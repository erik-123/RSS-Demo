using RSS_Demo;

namespace InterfaceMeddelande
{
    public class MessageController//kategorierExtra //: RSS_Demo.IKategori
    {
        public string Category { get; set; }
       // List<string> categoryList;
        private readonly RSS_Demo.IMeddelande messageClient;
       

        public MessageController(IMeddelande client)
        {
            messageClient = client;
        }
        public void InterfaceMeddelande()
        {
            messageClient.Meddelande();
        }
    }
}