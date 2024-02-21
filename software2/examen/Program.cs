using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Cliente> clientes = new List<Cliente>();
        List<Libro> libros = new List<Libro>();

        while (true)
        {
            Console.WriteLine("1. Registrar venta");
            Console.WriteLine("2. Mostrar ventas");
            Console.WriteLine("3. Salir");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarVenta(clientes, libros);
                    break;
                case 2:
                    MostrarVentas(clientes, libros);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }

    static void RegistrarVenta(List<Cliente> clientes, List<Libro> libros)
    {
        Console.WriteLine("Ingrese el nombre del cliente:");
        string nombreCliente = Console.ReadLine();

        Console.WriteLine("Ingrese el género del cliente:");
        string generoCliente = Console.ReadLine();

        Cliente cliente = new Cliente(nombreCliente, generoCliente);
        clientes.Add(cliente);

        Console.WriteLine("Ingrese el título del libro:");
        string tituloLibro = Console.ReadLine();

        Console.WriteLine("Seleccione el tipo de libro:");
        Console.WriteLine("1. Ficción");
        Console.WriteLine("2. Novelas");
        Console.WriteLine("3. Cuentos");
        Console.WriteLine("4. Física Cuántica");

        int tipoLibro = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese la cantidad de libros vendidos:");
        int cantidadLibros = Convert.ToInt32(Console.ReadLine());

        double precioLibro = ObtenerPrecioLibro(tipoLibro);
        double importeBruto = cantidadLibros * precioLibro;
        double porcentajeDescuento = ObtenerPorcentajeDescuento(cantidadLibros, tipoLibro);
        double montoDescuento = importeBruto * (porcentajeDescuento / 100);
        double importeNeto = importeBruto - montoDescuento;

        Libro libro = new Libro(tituloLibro, tipoLibro, cantidadLibros, precioLibro, importeBruto, porcentajeDescuento, montoDescuento, importeNeto);
        libros.Add(libro);

        Console.WriteLine("Venta registrada exitosamente.");
    }

    static void MostrarVentas(List<Cliente> clientes, List<Libro> libros)
    {
        Console.WriteLine("Ventas realizadas:");

        for (int i = 0; i < libros.Count; i++)
        {
            Console.WriteLine($"Cliente: {clientes[i].Nombre}, Libro: {libros[i].Titulo}, Importe Neto: {libros[i].ImporteNeto:C}");
        }
    }

    static double ObtenerPrecioLibro(int tipoLibro)
    {
        switch (tipoLibro)
        {
            case 1:
                return 90.00;
            case 2:
                return 100.00;
            case 3:
                return 80.00;
            case 4:
                return 150.00;
            default:
                return 0.00;
        }
    }

    static double ObtenerPorcentajeDescuento(int cantidadLibros, int tipoLibro)
    {
        if (cantidadLibros >= 1 && cantidadLibros <= 2)
        {
            switch (tipoLibro)
            {
                case 1:
                    return 5;
                case 2:
                    return 8;
                case 3:
                    return 9;
                case 4:
                    return 2;
                default:
                    return 0;
            }
        }
        else if (cantidadLibros >= 3 && cantidadLibros <= 6)
        {
            switch (tipoLibro)
            {
                case 1:
                    return 6;
                case 2:
                    return 16;
                case 3:
                    return 18;
                case 4:
                    return 2;
                default:
                    return 0;
            }
        }
        else if (cantidadLibros > 6)
        {
            switch (tipoLibro)
            {
                case 1:
                    return 8;
                case 2:
                    return 32;
                case 3:
                    return 36;
                case 4:
                    return 4;
                default:
                    return 0;
            }
        }
        else
        {
            return 0;
        }
    }
}

class Cliente
{
    public string Nombre { get; set; }
    public string Genero { get; set; }

    public Cliente(string nombre, string genero)
    {
        Nombre = nombre;
        Genero = genero;
    }
}

class Libro
{
    public string Titulo { get; set; }
    public int Tipo { get; set; }
    public int Cantidad { get; set; }
    public double Precio { get; set; }
    public double ImporteBruto { get; set; }
    public double PorcentajeDescuento { get; set; }
    public double MontoDescuento { get; set; }
    public double ImporteNeto { get; set; }

    public Libro(string titulo, int tipo, int cantidad, double precio, double importeBruto, double porcentajeDescuento, double montoDescuento, double importeNeto)
    {
        Titulo = titulo;
        Tipo = tipo;
        Cantidad = cantidad;
        Precio = precio;
        ImporteBruto = importeBruto;
        PorcentajeDescuento = porcentajeDescuento;
        MontoDescuento = montoDescuento;
        ImporteNeto = importeNeto;
    }
}