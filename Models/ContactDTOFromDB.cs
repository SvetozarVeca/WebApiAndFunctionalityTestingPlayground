using System.Text.Json.Serialization;

namespace Models
{
    public class ContactDTOFromDB : ContactDTOFromUser
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("__v")]
        public int Version { get; set; }

    }
}
