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
        private string[] _description;
        private string[] _paths;
        private double _price;
        private string[] _tags;
        private string[] _sizes;
        private string _materials;
        private bool _stock;

        // Constructors

        public Product(int id, string name, string[] description, string[] paths, double price, string[] tags, string[] sizes, string materials, bool stock)
        {
            _id = id;
            _name = name;
            _description = description;
            _paths = paths;
            _price = price;
            _tags = tags;
            _sizes = sizes;
            _materials = materials;
            _stock = stock;
        }

        public Product(JsonElement item)
        {
            // ASSIGNING ID
            _id = item.GetProperty("id").GetInt32();

            // ASSIGNING NAME
            _name = item.GetProperty("name").GetString();

            // ASSIGNING DESCRIPTION
            List<string> description = new List<string>();
            JsonElement arrayProperty = item.GetProperty("description");
            foreach (JsonElement element in arrayProperty.EnumerateArray())
            {
                description.Add(element.GetString());
            }
            _description = description.ToArray();

            // ASSIGNING PATHS
            List<string> paths = new List<string>();
            arrayProperty = item.GetProperty("paths");
            foreach (JsonElement element in arrayProperty.EnumerateArray())
            {
                paths.Add(element.GetString());
            }
            if(paths.Count() == 0)
            {
                paths = new List<string> { "https://placehold.it/240x320?text=ERROR_404_Image_file_not_found" };
            }
            _paths = paths.ToArray();

            // ASSIGNING PRICE
            _price = item.GetProperty("price").GetDouble();

            // ASSIGNING TAGS
            List<string> tags = new List<string>();
            arrayProperty = item.GetProperty("tags");
            foreach (JsonElement element in arrayProperty.EnumerateArray())
            {
                tags.Add(element.GetString());
            }
            _tags = tags.ToArray();

            // ASSIGNING SIZES
            List<string> sizes = new List<string>();
            arrayProperty = item.GetProperty("sizes");
            foreach (JsonElement element in arrayProperty.EnumerateArray())
            {
                sizes.Add(element.GetString());
            }
            if (sizes.Count() == 0)
            {
                sizes = new List<string> { "~marimi~" };
            }
            _sizes = sizes.ToArray();

            // ASSIGNING MATERIALS
            _materials = item.GetProperty("materials").GetString();
            if (_materials == null || _materials.Equals(""))
            {
                _materials = "~materiale~";
            }

            // ASSIGNING STOCK
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

        public string[] Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }

        public string[] Paths
        {
            get { return _paths; }
            set
            {
                _paths = value;
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

        public string[] Sizes
        {
            get { return _sizes; }
            set
            {
                _sizes = value;
            }
        }

        public string Materials
        {
            get { return _materials; }
            set
            {
                _materials = value;
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
            desc += $"Description: ";
            for (int i = 0; i < _description.Count(); i++)
            {
                desc += $"{_description[i]} ";
            }
            desc += "\n";
            desc += $"Paths: ";
            for (int i = 0; i < _paths.Count(); i++)
            {
                desc += $"{_paths[i]} ";
            }
            desc += "\n";
            desc += $"Price: {_price}\n";
            desc += $"Tags: ";
            for(int i = 0; i < _tags.Count(); i++)
            {
                desc += $"{_tags[i]} ";
            }
            desc += "\n";
            desc += $"Sizes: ";
            for (int i = 0; i < _sizes.Count(); i++)
            {
                desc += $"{_sizes[i]} ";
            }
            desc += "\n";
            desc += $"Materials: {_materials}\n";
            desc += $"Stock: {_stock}\n";

            return desc;
        }

        public string CreateHtmlPageString()
        {
            string htmlContent = $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <meta name='description' content='Magazin online pentru femei. Haine perfecte pentru stilul tau'>
   <meta name='keywords' content='";
            foreach(string tag in _tags)
            {
                htmlContent += tag + ", ";
            }
            htmlContent += $@"magazin online, imbracaminte, imbracaminte femei, haine dama, haine dama online, haine femei, haine made in Roamania, haine online, rochii dama, rochii online, bluze femei, bluze, pantaloni, geci, veste, bluze femei, pantaloni femei, veste femei'>
    <link rel='preconnect' href='https://fonts.googleapis.com'>
    <link rel='preconnect' href='https://fonts.gstatic.com' crossorigin>
    <link href='https://fonts.googleapis.com/css2?family=Gruppo&display=swap' rel='stylesheet'>
    <link href='https://fonts.googleapis.com/css2?family=Open+Sans&display=swap' rel='stylesheet'>
    <script src='https://kit.fontawesome.com/207839565f.js' crossorigin='anonymous'></script>
    <script src='scripts/script.js'></script>
    <link rel='stylesheet' href='../style/reset.css'>
    <link rel='stylesheet' href='style/product.css'>
    <title>Exclusiv - {_name}</title>
</head>
<body>
    <div id='top'></div>
    <header class='navbar-container' id='navbar'>
        <section class='left-navbar-container'>
            <a class='navbar-watermark' href='../index.html'>Exclusiv</a>
        </section>
        <section class='right-navbar-container'>
            <a class='navbar-item navbar-contact' href='../index.html'>CONTACT</a>
            <a class='navbar-item navbar-instagram' href='https://www.instagram.com/exclusiv.ro/' target='_blank'><i class=' fa-brands fa-instagram fa-lg' style='color: #ffffff'></i></a>
        </section>
    </header>

    <section class='product-container'>
        <section class='image-container'>
            <button id='left-image-button' onclick='previousImage()' class='image-button-left'></button>  
            <img id='product-image' class='image-item' src='{_paths[0]}' alt='' onclick='openOverlay()'/>
            <div id='overlay' onclick='closeOverlay()'>
                <img id='overlay-image' src=''>
            </div>
            <button  id='right-image-button' onclick='nextImage()' class='image-button-right'></button>
        </section>
        <section class='product-details'>
            <h1 class='product-details-item product-name'>{_name}</h1>
            <h1 class='product-details-item product-price'>{_price} RON</h1>
            <section class='product-description'>";
            foreach(string desc in _description)
            {
                htmlContent += $"<p class='product-details-item'>{desc}</p>";
            }
            htmlContent += $@"<p class='product-details-item product-subtitle'>Lista de marimi :</p>
                <p class='product-details-item'>~marimi~</p>
                <p class='product-details-item product-subtitle'>Materiale :</p>
                <p class='product-details-item'>~materiale~</p>
                <p class='product-details-item product-warning'>Pentru a comanda, contactați-ne!</p>
            </section>
            <section class='button-container'>
                <div class='button'>
                    <a class='button-text' href='../index.html'>Contact</a>
                </div>
                <div class='home'>
                    <a class='home-text' href='../index.html'>Inapoi Acasa</a>
                </div>
            </section>
        </section>
    </section>
</body>
</html>
            ";
            return htmlContent;
        }
    }
}
