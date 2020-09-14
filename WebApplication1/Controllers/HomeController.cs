using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml;
using KostenVoranSchlagConsoleParser.Helpers;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            OrganizationServiceProxy serviceProxy = ConnectHelper.CrmService;
            var service = (IOrganizationService)serviceProxy;

            VoMainScript voMain = new VoMainScript(service);
            VoMainScriptModel voMainModel = new VoMainScriptModel
            {
                VoMainScriptEntities = voMain.GetVoMainScriptRecors()
            };

            return View(voMainModel);
        }
        [HttpPost]
        public ActionResult Index(DataCollection<Entity> entities)
        {
            var qwe = 123;
            return View();
        }

    }
}