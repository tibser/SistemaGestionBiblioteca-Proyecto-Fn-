using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionBiblioteca_Proyecto_Final_
{
	public class Prestamo
	{
		public int Id { get; set; }
		public int LibroId { get; set; }
		public int UsuarioId { get; set; }
		public DateTime FechaPrestamo { get; set; }
		public DateTime? FechaDevolucion { get; set; }
		public bool Devuelto { get; set; }

		public Prestamo(int id, int libroId, int usuarioId)
		{
			Id = id;
			LibroId = libroId;
			UsuarioId = usuarioId;
			FechaPrestamo = DateTime.Now;
			FechaDevolucion = null;
			Devuelto = false;
		}
	}
}
