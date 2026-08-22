using System;
using System.Collections.Generic;
using System.Text;


namespace SistemaGestionBiblioteca_Proyecto_Final_
{
	public class Autor
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Nacionalidad { get; set; }

		public Autor(int id, string nombre, string nacionalidad)
		{
			Id = id;
			Nombre = nombre;
			Nacionalidad = nacionalidad;
		}
	}
}