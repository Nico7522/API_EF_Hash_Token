﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class FilterModel
    {
        public string? ModelName { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Sexe { get; set; }
        public FilterModel(string? modelName = null, string? category = null, string? brand = null, string? sexe = null)
        {
            ModelName = modelName;
            Category = category;
            Brand = brand;
            Sexe = sexe;
        }

    }
}