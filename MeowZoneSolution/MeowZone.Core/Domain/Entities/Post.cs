using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.IdentityEntities;

namespace MeowZone.Core.Domain.Entities
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("Author")]
        public Guid AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public int ViewCount { get; set; } = 0;

		[StringLength(500)]
        public string Summary { get; set; }   

        public bool IsPublished { get; set; }
    }
}
