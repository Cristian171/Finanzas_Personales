using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class Program
    {
        static List<Gasto> gastos = new List<Gasto>();
        static Gasto[] gastosVector = new Gasto[100];
        static NotificadorDeGastos notificador = new NotificadorDeGastos();
        static decimal ingresoMensual = 1000000; // Ingreso mensual predeterminado

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("Ingrese una opción:");
                Console.WriteLine("1. Agregar gasto");
                Console.WriteLine("2. Ver gastos de hoy");
                Console.WriteLine("3. Ver gastos de ayer");
                Console.WriteLine("4. Ver todos los gastos");
                Console.WriteLine("5. Ver dinero restante");
                Console.WriteLine("6. Salir");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarGasto();
                        break;
                    case "2":
                        VerGastos(DateTime.Today);
                        break;
                    case "3":
                        VerGastos(DateTime.Today.AddDays(-1));
                        break;
                    case "4":
                        VerTodosLosGastos();
                        break;
                    case "5":
                        VerDineroRestante();
                        break;
                    case "6":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AgregarGasto()
        {
            Console.WriteLine("Ingrese el monto del gasto:");
            decimal monto = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Ingrese la descripción del gasto:");
            string descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el tipo de pago (Efectivo o Tarjeta):");
            string tipoPago = Console.ReadLine();

            Gasto nuevoGasto = new Gasto(DateTime.Now, tipoPago, monto, descripcion);

            for (int i = 0; i < gastosVector.Length; i++)
            {
                if (gastosVector[i] == null)
                {
                    gastosVector[i] = nuevoGasto;
                    Console.WriteLine("Gasto agregado correctamente");

                    // Deducción del gasto del ingreso mensual
                    ingresoMensual -= monto;
                  
                }
            }
        }

        static void VerGastos(DateTime fecha)
        {
            Console.WriteLine($"Gastos del {fecha.ToString("dd/MM/yyyy")}:");
            foreach (var gasto in gastosVector)
            {
                if (gasto != null && gasto.Fecha.Date == fecha.Date)
                {
                    Console.WriteLine($"- {gasto.TipoPago}: ${gasto.Monto} - {gasto.Descripcion}");
                }
            }
        }

        static void VerTodosLosGastos()
        {
            Console.WriteLine("Todos los gastos:");
            foreach (var gasto in gastosVector)
            {
                if (gasto != null)
                {
                    Console.WriteLine($"- {gasto.Fecha.ToString("dd/MM/yyyy HH:mm")} - {gasto.TipoPago}: ${gasto.Monto} - {gasto.Descripcion}");
                }
            }
        }

        static void VerDineroRestante()
        {
            Console.WriteLine($"Dinero restante del ingreso mensual: ${ingresoMensual}");
        }

        static decimal CalcularPorcentajeGasto()
        {
            decimal totalGastos = gastosVector.Where(g => g != null).Sum(g => g.Monto);
            decimal porcentajeGasto = (totalGastos / ingresoMensual) * 100;
            return porcentajeGasto;
        }


    }

}




