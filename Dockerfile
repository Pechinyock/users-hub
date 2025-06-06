# Build app
ARG NET_SDK_VERSION=9.0
ARG NUGET_SOURCE=http://localhost:9966/v3/index.json
ARG CONFIGURATION=Staging
ARG ASPNETCORE_ENVIRONMENT=Staging

FROM mcr.microsoft.com/dotnet/sdk:${NET_SDK_VERSION} AS builder

ARG NUGET_SOURCE
ARG CONFIGURATION

RUN dotnet nuget add source ${NUGET_SOURCE} --allow-insecure-connections &&\
    apt-get update &&\
    apt-get install -y clang

WORKDIR /src

COPY  . .

RUN --network=host dotnet restore
RUN dotnet publish -o user-hub -c ${CONFIGURATION}

# Run app

ARG ENVIRONMENT_NAME=Staging
ENV ASPNETCORE_ENVIRONMENT=Staging
FROM debian:bookworm-slim AS runner
WORKDIR /app

COPY --from=builder /src/user-hub .

ENV ASPNETCORE_ENVIRONMENT=${ENVIRONMENT_NAME}

# Install minimal runtime dependencies
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
        libstdc++6 \
        libicu72 \
        zlib1g \
        openssl

CMD ["sh", "-c", "/bin/bash"]