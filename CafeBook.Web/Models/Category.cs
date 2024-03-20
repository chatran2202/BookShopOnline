using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CafeBook.Web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
		[DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Value must be between 1-500!")]
        public int DisplayOrder { get; set; }
    }
}
