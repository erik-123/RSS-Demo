using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RSS_Demo.Data
{
    internal static class CategoryRepo
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
                var categoryList = new List<string>();
                categoryList.Add("Visa alla podcasts");
                return categoryList;
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