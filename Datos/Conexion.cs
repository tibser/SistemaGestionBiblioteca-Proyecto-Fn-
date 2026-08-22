using Microsoft.Data.SqlClient;

namespace SistemaGestionBiblioteca_Proyecto_Final_
{
	internal class Conexion
	{
		internal SqlConnection ObtenerConexion()
		{
			string cadena = "Server=localhost;Database=gestion biblioteca proyecto final;Trusted_Connection=True;TrustServerCertificate=True;";

			return new SqlConnection(cadena);
		}

		internal bool ProbarConexion()
		{
			try
			{
				SqlConnection conexion = ObtenerConexion();
				conexion.Open();
				conexion.Close();

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}