using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPC.Demo
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }


        public override async Task ServerStreaming(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            for (int i = 0; i < 1000; i++)
            {
                var message = new HelloReply
                {
                    Message = "Hello " + i
                };


                await responseStream.WriteAsync(message);
            }
        }

        public override async Task<HelloReply> ClientStreaming(IAsyncStreamReader<HelloRequest> requestStream, ServerCallContext context)
        {
            var baseMessage = "I got ";
            HelloReply reply = new HelloReply() { Message = baseMessage };

            while (await requestStream.MoveNext())
            {

                var payload = requestStream.Current;
                Console.WriteLine($"I got a request with: { payload}");
                reply.Message = baseMessage + payload.Name.ToString();
            }
            return reply;
        }

        public override async Task BidirectionalStreaming(IAsyncStreamReader<HelloRequest> requestStream, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            var baseMessage = "";

            HelloReply reply = new HelloReply() { Message = baseMessage };
            while (await requestStream.MoveNext())
            {
                var payload = requestStream.Current;


                reply.Message = baseMessage + payload.Name.ToString();
                await responseStream.WriteAsync(reply);

            }
        }

    }
}
