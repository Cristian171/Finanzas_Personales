using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas
{
    public class Gasto
    {
        public DateTime Fecha { get; set; }
        public string TipoPago { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }

        public Gasto(DateTime fecha, string tipoPago, decimal monto, string descripcion)
        {
            Fecha = fecha;
            TipoPago = tipoPago;
            Monto = monto;
            Descripcion = descripcion;
        }
    }
}
