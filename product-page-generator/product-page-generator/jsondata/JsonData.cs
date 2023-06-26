﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product_page_generator.jsondata
{
    public class JsonData
    {
        private int _id;
        private string _description;
        private string _path;
        private double _price;
        private string[] _tags;
        private bool _stock;

        // Constructors

        public JsonData(int id, string description, string path, double price, string[] tags, bool stock)
        {
            _id = id;
            _description = description;
            _path = path;
            _price = price;
            _tags = tags;
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

        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }

        public string path
        {
            get { return _path; }
            set
            {
                _path = value; 
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
