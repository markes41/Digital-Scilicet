using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DigitalScilicet.Models
{
    public class Usuario : IdentityUser
    {
        public List<Curso> Cursos { get; set; }
        
    }
}