﻿namespace DashBoard.DAL.Models
{
    public class SubCategory : BaseEntity
    {
        //public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public bool? Active { get; set; } 
        public DateTime CreatedAt { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Products> Products { get; set; }
    }
}