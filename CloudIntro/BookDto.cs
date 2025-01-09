using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace CloudIntro
{
    public class BookDto
    {
        [Required]
        [JsonPropertyName("name")]
        public string Title { get; set; } = "";
        [Required]
        [JsonPropertyName("author")]
        public string Author { get; set; } = "";
        [JsonPropertyName("description")]
        public string Description { get; set; } = "";
    }
}
