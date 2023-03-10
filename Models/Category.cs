using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BullkBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        [DisplayName ("Display Order")]
        [Range(2,100,ErrorMessage ="Display order must be 1 to 100!!")]
        public int DisplayOrder { get; set; }
        public DateTime createdDateTime { get; set; }= DateTime.Now;
    }
}
