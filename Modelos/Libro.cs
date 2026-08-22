using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionBiblioteca_Proyecto_Final_
{
	public class Libro
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public string Autor { get; set; }
		public int AnioPublicacion { get; set; }
		public bool Disponible { get; set; }

		public Libro(int id, string titulo, string autor, int anioPublicacion)
		{
			Id = id;
			Titulo = titulo;
			Autor = autor;
			AnioPublicacion = anioPublicacion;
			Disponible = true;
		}
	}
}



