using Microsoft.EntityFrameworkCore;

namespace Cursos.Models
{
    [Keyless]
    public class Contenido
    {
        public string Url { get; set; }
    }
}