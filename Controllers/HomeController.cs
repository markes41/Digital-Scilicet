using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Digital_Scilicet.Models;
using Cursos.Models;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;

namespace Digital_Scilicet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CursosContext db;

        public HomeController(ILogger<HomeController> logger, CursosContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            return View();
            
        }
        public IActionResult Nosotros()
        {
            Usuario usuario = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            if(usuario != null)
            {
                return View(usuario);
            }
            else
            {
                return View();
            }
        }
        public IActionResult FAQs()
        {
            return View();
        } 
        public IActionResult Contacto()
        {
            return View();
        } 
        public IActionResult Register()
        {
            Usuario usuario = HttpContext.Session.Get<Usuario>("UsuarioLogueado");

            if(usuario == null)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
        }
        public IActionResult Login()
        {
            Usuario usuario = HttpContext.Session.Get<Usuario>("UsuarioLogueado");

            if(usuario == null)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
        }
        public IActionResult RegistrarUsuario(string mail, string nombre, string username, string password, string claveadmin)
        {
            Usuario usuarioCheck = db.Usuarios.FirstOrDefault(u => u.Mail.Equals(mail) || u.Username.ToLower().Equals(username.ToLower()));
            string clave = "qwerty";
            string rol;

            if(clave.Equals(claveadmin))
                rol = "Administrador";
            else
                rol = "Usuario";

            if(usuarioCheck == null){
                Usuario nuevoUsuario = new Usuario{
                Mail = mail,
                Nombre = nombre,
                Username = username,
                Password = password,
                Rol = rol
            };

            db.Usuarios.Add(nuevoUsuario);
            db.SaveChanges();
            return View("Login");

            }else{
                ViewBag.existeUsuario = true;
                return View("Register");
            }   
        }
        public IActionResult LogearUsuario(string mail, string password)
        {
            Usuario usuarioCheckMail = db.Usuarios.FirstOrDefault(u => u.Mail.Equals(mail));
            Usuario checkUserLogged = HttpContext.Session.Get<Usuario>("UsuarioLogueado");

            if(checkUserLogged == null)
            {
                if(usuarioCheckMail != null && usuarioCheckMail.Password.Equals(password))
                {
                    HttpContext.Session.Set<Usuario>("UsuarioLogueado", usuarioCheckMail);
                    return View("Index");
                }
                else
                {

                    ViewBag.errorCredenciales = true;
                    return View("Login");
                }
            }
            else
            {
                return View("Index");
            }
        }
        public JsonResult ConsultarUsuario()
        {
            Usuario usuario = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            return Json(usuario);
        }
        public IActionResult Deslogear()
        {
            HttpContext.Session.Remove("UsuarioLogueado");
            return View("Index");
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
            string mailNuestro = "digitalscilicetest@gmail.com";
            string pass = "41465817m";

            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(mailNuestro, pass);
            SmtpServer.EnableSsl = true;

            MailMessage mailMessage = new MailMessage(mailNuestro, correo);
            mailMessage.Subject = "Recibimos tu consulta sobre: "+motivo;
            mailMessage.Body = @"
                
                <html>

                    <style>
                        .container{
                            font-family: 'Poppins', 'sans-serif';
                        }
                    </style>

                    <body>
                        <div class='container' style='text-align: center;'>
                            <img src='https://i.ibb.co/b6wLdLt/Head-Message.jpg' alt='' class='headmessage' style='display: block;margin: auto;'>
                            <p class='nombre' style='font-size: 3rem;margin-bottom: 0;'><b>¡Hola "+nombre+@"!</b></p>
                            <p class='mensajeConsulta' style='font-size: 1.5rem;color: #979797;'>Recibimos la consulta que realizaste en nuestra página</p>
                            <p class='motivo' style='text-transform: uppercase;color: #3a4d97;font-size: 1.8rem;margin-top: 5rem;'><b>["+motivo+@"]</b></p>
                            <p class='consulta' style='color: #979797;font-size: 1.3rem;margin: 0 20%;margin-bottom: 2rem;'>'"+mensaje+@"'</p>
                            <hr style='width: 70%;'>
                            <img src='https://i.ibb.co/QcFXFVF/RRSS.png' alt='' class='rrssImage' style='margin-top: 1.8rem;'>
                            <p class='copyright' style='color: #979797;font-size: 1.1rem;'>©Digital Scilicet Inc. | Nicaragua 4677, Capital Federal | Plataforma de cursos <br>
                            Si tenés alguna consulta por favor contáctanos en digitalscilicet@gmail.com </p>
                            
                        </div>
                    </body>
                </html>                
                ";
            mailMessage.IsBodyHtml = true;

            SmtpServer.Send(mailMessage);

            
            }catch(Exception e)
            {
                Console.Out.Write(e);
            }
            return View("Contacto");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
