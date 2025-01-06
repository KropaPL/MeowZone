using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Core.DTO;

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
        public string? AuthorName { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public PostResponse ToPostResponse()
        {
	        return new PostResponse()
	        {
                Id = Id,
                AuthorId = AuthorId,
                CategoryId = CategoryId,
                Content = Content,
                CreatedAt = CreatedAt,
                Title = Title

	        };
        }
    }
}
