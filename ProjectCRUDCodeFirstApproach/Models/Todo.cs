using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCRUDCodeFirstApproach.Models
{
    [Table("Todo")]
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Todo Title is required")]
        [StringLength(100, ErrorMessage = "Title should be 100 character max")]
        [MinLength(3, ErrorMessage = "Title should contains atleast 3 character")]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"Id : {this.Id}, Title : {this.Title}, Description : {this.Description}";
        }
    }
}