using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Descripción breve de librosPorAutor
/// </summary>
public class librosPorAutor
{
    private int idlibro;

    public int idLibro
    {
        get { return idlibro; }
        set { idlibro = value; }
    }

    private string titulo;

    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }
    private string nombreAutor;

    public string NombreAutor
    {
        get { return nombreAutor; }
        set { nombreAutor = value; }
    }
    private double precio;

    public double Precio
    {
        get { return precio; }
        set { precio = value; }
    }

    private string sucursal;

    public string Sucursal
    {
        get { return sucursal; }
        set { sucursal = value; }
    }

}