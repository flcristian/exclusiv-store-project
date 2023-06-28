using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product_page_generator.jsondata
{
    public class JsonData
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

        public JsonData(int id, string name, string[] description, string[] paths, double price, string[] tags, string[] sizes, string materials, bool stock)
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

        // Accessors

        public int id
        {
            get { return _id; }
            set
            { 
                _id = value; 
            }
        }

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string[] description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }

        public string[] paths
        {
            get { return _paths; }
            set
            {
                _paths = value; 
            }
        }

        public double price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }

        public string[] tags
        {
            get { return _tags; }
            set
            {
                _tags = value;
            }
        }

        public string[] sizes
        {
            get { return _sizes; }
            set
            {
                _sizes = value;
            }
        }

        public string materials
        {
            get { return _materials; }
            set
            {
                _materials = value;
            }
        }

        public bool stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
            }
        }
    }
}
