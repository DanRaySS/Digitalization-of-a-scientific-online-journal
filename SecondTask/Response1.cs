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
        public string status { get; set; }
        [JsonPropertyName("message-type")]
        public string message_type { get; set; }
        [JsonPropertyName("message-version")]
        public string message_version { get; set; }
        public Message message { get; set; }

        public class Message
        {
            public Author[] author { get; set; }

            public string[] title { get; set; }
            [JsonPropertyName("container-title")]
            public string[] container_title { get; set; }
            public License[] license { get; set; }
            public class License
            {
                public Start start { get; set; }
                public class Start
                {
                    [JsonPropertyName("date-time")]
                    public string date { get; set; }
                }
            }
            public string volume { get; set; }
            public string page { get; set; }
        }
    }
}
