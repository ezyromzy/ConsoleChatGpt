﻿using System.Text.Json.Serialization;

namespace ConsoleChatGpt
{
    public class Request
    {
        [JsonPropertyName("model")]
        public string ModelId { get; set; } = "";
        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; } = new();
    }
}
