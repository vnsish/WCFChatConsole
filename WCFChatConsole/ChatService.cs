using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFChatConsole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChatService" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
       

        public ChatService ()
        {
           
        }

        public void recvMessage(CompositeType composite)
        {
            Console.WriteLine(composite.usr + ": " + composite.msg);
        }
    }
}
