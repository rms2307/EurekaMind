﻿using EurekaMind.Infra.OpenAI.Models;
using EurekaMind.Infra.Services.Interfaces;
using EurekaMind.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EurekaMind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOpenAITextService _openAITextService;

        public HomeController(ILogger<HomeController> logger, IOpenAITextService openAITextService)
        {
            _logger = logger;
            _openAITextService = openAITextService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string question)
        {
            List<Message> messages = new()
            {
                new()
                {
                    Content = question,
                    Role = "user"
                }
            };
            OpenAIRequest openAIRequest = new(messages);
            OpenAIResponse openAIResponse = await _openAITextService.CompletePrompt(openAIRequest);

            QuestionViewModel model = new();
            if (openAIResponse != null)
            {
                model.Question = question;
                model.Answer = openAIResponse.Choices[0].Message.Content;
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}