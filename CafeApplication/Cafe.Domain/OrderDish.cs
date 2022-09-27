﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain
{
    public class OrderDish
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public virtual Dish Dish { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}