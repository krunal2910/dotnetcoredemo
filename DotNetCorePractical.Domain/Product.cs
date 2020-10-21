using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCorePractical.Domain
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Price must be numeric")]
        public decimal Price { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
