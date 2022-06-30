using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_DAVIVIENDA_TEST.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string PrecioActual { get; set; }
        public int Stock { get; set; }
        public string Proveedor { get; set; }
    }
}
