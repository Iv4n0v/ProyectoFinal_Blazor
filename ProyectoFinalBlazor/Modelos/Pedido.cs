using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Pedido
    {
        [Required(ErrorMessage = "El Campo Codigo es Obligatorio")]
        public String Codigo { get; set; }

        public String Cliente { get; set; }
        public Decimal Total { get; set; }
        [Required(ErrorMessage = "El Campo IdProducto es Obligatorio")]
        public String IdProducto { get; set; }
        public int Cantidad { get; set; }

        public String Descripcion { get; set; }
    }
}
