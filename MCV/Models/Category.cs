﻿namespace MCV.Models
{
    public class Category
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public bool Status { get; set; }

        public List<ShoeDetail> ShoeDetails { get; set; }
    }
}
