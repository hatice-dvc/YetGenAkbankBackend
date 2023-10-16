using Microsoft.AspNetCore.Mvc;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using System.Diagnostics;
using OpenAI.Interfaces;
using YetGenAkbankJump.MVCClient.Models;

namespace YetGenAkbankJump.MVCClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOpenAIService _openAiService;

        public HomeController(ILogger<HomeController> logger, IOpenAIService openAiService)
        {
            _logger = logger;
            _openAiService = openAiService;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> Index(HomeIndexViewModel viewModel)
        {

            var imageResult = await _openAiService.Image.CreateImage(new ImageCreateRequest
            {
                Prompt = " Velociraptors with red ties",
                N = 3,
                Size = StaticValues.ImageStatics.Size.Size512,
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = "KalayMaster"
            });

            List<string> urls;

            if (imageResult.Successful)
            {
                urls = imageResult.Results.Select(r => r.Url).ToList();
            }

            return View();

            var completionResult = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {

                Messages = new List<ChatMessage> { 
                    ChatMessage.FromUser(viewModel.Prompt)
                },
                Model = OpenAI.ObjectModels.Models.Gpt_3_5_Turbo,
                MaxTokens = 3500

            });

            if (completionResult.Successful)
            {
                viewModel.ChatGPTResponse = completionResult.Choices.First().Message.Content;
            }

            return View(viewModel);

        }

        [HttpGet]
        public IActionResult SeriTarikGetir()
        {
            return View();
        }
        [HttpGet]
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