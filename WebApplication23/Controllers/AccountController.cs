using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using WebApplication23.Models;

namespace WebApplication23.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SendEmail(SendEmailViewModel model)
        {
            var message = await EMailTemplate("WelcomeEmail");
            message = message.Replace("@ViewBag.Name", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.FirstName));
            await MassageServices.SendEmailAsync(model.Email, "Welcome!", message);
            return View("EmailSent");
        }

        public ActionResult EmailSent()
        {
            return View();
        }

        public static async Task <string> EMailTemplate(string template)
        {
            var templateFilePath = HostingEnvironment.MapPath("~/Content/templates/") + template + ".cshtml";
            StreamReader objstreamreaderfile = new StreamReader(templateFilePath);
            var body = await objstreamreaderfile.ReadToEndAsync();
            objstreamreaderfile.Close();
            return body;
        }
    }
}