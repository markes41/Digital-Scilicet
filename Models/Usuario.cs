using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PruebaIdentity.Models
{
    public class Usuario : IdentityUser
    {
        public List<Curso> Cursos { get; set; }
        
    }
}