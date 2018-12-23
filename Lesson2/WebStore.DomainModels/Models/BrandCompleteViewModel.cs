﻿using System.Collections.Generic;

namespace WebStore.DomainModels.Models
{

        public class BrandCompleteViewModel
        {
            public IEnumerable<BrandViewModel> Brands { get; set; }
            public int? CurrentBrandId { get; set; }
        }

}