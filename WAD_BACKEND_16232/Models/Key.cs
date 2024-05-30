using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WAD_BACKEND_16232.Models
{
    public class Key
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Key name is required")]
        public string KeyName { get; set; }

        public string KeyInstruction { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive value")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Manufacturer is required")]
        public string Manufacturer { get; set; }

        public int? KeyCategoryID { get; set; }

        [ForeignKey("KeyCategoryID")]
        public KeyCategory? KeyCategory { get; set; }
    }
}
