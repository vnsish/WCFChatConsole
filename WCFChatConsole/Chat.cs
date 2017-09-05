using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WCFChatConsole
{
    public class Chat
    {
        public IChatService Channel;
        public IChatService Host;
        private DuplexChannelFactory<IChatService> _factory;

        public Chat()
        {

        }

        public void StartService()
        {
            var binding = new NetPeerTcpBinding();
            binding.Security.Mode = SecurityMode.None;

            var endpoint = new ServiceEndpoint(
                ContractDescription.GetContract(typeof(IChatService)),
                binding,
                new EndpointAddress("net.p2p://SimpleP2P"));

            Host = new ChatService();

            _factory = new DuplexChannelFactory<IChatService>(new InstanceContext(Host), endpoint);

            var channel = _factory.CreateChannel();

            ((ICommunicationObject)channel).Open();
            

            Channel = channel;

        }

        public void StopService()
        {
            Console.WriteLine("[ Stopping Service ]");
            
            ((ICommunicationObject)Channel).Close();
            if (_factory != null)
                _factory.Close();

            Console.WriteLine("[ Service Stopped ]");

        }

        public void Run()
        {
            Console.WriteLine("[ Starting Service ]");

            StartService();

            Console.WriteLine("[ Service Started ]");

        }


    }


}
