using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

//locals
using BlazorApp.Shared;

namespace BlazorApp.Api
{
    public static class Configuration
    {
        [FunctionName("GetHeader")]
        public static async Task<HeaderModel> GetHeader(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            HeaderModel result = new HeaderModel()
            {
                AvatarURL = "/img/MyAvator.png",
                AvatarAltText = "Coding with David",
                Name = "CodingWithDavid",
                Summary = "One engineers path to learn new and exciting things."
            };
            await Task.CompletedTask;
            return result;
        }

        [FunctionName("GetFooter")]
        public static async Task<FooterModel> GetFooter(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            SocialLinks sl = new SocialLinks()
            {
                TwitterLink = "https://twitter.com/CodingwithDavid",
                GitHub = "https://github.com/CodingWithDavid",
                LinkedInLink = "https://www.linkedin.com/in/davidgallivan/"
            };

            FooterModel result = new FooterModel()
            {
                About = "CodingWithDavid",
                Message = "Coding with David tries to provide free coding tips, MIT licensed",
                SocialLinks = sl

            };
            await Task.CompletedTask;
            return result;
        }

        [FunctionName("GetAbout")]
        public static async Task<AboutModel> GetAbout(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            AboutModel result = new AboutModel()
            {
                RightSectionMessage = "I have been building solutions for a long time and I am working on giving back to my profession, that I have enjoyed for so many years",
                LeftSectionMessage = "My goal is to provide knowledge and skills to the engineers that follow me so they can learn how to be become Software Craftsman",
                LinkToOtherResources = "http://manifesto.softwarecraftsmanship.org/",
                LinkName = "Software Craftsmanship"
            };
            await Task.CompletedTask;
            return result;
        }

        [FunctionName("GetPortfilo")]
        public static async Task<PortfolioDataList> GetPortfilo(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            PortfolioDataList result = new PortfolioDataList();

            PortfolioDataModel data = new PortfolioDataModel()
            {
                ImageURL = "img/portfolio/cabin.png",
                Title = "Log Cabin",
                Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Mollitia neque assumenda ipsam nihil, molestias magnam, recusandae quos quis inventore quisquam velit asperiores, vitae? Reprehenderit soluta, eos quod consequuntur itaque. Nam."
            };
            result.Portfolios.Add(data);
            data = new PortfolioDataModel()
            {
                ImageURL = "img/portfolio/cake.png",
                Title = "Cakes",
                Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Mollitia neque assumenda ipsam nihil, molestias magnam, recusandae quos quis inventore quisquam velit asperiores, vitae? Reprehenderit soluta, eos quod consequuntur itaque. Nam."
            };
            result.Portfolios.Add(data);
            data = new PortfolioDataModel()
            {
                ImageURL = "img/portfolio/circus.png",
                Title = "Circus",
                Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Mollitia neque assumenda ipsam nihil, molestias magnam, recusandae quos quis inventore quisquam velit asperiores, vitae? Reprehenderit soluta, eos quod consequuntur itaque. Nam."
            };
            result.Portfolios.Add(data);
            data = new PortfolioDataModel()
            {
                ImageURL = "img/portfolio/game.png",
                Title = "Game",
                Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Mollitia neque assumenda ipsam nihil, molestias magnam, recusandae quos quis inventore quisquam velit asperiores, vitae? Reprehenderit soluta, eos quod consequuntur itaque. Nam."
            };
            result.Portfolios.Add(data);
            data = new PortfolioDataModel()
            {
                ImageURL = "img/portfolio/safe.png",
                Title = "Safe",
                Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Mollitia neque assumenda ipsam nihil, molestias magnam, recusandae quos quis inventore quisquam velit asperiores, vitae? Reprehenderit soluta, eos quod consequuntur itaque. Nam."
            };
            result.Portfolios.Add(data);
            data = new PortfolioDataModel()
            {
                ImageURL = "img/portfolio/submarine.png",
                Title = "Submarine",
                Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Mollitia neque assumenda ipsam nihil, molestias magnam, recusandae quos quis inventore quisquam velit asperiores, vitae? Reprehenderit soluta, eos quod consequuntur itaque. Nam."
            };
            result.Portfolios.Add(data);
            await Task.CompletedTask;
            return result;
        }
    }
}
