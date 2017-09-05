using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WCFChatConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Chat ch = new WCFChatConsole.Chat();

            var chThread = new Thread(ch.Run) { IsBackground = true };

            chThread.Start();

            Thread.Sleep(5000);

            Console.WriteLine("Usuario: ");
            string usr = Console.ReadLine();

            while (true)
            {
                string msg = Console.ReadLine();

                if (msg == "") break;

                CompositeType cmp = new CompositeType();
                cmp.usr = usr;
                cmp.msg = msg;

                ch.Channel.recvMessage(cmp);
                
            }
        }
    }
}
