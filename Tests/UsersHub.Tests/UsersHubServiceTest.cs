﻿using Moq;
using Grpc.Core;
using Grpc.Core.Testing;
using TaskTrain.UserHub;
using TaskTrain.Contracts;

namespace UsersHub.Tests;

public class UsersHubServiceTest
{
    [Fact]
    public void ExampleGRPCUnitTest()
    {
        Assert.True(true);
        //var mockUserHubSvc = new Mock<IUserHubService>();

        //var grpcService = new UsersHubGRPC(mockUserHubSvc.Object);

        //var requset = new CreateUserRequest() { Login ="dfdf"
        //    , Password ="dfdf"
        //    , RepeatPassword= "123e4"
        //};
        //var context = TestServerCallContext.Create(method: nameof(UsersHubGRPC.Create)
        //    , host: "localhost"
        //    , deadline: DateTime.Now.AddMinutes(30)
        //    , requestHeaders: new Metadata()
        //    , cancellationToken: CancellationToken.None
        //    , peer: "10.0.0.25:5001"
        //    , authContext: null
        //    , contextPropagationToken: null
        //    , writeHeadersFunc: (metadata) => Task.CompletedTask
        //    , writeOptionsGetter: () => new WriteOptions()
        //    , writeOptionsSetter: (writeOptions) => { }
        //);

        //var response = await grpcService.Create(requset, context);
    }
}
