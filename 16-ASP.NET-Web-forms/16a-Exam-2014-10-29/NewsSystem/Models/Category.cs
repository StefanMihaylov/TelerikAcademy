﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsSystem.Models
{
    public class Category
    {
        private ICollection<Article> articles;

        public Category()
        {
            this.articles = new HashSet<Article>();
        }

        public int CategoryId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
    }
}