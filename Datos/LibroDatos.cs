using Microsoft.Data.SqlClient;

namespace SistemaGestionBiblioteca_Proyecto_Final_
{
	internal class LibroDatos
	{
		private Conexion conexion = new Conexion();

		internal bool AgregarLibro(Libro libro)
		{
			try
			{
				using (SqlConnection cn = conexion.ObtenerConexion())
				{
					cn.Open();

					string sql = @"INSERT INTO Libros
					(Id, Titulo, Autor, AnioPublicacion, Disponible)
					VALUES
					(@Id, @Titulo, @Autor, @AnioPublicacion, @Disponible)";

					using (SqlCommand comando = new SqlCommand(sql, cn))
					{
						comando.Parameters.AddWithValue("@Id", libro.Id);
						comando.Parameters.AddWithValue("@Titulo", libro.Titulo);
						comando.Parameters.AddWithValue("@Autor", libro.Autor);
						comando.Parameters.AddWithValue("@AnioPublicacion", libro.AnioPublicacion);
						comando.Parameters.AddWithValue("@Disponible", libro.Disponible);

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

		internal List<Libro> ListarLibros()
		{
			List<Libro> libros = new List<Libro>();

			using (SqlConnection cn = conexion.ObtenerConexion())
			{
				cn.Open();

				string sql = "SELECT * FROM Libros";

				using (SqlCommand comando = new SqlCommand(sql, cn))
				using (SqlDataReader lector = comando.ExecuteReader())
				{
					while (lector.Read())
					{
						Libro libro = new Libro(
							Convert.ToInt32(lector["Id"]),
							lector["Titulo"].ToString(),
							lector["Autor"].ToString(),
							Convert.ToInt32(lector["AnioPublicacion"])
						);

						libro.Disponible = Convert.ToBoolean(lector["Disponible"]);

						libros.Add(libro);
					}
				}
			}

			return libros;
		}

		internal Libro BuscarLibroPorId(int id)
		{
			foreach (Libro libro in ListarLibros())
			{
				if (libro.Id == id)
					return libro;
			}

			return null;
		}

		internal List<Libro> BuscarLibrosPorTitulo(string titulo)
		{
			List<Libro> libros = ListarLibros();

			return libros
				.Where(l => l.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase))
				.ToList();
		}


		internal bool ModificarLibro(Libro libro)
		{
			using (SqlConnection cn = conexion.ObtenerConexion())
			{
				cn.Open();

				string sql = @"UPDATE Libros
							   SET Titulo = @Titulo,
								   Autor = @Autor,
								   AnioPublicacion = @Anio
							   WHERE Id = @Id";

				using (SqlCommand comando = new SqlCommand(sql, cn))
				{
					comando.Parameters.AddWithValue("@Id", libro.Id);
					comando.Parameters.AddWithValue("@Titulo", libro.Titulo);
					comando.Parameters.AddWithValue("@Autor", libro.Autor);
					comando.Parameters.AddWithValue("@Anio", libro.AnioPublicacion);

					return comando.ExecuteNonQuery() > 0;
				}
			}
		}

		internal bool EliminarLibro(int id)
		{
			using (SqlConnection cn = conexion.ObtenerConexion())
			{
				cn.Open();

				string sql = "DELETE FROM Libros WHERE Id = @Id";

				using (SqlCommand comando = new SqlCommand(sql, cn))
				{
					comando.Parameters.AddWithValue("@Id", id);

					return comando.ExecuteNonQuery() > 0;
				}
			}
		}

		internal void ActualizarDisponibilidad(int id, bool disponible)
		{
			using (SqlConnection cn = conexion.ObtenerConexion())
			{
				cn.Open();

				string sql = "UPDATE Libros SET Disponible = @Disponible WHERE Id = @Id";

				using (SqlCommand comando = new SqlCommand(sql, cn))
				{
					comando.Parameters.AddWithValue("@Id", id);
					comando.Parameters.AddWithValue("@Disponible", disponible);

					comando.ExecuteNonQuery();
				}
			}
		}
	}
}