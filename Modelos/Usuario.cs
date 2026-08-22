using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace SistemaGestionBiblioteca_Proyecto_Final_.Modelos
{
	public class Usuario : Persona
	{
		public string Telefono { get; set; }

		public Usuario(int id, string nombre, string apellido, string telefono)
			: base(id, nombre, apellido)
		{
			Telefono = telefono;
		}

		public override string ObtenerInformacion()
		{
			return $"Usuario: {Nombre} {Apellido} - Teléfono: {Telefono}";
		}
	}
}