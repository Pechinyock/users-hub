ARG NET_SDK_VERSION=9.0
ARG NUGET_SOURCE=http://localhost:9966/v3/index.json

FROM mcr.microsoft.com/dotnet/sdk:${NET_SDK_VERSION} AS builder

ARG NUGET_SOURCE

RUN dotnet nuget add source ${NUGET_SOURCE} --allow-insecure-connections &&\
    apt-get update &&\
    apt-get install -y clang

WORKDIR /src

COPY  . .

RUN --network=host dotnet restore
RUN dotnet publish -o user-hub

FROM debian:bookworm-slim AS runner
WORKDIR /app

COPY --from=builder /src/user-hub .

# Install minimal runtime dependencies
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
        libstdc++6 \
        libicu72 \
        zlib1g

CMD ["sh", "-c", "./UsersHub.API"]