﻿using OnlineShop.Domain.Common;
using OnlineShop.Domain.Relations;

namespace OnlineShop.Domain.Models
{
    public class Value : BaseEntity<int>
    {
        public string Name { get; set; }

        public List<PropertyValue> PropertyValues { get; set; }
    }
}
