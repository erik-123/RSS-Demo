using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RSS_Demo.Data
{
    static class CategoryRepo
    {
        static public List<string> LoadCategories()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<string>));
            try
            {
                using (var filestream = File.OpenRead("./category.xml"))
                {
                    return (List<string>)xmlSerializer.Deserialize(filestream);
                }
            }
            catch (FileNotFoundException)
            {
                return new List<string>();
            }
        }
        static public void SaveCategories(List<string> categories)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<string>));

            using (var fileStream = File.OpenWrite("./category.xml"))
            {
                var writer = new StreamWriter(fileStream);
                xmlSerializer.Serialize(writer, categories);
            }
        }
    }
}
