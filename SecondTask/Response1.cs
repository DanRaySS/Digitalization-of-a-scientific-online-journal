using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Response1
    {
        public string DOI { get; set; }
        public string? status { get; set; }
        [JsonPropertyName("message-type")]
        public string? message_type { get; set; }
        [JsonPropertyName("message-version")]
        public string? message_version { get; set; }
        public Message? message { get; set; }

        public class Message
        {
            public Author[]? author { get; set; }
            public class Author
            {
                public string given { get; set; }
                public string family { get; set; }
            }

            [JsonPropertyName("published-print")]
            public PublishedPrint? published_print { get; set; }
            public class PublishedPrint
            {
                [JsonPropertyName("date-parts")]
                public int[][]? date_parts { get; set; }
            }

            public Created? created { get; set; }
            public class Created
            {
                [JsonPropertyName("date-parts")]
                public int[][]? date_parts { get; set; }
            }

            public string[]? title { get; set; }

            [JsonPropertyName("container-title")]
            public string[]? container_title { get; set; }
            public string? issue { get; set; }
            public string? volume { get; set; }
            public string? page { get; set; }
        }
    }
}
