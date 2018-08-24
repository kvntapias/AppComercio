using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Catalogo
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string fecha { get; set; }
        public byte estado { get; set; }
        public Catalogo()
        {
            Id = this.Id;
            nombre = this.nombre;
            fecha = DateTime.Today.ToString("MM/dd/yyyy");
        }

        public Catalogo(int v1, string v2)
        {
            this.Id = v1;
            this.nombre = v2;
        }
    }
}
