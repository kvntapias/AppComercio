using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public class Usuario
    {
        public int Id { get; set; }
        public string documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string contraseña { get; set; }
        public string telefono { get; set; }
        public int puntos { get; set; }
        public byte rol { get; set; }
    }
}
