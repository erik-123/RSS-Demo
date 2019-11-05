using RSS_Demo;

namespace InterfaceMeddelande
{
    public class MessageController//kategorierExtra //: RSS_Demo.IKategori
    {
        public string Category { get; set; }
       // List<string> categoryList;
        private readonly RSS_Demo.IMessage messageClient;
       

        public MessageController(IMessage client)
        {
            messageClient = client;
        }
        public void InterfaceMessage()
        {
            messageClient.Message();
        }
    }
}