using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Application.ViewModels;
using Teste.Application.App;
using Teste.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.API.Controllers
{
    [Route("feed")]
    [ApiController]
    public class InfoGeneralController : ControllerBase
    {
        private readonly IFeedApp FeedApp;

        public InfoGeneralController(IFeedApp feedApp)
        {
            FeedApp = feedApp;
        }

        [HttpGet]
        [Route("get-info-general")]
        public ResultVM GetInfoGeneral() =>
            FeedApp.GetInfoGeneral();
    }
}
