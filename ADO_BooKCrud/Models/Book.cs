﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_BooKCrud.Models
{
    public class Book
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Author { set; get; }

        public int Price { set; get; }
    }
}
