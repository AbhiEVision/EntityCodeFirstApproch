using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace LearnEF.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        
    }
}