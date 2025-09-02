﻿

using System.ComponentModel.DataAnnotations;

namespace BlogCMS.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Slug { get; set; } = string.Empty;

        public List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    }
}