using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Producto
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string imagen { get; set; }
        public int cantidad { get; set; }
        public float precio { get; set; }
        //Constructor
        public Producto(int id,string nom, string img, int cant)
        {
            this.Id = id;
            this.nombre = nom;
            this.imagen = img;
            this.cantidad = cant;
        }
        public Producto()
        {

        }
    }

}
