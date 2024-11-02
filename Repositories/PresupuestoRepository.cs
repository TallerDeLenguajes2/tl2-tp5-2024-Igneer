using Microsoft.Data.Sqlite;

class PresupuestoRepositorySQL : IPresupuestoRepository
{
    string connectionString = "Data Source=Tienda.db;Cache=Shared";
    public void InsertPresupuesto(Presupuesto p)
    {
        string queryString = @"INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES (@nombre, @fecha)";
        
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand command = new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue("@nombre", p.NombreDestinatario);
            command.Parameters.AddWithValue("@fecha", p.FechaCreacion);

            command.ExecuteNonQuery();

            connection.Close();

        }
    }
    public List<Presupuesto> GetPresupuestos()
    {
        List<Presupuesto> presupuestos = new List<Presupuesto>();
        string queryString = @"SELECT * FROM Presupuestos";
        
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(queryString, connection);
            
            using(SqliteDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    Presupuesto p = new Presupuesto();
                    p.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]); //en vez de poner 0, 1, etc conviene poner el nombre del atributo y todo se tiene que convertir
                    p.NombreDestinatario = reader["NombreDestinatario"].ToString();
                    p.FechaCreacion = DateOnly.FromDateTime(DateTime.Parse(reader["FechaCreacion"].ToString()));
                    //ARMO CONSULTA PARA TRAER LOS PRODUCTOS
                        string queryString2 = @"SELECT * FROM Productos INNER JOIN PresupuestosDetalle USING (idProducto) WHERE idPresupuesto = @idPresupuesto";
                        SqliteCommand command2 = new SqliteCommand(queryString2, connection);
                        command2.Parameters.AddWithValue("@idPresupuesto", p.IdPresupuesto);
                        using(SqliteDataReader reader2 = command2.ExecuteReader())
                        {
                            while(reader2.Read())
                            {
                                Producto p1 = new Producto();
                                p1.IdProducto = Convert.ToInt32(reader2["idProducto"]); 
                                p1.Descripcion = reader2["Descripcion"].ToString();
                                p1.Precio = Convert.ToInt32(reader2["Precio"]);
                                p.agregarProducto(p1, Convert.ToInt32(reader2["Cantidad"]));
                            }
                        }
                    presupuestos.Add(p);
                }
            }
            connection.Close();
        }

        return presupuestos;
    }


}