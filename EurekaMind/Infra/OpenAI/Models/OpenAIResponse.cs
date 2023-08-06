﻿namespace EurekaMind.Infra.OpenAI.Models
{
    public class OpenAIResponse
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public int Created { get; set; }
        public string Model { get; set; }
        public Choice[] Choices { get; set; }
        public Usage Usage { get; set; }
        public OpenAIError? Error { get; set; }
    }
}
