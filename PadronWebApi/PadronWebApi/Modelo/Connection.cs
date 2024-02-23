using Microsoft.Data.SqlClient;

namespace PadronWebApi.Modelo
{
    public class Connection
    {
        readonly string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=padron;Trusted_Connection=True; TrustServerCertificate=True;";

        public List<Persona> GetAll() 
        {
            List<Persona> result = new List<Persona>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string selectAll = "SELECT top 10000 DISTRITO, TX_TIPO_EJEMPLAR, NU_MATRICULA, TX_APELLIDO, TX_NOMBRE, TX_CLASE, TX_GENERO, TX_DOMICILIO, TX_SECCION, TX_CIRCUITO, TX_LOCALIDAD, TX_CODIGO_POSTAL, TX_TIPO_NACIONALIDAD, NUMERO_MESA, NU_ORDEN_MESA, ESTABLECIMIENTO, DIRECCION_ESTABLECIMIENTO FROM PADRON; ";
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = selectAll;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Persona padron = new Persona()
                        {
                            DISTRITO = reader.IsDBNull(0) ? "na" : reader.GetString(0),
                            TX_TIPO_EJEMPLAR = reader.IsDBNull(1) ? "na" : reader.GetString(1),
                            NU_MATRICULA = reader.IsDBNull(2) ? "na" : reader.GetInt32(2).ToString(),
                            TX_APELLIDO = reader.IsDBNull(3) ? "na" : reader.GetString(3),
                            TX_NOMBRE = reader.IsDBNull(4) ? "na" : reader.GetString(4),
                            TX_CLASE = reader.IsDBNull(5) ? "na" : reader.GetInt32(5).ToString(),
                            TX_GENERO = reader.IsDBNull(6) ? "na" : reader.GetString(6),
                            TX_DOMICILIO = reader.IsDBNull(7) ? "na" : reader.GetString(7),
                            TX_SECCION = reader.IsDBNull(8) ? "na" : reader.GetString(8),
                            TX_CIRCUITO = reader.IsDBNull(9) ? "na" : reader.GetString(9),
                            TX_LOCALIDAD = reader.IsDBNull(10) ? "na" : reader.GetString(10),
                            TX_CODIGO_POSTAL = reader.IsDBNull(11) ? "na" : reader.GetString(11),
                            TX_TIPO_NACIONALIDAD = reader.IsDBNull(12) ? "na" : reader.GetString(12),
                            NUMERO_MESA = reader.IsDBNull(13) ? "na" : reader.GetInt32(13).ToString(),
                            NU_ORDEN_MESA = reader.IsDBNull(14) ? "na" : reader.GetInt32(14).ToString(),
                            ESTABLECIMIENTO = reader.IsDBNull(15) ? "na" : reader.GetString(15),
                            DIRECCION_ESTABLECIMIENTO = reader.IsDBNull(16) ? "na" : reader.GetString(16)
                        };
                        result.Add(padron);
                    }
                }
            }
            catch(Exception ex) {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                // También puedes lanzar la excepción nuevamente si deseas propagarla
                throw;
            }

            return result;
        }

        public List<Persona> GetByName(string dato, int tipo)
        {
            List<Persona> result = new List<Persona>();
            string selectAll = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    switch (tipo)
                    {
                        case 0:
                            selectAll = "SELECT DISTRITO, TX_TIPO_EJEMPLAR, NU_MATRICULA, TX_APELLIDO, TX_NOMBRE, TX_CLASE, TX_GENERO, TX_DOMICILIO, TX_SECCION, TX_CIRCUITO, TX_LOCALIDAD, TX_CODIGO_POSTAL, TX_TIPO_NACIONALIDAD, NUMERO_MESA, NU_ORDEN_MESA, ESTABLECIMIENTO, DIRECCION_ESTABLECIMIENTO FROM PADRON where NU_MATRICULA = @dato; ";
                            break;
                        case 1:
                            selectAll = "SELECT DISTRITO, TX_TIPO_EJEMPLAR, NU_MATRICULA, TX_APELLIDO, TX_NOMBRE, TX_CLASE, TX_GENERO, TX_DOMICILIO, TX_SECCION, TX_CIRCUITO, TX_LOCALIDAD, TX_CODIGO_POSTAL, TX_TIPO_NACIONALIDAD, NUMERO_MESA, NU_ORDEN_MESA, ESTABLECIMIENTO, DIRECCION_ESTABLECIMIENTO FROM PADRON where TX_APELLIDO = @dato; ";
                            break;
                        case 2:
                            selectAll = "SELECT DISTRITO, TX_TIPO_EJEMPLAR, NU_MATRICULA, TX_APELLIDO, TX_NOMBRE, TX_CLASE, TX_GENERO, TX_DOMICILIO, TX_SECCION, TX_CIRCUITO, TX_LOCALIDAD, TX_CODIGO_POSTAL, TX_TIPO_NACIONALIDAD, NUMERO_MESA, NU_ORDEN_MESA, ESTABLECIMIENTO, DIRECCION_ESTABLECIMIENTO FROM PADRON where TX_NOMBRE = @dato; ";
                            break;
                    }
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();

                    cmd.Parameters.AddWithValue("dato", dato);
                    cmd.CommandText = selectAll;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Persona padron = new Persona()
                        {
                            DISTRITO = reader.IsDBNull(0) ? "na" : reader.GetString(0),
                            TX_TIPO_EJEMPLAR = reader.IsDBNull(1) ? "na" : reader.GetString(1),
                            NU_MATRICULA = reader.IsDBNull(2) ? "na" : reader.GetInt32(2).ToString(),
                            TX_APELLIDO = reader.IsDBNull(3) ? "na" : reader.GetString(3),
                            TX_NOMBRE = reader.IsDBNull(4) ? "na" : reader.GetString(4),
                            TX_CLASE = reader.IsDBNull(5) ? "na" : reader.GetInt32(5).ToString(),
                            TX_GENERO = reader.IsDBNull(6) ? "na" : reader.GetString(6),
                            TX_DOMICILIO = reader.IsDBNull(7) ? "na" : reader.GetString(7),
                            TX_SECCION = reader.IsDBNull(8) ? "na" : reader.GetString(8),
                            TX_CIRCUITO = reader.IsDBNull(9) ? "na" : reader.GetString(9),
                            TX_LOCALIDAD = reader.IsDBNull(10) ? "na" : reader.GetString(10),
                            TX_CODIGO_POSTAL = reader.IsDBNull(11) ? "na" : reader.GetString(11),
                            TX_TIPO_NACIONALIDAD = reader.IsDBNull(12) ? "na" : reader.GetString(12),
                            NUMERO_MESA = reader.IsDBNull(13) ? "na" : reader.GetInt32(13).ToString(),
                            NU_ORDEN_MESA = reader.IsDBNull(14) ? "na" : reader.GetInt32(14).ToString(),
                            ESTABLECIMIENTO = reader.IsDBNull(15) ? "na" : reader.GetString(15),
                            DIRECCION_ESTABLECIMIENTO = reader.IsDBNull(16) ? "na" : reader.GetString(16)
                        };
                        result.Add(padron);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                // También puedes lanzar la excepción nuevamente si deseas propagarla
                throw;
            }

            return result;
        }
    }
}
