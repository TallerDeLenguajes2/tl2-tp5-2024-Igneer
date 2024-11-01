using Microsoft.Data.Sqlite;

public class ProductosRepository
{
    string connectionString = "Data Source=Tienda.db;Cache=Shared";
    public List<Producto> listarProductosExistentes()
    {
        
        List<Producto> productos = new List<Producto>();
        string queryString = @"SELECT * FROM Productos";
        
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            SqliteCommand command = new SqliteCommand(queryString, connection);
            
            connection.Open();
            using(SqliteDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    Producto p = new Producto();
                    p.IdProducto = Convert.ToInt32(reader["idProducto"]); //en vez de poner 0, 1, etc conviene poner el nombre del atributo y todo se tiene que convertir
                    p.Descripcion = reader["Descripcion"].ToString();
                    p.Precio = Convert.ToInt32(reader["Precio"]);

                    productos.Add(p);
                }
            }
            connection.Close();

        }

        return productos;
    }   
}