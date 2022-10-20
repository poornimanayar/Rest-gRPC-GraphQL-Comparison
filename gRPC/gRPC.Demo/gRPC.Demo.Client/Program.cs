using gRPC.Demo.Protos;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace gRPC.Demo.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //create a channel, a connection to the service
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            //instantiate the client
            var client = new User.UserClient(channel);

             client.TestError(new Google.Protobuf.WellKnownTypes.Empty());

            ////call the get users stub method
            //var reply = await client.GetUsersAsync(new UserListRequestModel());

            //Console.WriteLine("========================================================");
            //Console.WriteLine("Users");
            //Console.WriteLine("========================================================");

            //foreach(var user in reply.Users)
            //{
            //    Console.WriteLine($"{user.Id} . {user.Name} - {user.Headline}");
            //}

            //Console.WriteLine("Press any key to exit...");

            Console.ReadKey();
        }
    }
}
