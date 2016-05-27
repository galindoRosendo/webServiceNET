using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using MySql.Data.MySqlClient;
using System.Xml;
using System.IO;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string[] HelloWorld() {
        List<string> milista = new List<string>();
        milista.Add("uno");
        milista.Add("dos");
        milista.Add("tres");
        milista.Add("cuatro");


        return milista.ToArray();
    }



    [WebMethod]
    public List<librosPorAutor> autores(string nombre)
    {
        List<librosPorAutor> lista = new List<librosPorAutor>();

        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=libreriaguadalajara;Uid=root;Pwd=passw0rd;");
        
        string query = "select l.id_libro, l.titulo, a.nombre as nombre_autor,l.precio,l.sucursal "+
                        "from libros l join autores a on (l.id_autor=a.id_autor) "+
                        "where a.nombre='"+nombre+"'";
        MySqlCommand command = new MySqlCommand(query,conn);
        conn.Open();

        MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                librosPorAutor autor = new librosPorAutor();
                autor.idLibro = reader.GetInt32(0);
                autor.Titulo = reader.GetString(1);
                autor.NombreAutor = reader.GetString(2);
                autor.Precio = reader.GetDouble(3);
                autor.Sucursal = reader.GetString(4);
                lista.Add(autor);

            }
         conn.Close();

         //MySqlConnection connmeme = new MySqlConnection("Server=192.168.1.101;port=3306;Database=librerialaredo;Uid=meme;Pwd=Mendoza27;");

         //MySqlCommand commandmeme = new MySqlCommand(query, connmeme);
         //connmeme.Open();

         //reader = commandmeme.ExecuteReader();
         //while (reader.Read())
         //{
         //    librosPorAutor autor = new librosPorAutor();
         //    autor.idLibro = reader.GetInt32(0);
         //    autor.Titulo = reader.GetString(1);
         //    autor.NombreAutor = reader.GetString(2);
         //    autor.Precio = reader.GetDouble(3);
         //    autor.Sucursal = reader.GetString(4);
         //    lista.Add(autor);

         //}
         //connmeme.Close();

         //MySqlConnection connisa = new MySqlConnection("Server=192.168.103;Database=libreriaMty;Uid=danni;Pwd=Passw0rd;");

         //MySqlCommand commandisa = new MySqlCommand(query, connisa);
         //connisa.Open();

         //reader = commandisa.ExecuteReader();
         //while (reader.Read())
         //{
         //    librosPorAutor autor = new librosPorAutor();
         //    autor.idLibro = reader.GetInt32(0);
         //    autor.Titulo = reader.GetString(1);
         //    autor.NombreAutor = reader.GetString(2);
         //    autor.Precio = reader.GetDouble(3);
         //    autor.Sucursal = reader.GetString(4);
         //    lista.Add(autor);

         //}
         //connisa.Close();


        return lista;
    }
    
}