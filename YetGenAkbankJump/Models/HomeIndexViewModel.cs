﻿namespace YetGenAkbankJump.MVCClient.Models
{
    public class HomeIndexViewModel
    {
        public string Prompt { get; set; }
        public int ImageCount { get; set; }

        public List<string> ImageUrls { get; set; }
        public string ChatGPTResponse { get; internal set; }

        public HomeIndexViewModel()
        {
            ImageUrls = new List<string>();
        }
    }
}
