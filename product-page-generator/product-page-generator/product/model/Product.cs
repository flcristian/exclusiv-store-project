using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace product_page_generator.product.model
{
    public class Product
    {
        private int _id;
        private string _name;
        private string _description;
        private string _path;
        private double _price;
        private string[] _tags;
        private bool _stock;

        // Constructors

        public Product(int id, string name, string description, string path, double price, string[] tags, bool stock)
        {
            _id = id;
            _name = name;
            _description = description;
            _path = path;
            _price = price;
            _tags = tags;
            _stock = stock;
        }

        public Product(JsonElement item)
        {
            _id = item.GetProperty("id").GetInt32();
            _name = "name";
            _description = item.GetProperty("description").GetString();
            _path = item.GetProperty("path").GetString();
            _price = item.GetProperty("price").GetDouble();
            List<string> tags = new List<string>();
            JsonElement arrayProperty = item.GetProperty("tags");
            foreach (JsonElement element in arrayProperty.EnumerateArray())
            {
                tags.Add(element.GetString());
            }
            _tags = tags.ToArray();
            _stock = item.GetProperty("stock").GetBoolean();
        }

        // Accessors

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }

        public string[] Tags
        {
            get { return _tags; }
            set
            {
                _tags = value;
            }
        }

        public bool Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
            }
        }

        // Methods

        public override string ToString()
        {
            string desc = "";

            desc += $"Product {_id}\n";
            desc += $"Name: {_name}\n";
            desc += $"Description: {_description}\n";
            desc += $"Path: {_path}\n";
            desc += $"Price: {_price}\n";
            desc += $"Tags: ";
            for(int i = 0; i < _tags.Count(); i++)
            {
                desc += $"{_tags[i]} ";
            }
            desc += "\n";
            desc += $"Stock: {_stock}\n";

            return desc;
        }

        public string CreateHtmlPageString()
        {
            string htmlContent = $@"
            <html>
                <head>
                    <title>{_name}</title>
                </head>
                <body>
                    <h1>{_name}</h1>
                    <p>{_description}</p>
                </body>
            </html>
            ";
            return htmlContent;
        }
    }
}
