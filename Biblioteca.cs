using System;
using System.Collections.Generic;
using System.Linq;
using SistemaGestionBiblioteca_Proyecto_Final_.Modelos;

namespace SistemaGestionBiblioteca_Proyecto_Final_
{
	internal class Biblioteca
	{
		List<Libro> libros;
		List<Autor> autores;
		List<Usuario> usuarios;
		List<Prestamo> prestamos;

		internal Biblioteca()
		{
			libros = new List<Libro>();
			autores = new List<Autor>();
			usuarios = new List<Usuario>();
			prestamos = new List<Prestamo>();
		}

		internal Libro AgregarLibro(Libro libro)
		{
			libros.Add(libro);
			return libro;
		}

		internal Autor AgregarAutor(Autor autor)
		{
			autores.Add(autor);
			return autor;
		}

		internal Usuario AgregarUsuario(Usuario usuario)
		{
			usuarios.Add(usuario);
			return usuario;
		}

		internal Prestamo AgregarPrestamo(Prestamo prestamo)
		{
			prestamos.Add(prestamo);
			return prestamo;
		}

		internal Libro BuscarLibro(int id)
		{
			return libros.FirstOrDefault(libro => libro.Id == id);
		}

		internal List<Libro> BuscarLibro(string titulo)
		{
			return libros
				.Where(libro => libro.Titulo.ToLower().Contains(titulo.ToLower()))
				.ToList();
		}

		internal List<Libro> ListarLibros()
		{
			return libros;
		}

		internal List<Autor> ListarAutores()
		{
			return autores;
		}

		internal List<Usuario> ListarUsuarios()
		{
			return usuarios;
		}

		internal List<Prestamo> ListarPrestamos()
		{
			return prestamos;
		}

		internal bool EliminarLibro(int id)
		{
			Libro libro = BuscarLibro(id);

			if (libro == null)
			{
				return false;
			}

			libros.Remove(libro);
			return true;
		}

		internal bool ModificarLibro(
			int id,
			string nuevoTitulo,
			string nuevoAutor,
			int nuevoAnio)
		{
			Libro libro = BuscarLibro(id);

			if (libro == null)
			{
				return false;
			}

			libro.Titulo = nuevoTitulo;
			libro.Autor = nuevoAutor;
			libro.AnioPublicacion = nuevoAnio;

			return true;
		}
	}
}