﻿namespace Web.Models
{
    public class CartItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public int count { get; set; }
    }
}
