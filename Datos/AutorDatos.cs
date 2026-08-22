using Microsoft.Data.SqlClient;

namespace SistemaGestionBiblioteca_Proyecto_Final_
{
	internal class AutorDatos
	{
		internal bool Agregar(Autor autor)
		{
			try
			{
				Conexion conexion = new Conexion();

				using (SqlConnection cn = conexion.ObtenerConexion())
				{
					cn.Open();

					string sql = "INSERT INTO Autores (Id, Nombre, Nacionalidad) " +
								 "VALUES (@Id, @Nombre, @Nacionalidad)";

					using (SqlCommand comando = new SqlCommand(sql, cn))
					{
						comando.Parameters.AddWithValue("@Id", autor.Id);
						comando.Parameters.AddWithValue("@Nombre", autor.Nombre);
						comando.Parameters.AddWithValue("@Nacionalidad", autor.Nacionalidad);

						comando.ExecuteNonQuery();
					}
				}

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}