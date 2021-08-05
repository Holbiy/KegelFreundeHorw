using System;
using KegelFreundeHorw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace KegelFreundeHorw.Controllers
{
	public class ContactController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;

		public ContactController(ILogger<HomeController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult SendMail(MailViewModel model){
			var fromAddress = new MailAddress(_configuration.GetValue<string>("Mail:Address"), model.Name);
			var toAddress = new MailAddress(_configuration.GetValue<string>("Mail:Address"), "Kegel Freunde Horw");
			string fromPassword = _configuration.GetValue<string>("Mail:Password");
			string subject = model.Subject;
			string body = getContent(model);
			if (string.IsNullOrEmpty(body))
			{
				ViewBag.ErrorMessage = "Mail konnte nicht versendet werden.";
				return View("~/Views/Contact/Index.cshtml");
			}

			var smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
			};
			using (var message = new MailMessage(fromAddress, toAddress)
			{
				Subject = subject,
				Body = body,
				IsBodyHtml = true
			})
			{
				try
				{
					smtp.Send(message);
				}
				catch (Exception)
				{
					ViewBag.ErrorMessage = "Mail konnte nicht versendet werden.";
					return View("~/Views/Contact/Index.cshtml");
				}
			}

			return View("~/Views/Contact/Success.cshtml");
		}

		private string getContent(MailViewModel model)
		{
			string body;
			try
			{
				using (StreamReader reader = new StreamReader(_configuration.GetValue<string>("Mail:ContentPath")))
				{
					body = reader.ReadToEnd();
				}
			}
			catch (Exception)
			{
				return null;
			}

			body = body.Replace("!content!", model.Content);
			body = body.Replace("!name!", model.Name);
			body = body.Replace("!mail!", model.Sender);

			return body;

		}

	}
}
