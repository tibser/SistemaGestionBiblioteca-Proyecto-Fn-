using Microsoft.Data.SqlClient;

namespace SistemaGestionBiblioteca_Proyecto_Final_
{
	internal class PrestamoDatos
	{
		internal bool Agregar(Prestamo prestamo)
		{
			try
			{
				Conexion conexion = new Conexion();

				using (SqlConnection cn = conexion.ObtenerConexion())
				{
					cn.Open();

					string sql = @"INSERT INTO Prestamos
					(Id, LibroId, UsuarioId, FechaPrestamo, FechaDevolucion, Devuelto)
					VALUES
					(@Id, @LibroId, @UsuarioId, @FechaPrestamo, @FechaDevolucion, @Devuelto)";

					using (SqlCommand comando = new SqlCommand(sql, cn))
					{
						comando.Parameters.AddWithValue("@Id", prestamo.Id);
						comando.Parameters.AddWithValue("@LibroId", prestamo.LibroId);
						comando.Parameters.AddWithValue("@UsuarioId", prestamo.UsuarioId);
						comando.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo);
						comando.Parameters.AddWithValue("@FechaDevolucion",
							(object)prestamo.FechaDevolucion ?? DBNull.Value);
						comando.Parameters.AddWithValue("@Devuelto", prestamo.Devuelto);

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