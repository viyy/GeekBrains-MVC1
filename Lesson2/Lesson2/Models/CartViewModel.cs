﻿using System.Collections.Generic;
using System.Linq;

namespace WebStore.Models
{
    public class CartViewModel
    {
        public Dictionary<ProductViewModel, int> Items { get; set; }

        public int ItemsCount
        {
            get
            {
                return Items?.Sum(x => x.Value) ?? 0;
            }
        }

    }
}