using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using product_page_generator.product.model;
using product_page_generator.jsondata;
using System.Net.Http;

namespace product_page_generator.product.service
{
    public class ProductService
    {
        private List<Product> _list;

        // Constructors

        public ProductService()
        {
            _list = new List<Product>();
            this.ReadList();
        }

        public ProductService(List<Product> list)
        {
            _list = list;
        }

        // Methods

        public void ReadList()
        {
            JsonDocument jsonDocument = JsonDocument.Parse(File.ReadAllText("products.json"));
            JsonElement root = jsonDocument.RootElement;
            foreach (JsonElement item in root.EnumerateArray())
            {
                Product product = new Product(item);
                _list.Add(product);
            }
            jsonDocument.Dispose();
        }

        public void SaveList()
        {
            // CREATING BACKUP
            Directory.CreateDirectory("backups");
            DateTime currentTime = DateTime.Now;
            string timeString = currentTime.ToString("yyyy-MM-dd-HH-mm-ss");
            string filePath = $"backups/backup-{timeString}.json";
            FileStream fileStream = File.Create(filePath);
            fileStream.Close();
            File.WriteAllText(filePath, File.ReadAllText("products.json"));

            // SAVING PRODUCT LIST TO JSON
            List<JsonData> list = new List<JsonData>();
            foreach(Product product in _list)
            {
                list.Add(new JsonData(product.Id, product.Name, product.Description, product.Paths, product.Price, product.Tags, product.Stock));
            }
            JsonData[] data = list.ToArray();
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText("products.json", jsonString);
        }

        public void test()
        {
            Console.WriteLine(_list[0].CreateHtmlPageString());
        }

        public void ClearHtmlPages(string folderPath)
        {
            foreach (string filePath in Directory.GetFiles(folderPath))
            {
                File.Delete(filePath);
            }

            foreach (string subdirectoryPath in Directory.GetDirectories(folderPath))
            {
                ClearHtmlPages(subdirectoryPath);
                Directory.Delete(subdirectoryPath);
            }
        }

        public void CreateAllHtmlPages()
        {
            SaveList();
            ClearHtmlPages("product-pages");
            foreach(Product product in _list)
            {
                string content = product.CreateHtmlPageString();
                string filePath = $"product-pages/product-{product.Id}.html";
                FileStream fileStream = File.Create(filePath);
                fileStream.Close();
                File.WriteAllText(filePath, content);
            }
        }
    }
}
