using Microsoft.Data.SqlClient;
using SistemaGestionBiblioteca_Proyecto_Final_.Modelos;

namespace SistemaGestionBiblioteca_Proyecto_Final_
{
	internal class UsuarioDatos
	{
		internal bool Agregar(Usuario usuario)
		{
			try
			{
				Conexion conexion = new Conexion();

				using (SqlConnection cn = conexion.ObtenerConexion())
				{
					cn.Open();

					string sql = @"INSERT INTO Usuarios
					(Id, Nombre, Apellido, Telefono)
					VALUES
					(@Id, @Nombre, @Apellido, @Telefono)";

					using (SqlCommand comando = new SqlCommand(sql, cn))
					{
						comando.Parameters.AddWithValue("@Id", usuario.Id);
						comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
						comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
						comando.Parameters.AddWithValue("@Telefono", usuario.Telefono);

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