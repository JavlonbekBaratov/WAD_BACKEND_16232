using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WAD_BACKEND_16232.Models
{
    public class KeyCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Key category name is required")]
        public string KeyCategoryName { get; set; }

        public string KeyDescription { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SecurityLevel SecurityLevel { get; set; }
    }

    public enum SecurityLevel
    {
        high,
        medium,
        low
    }
}
