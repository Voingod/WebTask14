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
            try
            {
                OrganizationServiceProxy serviceProxy = ConnectHelper.CrmService;
                var service = (IOrganizationService)serviceProxy;

                VoMainScripts voMainScripts = new VoMainScripts(service);
                VoMainScriptModel voMainScriptModel = new VoMainScriptModel();
                voMainScriptModel.voMainScriptChecked = voMainScripts.GetCheckedVoMainScripts();

                ViewBag.RecordName = ConfigurationManager.AppSettings.Get("RecordName");
                ViewBag.StatusStart = "All okay, choose file and click Attach";

                return View(voMainScriptModel);

            }
            catch (Exception)
            {
                ViewBag.StatusStart = "Something is wrong";
                return View();
            }

        }
        [HttpPost]
        public ActionResult Index(VoMainScriptModel voMainScriptModel, HttpPostedFileBase myFileName)
        {
            try
            {
                OrganizationServiceProxy serviceProxy = ConnectHelper.CrmService;
                var service = (IOrganizationService)serviceProxy;

                int fileLength = myFileName.ContentLength;
                byte[] arr = new byte[fileLength];
                myFileName.InputStream.Read(arr, 0, fileLength);
                string fileAsString = Convert.ToBase64String(arr);

                Random random = new Random();

                Entity Note = new Entity("annotation");
                Note["subject"] = "My File № " + random.Next(0, 500);
                Note["notetext"] = "Was attached: " + DateTime.Today;
                Note["documentbody"] = fileAsString;
                Note["mimetype"] = myFileName.ContentType;
                Note["filename"] = myFileName.FileName;

                foreach (var item in voMainScriptModel.voMainScriptChecked)
                {
                    if (item.IsChecked)
                    {
                        Note["objectid"] = new EntityReference(item.VoMainScriptEntity.LogicalName, item.VoMainScriptEntity.Id);
                        Note["objecttypecode"] = item.VoMainScriptEntity.LogicalName;

                        service.Create(Note);
                    }
                }
                //ViewBag.StatusEnd = "File was attached to chosen records";
            }
            catch (Exception)
            {

                //ViewBag.StatusEnd = "Something is wrong";
            }
            return RedirectToAction("Index");
        }

    }
}