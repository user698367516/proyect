using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacientesFinal
{
    class Paciente
    {
        public string Nombre;
        public int Edad;
        public string Diagnostico;
        public int Prioridad;
    }

    class Program
    {
        static Paciente[] pacientes = new Paciente[100];
        static int cantidad = 0;

        static void Main()
        {
            int opcion = 0;

            do
            {
                Console.WriteLine("======= MENÚ =======");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Mostrar pacientes");
                Console.WriteLine("3. Ordenar por prioridad");
                Console.WriteLine("4. Buscar paciente por nombre");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                string textoOpcion = Console.ReadLine();

                if (textoOpcion != "")
                {
                    opcion = int.Parse(textoOpcion);

                    switch (opcion)
                    {
                        case 1:
                            RegistrarPaciente();
                            break;
                        case 2:
                            MostrarPacientes();
                            break;
                        case 3:
                            OrdenarPorPrioridad();
                            break;
                        case 4:
                            BuscarPorNombre();
                            break;
                        case 5:
                            Console.WriteLine(" Saliendo...");
                            break;
                        default:
                            Console.WriteLine(" Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(" Ingrese una opción.");
                }

            } while (opcion != 5);
        }

        static void RegistrarPaciente()
        {
            if (cantidad >= 100)
            {
                Console.WriteLine("Límite de pacientes alcanzado.");
                return;
            }

            Paciente p = new Paciente();

            Console.Write("Nombre: ");
            p.Nombre = Console.ReadLine();

            // Lee la edad como entero válido
            int edad = -1;
            while (edad <= 0)
            {
                Console.Write("Edad (mayor a 0): ");
                string textoEdad = Console.ReadLine();

                if (textoEdad != "")
                {
                    edad = int.Parse(textoEdad);

                    if (edad <= 0)
                        Console.WriteLine("❌ Edad debe ser mayor que 0.");
                }
                else
                {
                    Console.WriteLine("❌ No puede estar vacío.");
                }
            }
            p.Edad = edad;

            Console.Write("Diagnóstico: ");
            p.Diagnostico = Console.ReadLine();

            // Leer la prioridad válida
            int prioridad = 0;
            while (prioridad < 1 || prioridad > 3)
            {
                Console.Write("Prioridad (1 = Alta, 2 = Media, 3 = Baja): ");
                string textoPrioridad = Console.ReadLine();

                if (textoPrioridad != "")
                {
                    prioridad = int.Parse(textoPrioridad);

                    if (prioridad < 1 || prioridad > 3)
                        Console.WriteLine("Prioridad inválida. Use 1, 2 o 3.");
                }
                else
                {
                    Console.WriteLine("No puede estar vacío.");
                }
            }
            p.Prioridad = prioridad;

            pacientes[cantidad] = p;
            cantidad++;

            Console.WriteLine("Paciente registrado correctamente.");
        }

        static void MostrarPacientes()
        {
            if (cantidad == 0)
            {
                Console.WriteLine("- No hay pacientes -.");
                return;
            }

            Console.WriteLine("--- LISTA DE PACIENTES ---");

            for (int i = 0; i < cantidad; i++)
            {
                Paciente p = pacientes[i];
                string prioridadTexto = "";

                if (p.Prioridad == 1) prioridadTexto = "Alta";
                else if (p.Prioridad == 2) prioridadTexto = "Media";
                else if (p.Prioridad == 3) prioridadTexto = "Baja";

                Console.WriteLine($"{i + 1}. {p.Nombre} | Edad: {p.Edad} | Diagnóstico: {p.Diagnostico} | Prioridad: {prioridadTexto}");
            }
        }

        static void OrdenarPorPrioridad()
        {
            for (int i = 0; i < cantidad - 1; i++)
            {
                for (int j = 0; j < cantidad - i - 1; j++)
                {
                    if (pacientes[j].Prioridad > pacientes[j + 1].Prioridad)
                    {
                        Paciente temp = pacientes[j];
                        pacientes[j] = pacientes[j + 1];
                        pacientes[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Pacientes ordenados por prioridad (1 primero).");
        }

        static void BuscarPorNombre()
        {
            Console.Write("Ingrese el nombre a buscar: ");
            string nombreBuscado = Console.ReadLine().ToLower();

            bool encontrado = false;

            for (int i = 0; i < cantidad; i++)
            {
                if (pacientes[i].Nombre.ToLower().Contains(nombreBuscado))
                {
                    Paciente p = pacientes[i];
                    string prioridadTexto = p.Prioridad == 1 ? "Alta" : (p.Prioridad == 2 ? "Media" : "Baja");

                    Console.WriteLine($"{i + 1}. {p.Nombre} | Edad: {p.Edad} | Diagnóstico: {p.Diagnostico} | Prioridad: {prioridadTexto}");
                    encontrado = true;
                }
            }

            if (!encontrado)
                Console.WriteLine("No se encontraron pacientes con ese nombre.");
        }
    }
}
