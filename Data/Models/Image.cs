﻿namespace MCV.Models
{
    public class Image
    {
        public Guid id { get; set; }
        public Guid? ShoeDetailId { get; set; }
        public string ImgUrl { get; set; }
        public virtual ShoeDetail? ShoeDetail { get; set; }

    }
}
