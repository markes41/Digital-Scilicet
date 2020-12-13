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
    public class CursoController : Controller
    {
        private readonly ILogger<CursoController> _logger;
        private readonly CursosContext db;

        public CursoController(ILogger<CursoController> logger, CursosContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Cursos()
        {
            return View(db.Cursos.ToList());
        } 

        public IActionResult NuevoCurso()
        {
            Usuario usuario = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            
            if(usuario != null)
            {
                if(usuario.Rol.Equals("Administrador") && usuario.Rol != null)
                {   
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
        } 
        
        public IActionResult ConsultarCurso(long ID)
        {
            Usuario usuario = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            if(usuario != null)
            {
                if(usuario.Rol.Equals("Administrador") && usuario.Rol != null)
                {   
                    Curso curso = db.Cursos.FirstOrDefault(c => c.ID == ID);
                    return Json(curso);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public IActionResult CrearCurso(string nombre, string descripcion, double precio, int categoria, string url, string idioma, string subtitulos, int cantidad, string autor)
        {
            Usuario usuario = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            Curso curso = db.Cursos.FirstOrDefault(c => c.Titulo == nombre || c.Url == url);
            if(usuario != null)
            {
                if(usuario.Rol.Equals("Administrador"))
                {
                    
                    if(curso == null)
                    {
                        Curso nuevoCurso = new Curso
                        {
                            Titulo = nombre,
                            Descripcion = descripcion,
                            Precio = precio,
                            Categoria = categoria,
                            Url = url,
                            Idioma = idioma,
                            Subtitulos = subtitulos,
                            CantidadVideos = cantidad,
                            Autor = autor
                        };
                        db.Cursos.Add(nuevoCurso);
                        db.SaveChanges();

                        return View("NuevoCurso");
                    }
                    else
                    {
                        ViewBag.existeCurso = true;
                        return View("NuevoCurso");
                    }

                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
                }
            else
            {
                ViewBag.autorizado = true;
                return RedirectToAction("Index", "Home");
            }
            

        }
        public IActionResult CursoInformacion(int ID)
        {
            Curso curso = db.Cursos.FirstOrDefault(c => c.ID == ID);
            return View(curso);
        }
        public IActionResult ComprarCurso(int ID)
        {
            Curso curso = db.Cursos.Include(c => c.Owner).FirstOrDefault(c => c.ID == ID);
            Usuario usuario = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            
            if(usuario != null)
            {  
                usuario = db.Usuarios.Include(u => u.Cursos).FirstOrDefault(u => u.Mail.Equals(usuario.Mail));          
                var tieneCurso = false;
                for(int i = 0; i < curso.Owner.Count; i++)
                {
                    if(curso.Owner.ElementAt(i) == usuario)
                    {
                        tieneCurso = true;
                        break;
                    }
                }

                
                if(tieneCurso == false)
                {
                    if(curso != null && usuario != null)

                    {
                        curso.Owner.Add(usuario);
                        db.Cursos.Update(curso);
                        db.SaveChanges();
                        ViewBag.comproCurso = true;
                        return View("Cursos", db.Cursos.ToList());
                    }
                    else
                    {
                        return RedirectToAction("Login", "Home");
                    }
                }
                else
                {
                    ViewBag.tieneCurso = true;
                    return View("Cursos", db.Cursos.ToList());
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }
        public IActionResult MisCursos()
        {   
            Usuario usuario = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            

            if(usuario != null)
            {
                Usuario user = db.Usuarios.Include(u => u.Cursos).FirstOrDefault(u => u.Mail.Equals(usuario.Mail));
                return View(user.Cursos.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }
        public IActionResult VerCurso(long ID)
        {
            Curso curso = db.Cursos.Include(c => c.Owner).FirstOrDefault(c => c.ID == ID);
            Usuario usuario = HttpContext.Session.Get<Usuario>("UsuarioLogueado");

            if(usuario != null)
            {
                if(curso != null)
                {
                    usuario = db.Usuarios.Include(u => u.Cursos).FirstOrDefault(u => u.Mail.Equals(usuario.Mail));          
                    var tieneCurso = false;
                    for(int i = 0; i < curso.Owner.Count; i++)
                    {
                        if(curso.Owner.ElementAt(i) == usuario)
                        {
                            tieneCurso = true;
                            break;
                        }
                    }

                    if(tieneCurso)
                    {
                        return View(curso);
                    }
                    else
                    {
                        return View("MisCursos", usuario.Cursos.ToList());
                    }
                }
                else
                {
                    return View("MisCursos", usuario.Cursos.ToList());
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        public JsonResult TestUser()
        {
            Usuario usuario = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            return Json(usuario);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
