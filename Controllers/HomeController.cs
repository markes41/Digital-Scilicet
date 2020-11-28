using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DigitalScilicet.Models;
using System.Net.Mail;

namespace DigitalScilicet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nosotros()
        {
            return View();
        }

        public IActionResult FAQs()
        {
            return View();
        } 

        public IActionResult Contacto()
        {
            return View();
        } 

        public IActionResult Cursos()
        {
            return View();
        } 

        public IActionResult EnviarContacto(string nombre, string correo, string numTelefono, string motivo, string mensaje)
        {
            try
            {
            
            ViewBag.nombre = nombre;
            ViewBag.numTelefono = numTelefono;
            ViewBag.motivo = motivo;
            ViewBag.mail = correo;
            ViewBag.mensaje = mensaje;
            string mailNuestro = "digitalscilicet@gmail.com";
            string pass = "cZnQqWQx*";

            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(mailNuestro, pass);
            SmtpServer.EnableSsl = true;

            MailMessage mailMessage = new MailMessage(mailNuestro, correo);
            mailMessage.Subject = motivo;
            mailMessage.Body = @"
                <html>

                <style>
                    .parrafo{
                        color: red;
                    }
                </style>

                <h1 class='parrafo'>Cliente:"+nombre+@"</h1>

                </html>"
                
                
                ;
            mailMessage.IsBodyHtml = true;

            SmtpServer.Send(mailMessage);

            
            }catch(Exception e)
            {
                Console.Out.Write(e);
            }
            return View("ok!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
