using System;
using TestThrift.Contracts.Test;
using TestThrift.RPC.Test;
using Thrift.Server;
using Thrift.Transport;

namespace TestThrift.RPC
{
    class Program
    {
        private const int port = 8885;

        public static void Main(string[] args)
        {
            Console.WriteLine("[Welcome] TestService RPC Server is lanuched...");
            TServerTransport transport = new TServerSocket(port);
            var processor = new TestService.Processor(new TestServiceImpl());
            TServer server = new TThreadedServer(processor, transport);

            //多个服务
            //var processor1 = new TestService.Processor(new TestServiceImpl());
            //var processor2 = new Test2ServiceProcessor(new Test2ServiceImpl());
            //var processorMulti = new Thrift.Protocol.TMultiplexedProcessor();
            //processorMulti.RegisterProcessor("Service1", processor1);
            //processorMulti.RegisterProcessor("Service2", processor2);
            //TServer server = new TThreadedServer(processorMulti, transport);

            // lanuch
            server.Serve();
        }
    }
}
