﻿using System.ComponentModel.DataAnnotations;

namespace DashBoard.DAL.Models
{
    public class Category : BaseEntity
    {
        //public int Id { get; set; }
        public bool? Active { get; set; } 
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } 
        public string Descrption { get; set; } = string.Empty;
        public string ImageFileName { get; set; } = string.Empty;

        public List<Products> Products { get; set; } = new List<Products>();
        public List<SubCategory> SubCategories { get; set; }
    }
}