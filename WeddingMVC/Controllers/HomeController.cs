using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using WeddingMVC.Models;

namespace WeddingMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Start()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MassageToUser()
        {
            return View();
        }

        public ActionResult Location()
        {
            return View();
        }

        public ActionResult Quiz()
        {
            ViewData["listOfIsExist"] = new [] {
                                            new SelectListItem {Text = "Yes", Value = "True"},
                                            new SelectListItem {Text = "Yes Yes", Value = "False"}
                                        };
            ViewData["listOfSize"] = Enumerable.Range(25, 24)
                                               .Select(age => Convert.ToString(age, CultureInfo.InvariantCulture))
                                               .Select(age => new SelectListItem {Text = age, Value = age})
                                               .ToList();
            return View(new Quiz());
        }

        [HttpPost]
        public ActionResult Quiz(Quiz quiz)
        {
            if (IsStupidBot())
            {
                TempData["Thanks"] = "You are the bot!";
            }
            else
            {
                var isSent = SendQuizResultToEmail(quiz);
                TempData["Thanks"] = isSent ? "Спасибки, всем чмоки!" : "Простите, но результаты не сохранились, пожалуйста сообщите об этом Денису или Алёне. :(";
            }

            return RedirectToAction("MassageToUser");
        }

        public ActionResult Email(Quiz quiz)
        {
            return View(quiz);
        }


        private bool IsStupidBot()
        {
            return !string.IsNullOrEmpty(Convert.ToString(this.Request.Form["honeyspot"]));
        }

        private bool SendQuizResultToEmail(Quiz quiz)
        {
            try
            {
                var smtp = new SmtpClient();
                var mail = new MailMessage
                {
                    Subject = "[QUIZ] " + quiz.Fio,
                    IsBodyHtml = true, Body = GetEmailBody(quiz)
                };
                mail.To.Add("dmak563@gmail.com");
                mail.To.Add("alyonabazhanova@gmail.com");
				mail.To.Add("andreybazhanov@rambler.ru");
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                return false;
            }
            return true;
        }

        private string GetEmailBody(Quiz quiz)
        {
            using (var writer = new StringWriter())
            {
                var viewData = new ViewDataDictionary { Model = quiz };
                var tempData = new TempDataDictionary();
                var view = ViewEngines.Engines.FindView(ControllerContext, "Email", null);
                var context = new ViewContext(ControllerContext, view.View, viewData, tempData, writer);
                view.View.Render(context, writer);
                writer.Flush();
                return writer.ToString();
            }
        }
    }
}