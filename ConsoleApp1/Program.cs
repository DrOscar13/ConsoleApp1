namespace ConsoleApp1;
using LogicaNegocio;

    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion = "";
            Sistema sistema = Sistema.Instancia;

        while (opcion != "0")
        // se despliega el menu con las distintas opciones del 0 al 4.
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("#-----------------------#");
            Console.WriteLine("1. Listado de todos los clientes");
            Console.WriteLine("#-----------------------#");
            Console.WriteLine("2. Listado de articulos por categoria");
            Console.WriteLine("#-----------------------#");
            Console.WriteLine("3. Agregar articulo");
            Console.WriteLine("#-----------------------#");
            Console.WriteLine("4. Listar publicaciones dadas dos fechas ");
            Console.WriteLine("#-----------------------#");
            Console.WriteLine("0 - Salir");

            opcion = SolicitarInt(0, 4, "").ToString();
            switch (opcion)
            {
                case "0":
                    Console.WriteLine("Hasta luego, gracias por visitar la pagina");
                    break;
                //Se llama a la clase cliente para generar la lista de clientes.
                case "1":
                    List<Usuario> clientes = sistema.ListarClientes();
                    Console.WriteLine("Listado de Clientes:");

                    if (clientes == null || clientes.Count == 0)
                    {
                        Console.WriteLine("No hay usuarios en el sistema");
                    }
                    else
                    {
                        foreach (Usuario cliente in clientes)

                        {
                            Console.WriteLine(cliente.ToString());
                        }

                    }
                    break;
                // se lista articulos dada una categoria.
                case "2":
                    Console.WriteLine("Ingrese la categoría de los artículos a listar: ");
                    string categoria = Console.ReadLine();
                    List<Articulo> Categoria = sistema.ListarArticulosPorCategoria(categoria);
                    // la variable noHayCategoria es para generar un mensaje que diga que no hay articulos de esa categoria
                    List<Articulo> noHayCategoria = sistema.ListarArticulosPorCategoria(categoria);
                    Console.WriteLine("Listado de articulos por categoria ");

                    foreach (Articulo articulo in Categoria)
                    {
                        Console.WriteLine($"{articulo.ToString()}");
                    }

                    if (noHayCategoria == null || noHayCategoria.Count == 0)
                    {
                        Console.WriteLine("No hay articulos de esa categoria");
                    }
                    break;
                // ingreso de un nuevo articulo
                case "3":
                    bool esCorrecto = false;
                    while (!esCorrecto)
                    {
                        try
                        {
                            Console.WriteLine("Ingrese nombre articulo");
                            string nombre = Console.ReadLine();

                            Console.WriteLine("Ingrese precio del articulo");
                            string input = Console.ReadLine();
                            int precio;

                            int.TryParse(input, out precio);

                            Console.WriteLine("Ingrese una categoria");
                            string categoriaArticulo = Console.ReadLine();


                            Articulo articulo = new Articulo(
                            nombre,
                            categoriaArticulo,
                            precio
                            );
                            esCorrecto = true;
                            articulo.Validar();
                            sistema.AgregarArticulo(articulo);
                            Console.WriteLine("Se ingreso un articulo con los siguentes datos: \n" + articulo);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;



                case "4":
                    Console.WriteLine("Ingrese la fecha inicial (dd/MM/yyyy): ");
                    string ingreFechaInicial = Console.ReadLine();
                    DateTime fecha1;
                    if (!DateTime.TryParse(ingreFechaInicial, out fecha1))
                    {
                        Console.WriteLine("Fecha inicial inválida. Debe ingresar una fecha en formato válido.");

                    }
                    Console.WriteLine("Ingrese la fecha final (dd/MM/yyyy): ");
                    string ingreFechaFinal = Console.ReadLine();
                    DateTime fecha2;
                    if (!DateTime.TryParse(ingreFechaFinal, out fecha2))
                    {
                        Console.WriteLine("Fecha final inválida. Debe ingresar una fecha en formato válido.");

                    }

                    // Validar las fechas con el método ValidarFecha
                    try
                    {
                        Publicacion.ValidarFecha(fecha1, fecha2);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }

                    // Si las fechas son válidas, listamos las publicaciones en ese rango
                    List<Publicacion> publicaciones = sistema.ListarPublicacionesEntreFechas(fecha1, fecha2);
                    Console.WriteLine("Listado de publicaciones:");


                    if (publicaciones == null || publicaciones.Count == 0)
                    {
                        Console.WriteLine("No hay publicaciones en ese rango de fecha.");
                    }
                    else
                    {
                        foreach (Publicacion publicacion in publicaciones)
                        {
                            Console.WriteLine(publicacion.ToString());
                        }
                    }

                    break;

            }

                }
        }
        public static int SolicitarInt(int min, int max, string mensaje) // metodo para tranfomrar un string en int 
        {
            int respuesta = 0;
            bool esCorrecto = false;
            while (!esCorrecto)
            {
                try
                {
                    Console.WriteLine(mensaje);
                    respuesta = int.Parse(Console.ReadLine());
                    if (respuesta < min || respuesta > max)
                    {
                        Console.WriteLine("El número debe ser mayor a " + min + " y menor a " + max);
                    }
                    else
                    {
                        return respuesta;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Solo se aceptan números enteros.");
                }
            }
            return 0;
        }
    }

