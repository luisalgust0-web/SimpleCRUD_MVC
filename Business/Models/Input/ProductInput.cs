﻿namespace SimpleCRUD_MVC.Business.Models.Input
{
    public class ProductInput
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public bool Disponibility { get; set; }
    }
}
