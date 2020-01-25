﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace Filmoteka.Models
{
    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }

    }
}