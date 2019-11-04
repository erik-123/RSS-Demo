using RSS_Demo;
using RSS_Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceMeddelande
{
    public class MessageController//kategorierExtra //: RSS_Demo.IKategori
    {

        public string Category { get; set; }
       // List<string> categoryList;
        private RSS_Demo.IMeddelande messageClient;
       

        public MessageController(IMeddelande client)
        {
           messageClient = client;
        }
        public void InterfaceMeddelande()
        {
            messageClient.Meddelande();
        }
             


       // public void taBortKategori(string category)
       //  {
       //    try {
       //  var befintligaKategorier = CategoryRepo.LoadCategories();

        // foreach (var kategori in befintligaKategorier)
        //  {
        //    int index = befintligaKategorier.IndexOf(category);
        //  befintligaKategorier.RemoveAt(index);

        //  } 
        // }          
        //  catch (Exception)
        // {
        //     MessageBox.Show("Den valda kategorin kunde inte tas bort!");
        // }






        //  }
    }
}

