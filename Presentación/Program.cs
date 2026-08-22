using SistemaGestionBiblioteca_Proyecto_Final_;
using SistemaGestionBiblioteca_Proyecto_Final_.Modelos;


Biblioteca biblioteca = new Biblioteca();

Conexion conexion = new Conexion();

if (conexion.ProbarConexion())
{
	Console.WriteLine("Conexión exitosa a la base de datos.");
}
else
{
	Console.WriteLine("No se pudo conectar a la base de datos.");
}

Console.ReadKey();


int opcion = 0;

while (opcion != 9)
{

	Console.Clear();

	Console.WriteLine("======================================");
	Console.WriteLine("     SISTEMA DE GESTIÓN DE BIBLIOTECA");
	Console.WriteLine("======================================");
	Console.WriteLine("1. Registrar libro");
	Console.WriteLine("2. Registrar autor");
	Console.WriteLine("3. Registrar usuario");
	Console.WriteLine("4. Registrar préstamo");
	Console.WriteLine("5. Listar libros");
	Console.WriteLine("6. Buscar libro");
	Console.WriteLine("7. Modificar libro");
	Console.WriteLine("8. Eliminar libro");
	Console.WriteLine("9. Salir");
	Console.WriteLine("======================================");
	Console.Write("Seleccione una opción: ");

	string entrada = Console.ReadLine();

	if (!int.TryParse(entrada, out opcion))
	{
		Console.WriteLine();
		Console.WriteLine("Opción inválida. Debe introducir un número.");
		Console.WriteLine("Presione una tecla para continuar...");
		Console.ReadKey();
		continue;
	}

	switch (opcion)
	{
		case 1:

			Console.Clear();

			Console.WriteLine("===== REGISTRAR LIBRO =====");

			Console.Write("Ingrese el ID del libro: ");
			int idLibro;

			while (!int.TryParse(Console.ReadLine(), out idLibro))
			{
				Console.Write("ID inválido. Ingrese un número: ");
			}

			Console.Write("Ingrese el título: ");
			string titulo = Console.ReadLine();

			Console.Write("Ingrese el autor: ");
			string autor = Console.ReadLine();

			Console.Write("Ingrese el año de publicación: ");
			int anio;

			while (!int.TryParse(Console.ReadLine(), out anio))
			{
				Console.Write("Año inválido. Ingrese un número: ");
			}

			Libro libro = new Libro(
				idLibro,
				titulo,
				autor,
				anio
			);

			biblioteca.AgregarLibro(libro);

			LibroDatos libroDatos = new LibroDatos();

			if (libroDatos.AgregarLibro(libro))
			{
				Console.WriteLine();
				Console.WriteLine("Libro registrado correctamente en la base de datos.");
			}
			else
			{
				Console.WriteLine();
				Console.WriteLine("No se pudo registrar el libro en la base de datos.");
			}



			Console.WriteLine();
			Console.WriteLine("Presione una tecla para continuar...");
			Console.ReadKey();

			break;






		case 2:

			Console.Clear();

			Console.WriteLine("===== REGISTRAR AUTOR =====");

			Console.Write("Ingrese el ID del autor: ");
			int idAutor;

			while (!int.TryParse(Console.ReadLine(), out idAutor))
			{
				Console.Write("ID inválido. Ingrese un número: ");
			}

			Console.Write("Ingrese el nombre del autor: ");
			string nombre = Console.ReadLine();

			Console.Write("Ingrese la nacionalidad: ");
			string nacionalidad = Console.ReadLine();

			Autor nuevoAutor = new Autor(
				idAutor,
				nombre,
				nacionalidad
			);

			biblioteca.AgregarAutor(nuevoAutor);

			if (new AutorDatos().Agregar(nuevoAutor))
				Console.WriteLine("Autor registrado en la base de datos.");
			else
				Console.WriteLine("No se pudo registrar el autor.");


			Console.WriteLine();
			Console.WriteLine("Autor registrado correctamente.");
			Console.WriteLine();
			Console.WriteLine("Presione una tecla para continuar...");
			Console.ReadKey();

			break;




		case 3:

			Console.Clear();

			Console.WriteLine("===== REGISTRAR USUARIO =====");

			Console.Write("Ingrese el ID del usuario: ");
			int idUsuario;

			while (!int.TryParse(Console.ReadLine(), out idUsuario))
			{
				Console.Write("ID inválido. Ingrese un número: ");
			}

			Console.Write("Ingrese el nombre: ");
			string nombreUsuario = Console.ReadLine();

			Console.Write("Ingrese el apellido: ");
			string apellidoUsuario = Console.ReadLine();

			Console.Write("Ingrese el teléfono: ");
			string telefono = Console.ReadLine();

			Usuario nuevoUsuario = new Usuario(
				idUsuario,
				nombreUsuario,
				apellidoUsuario,
				telefono
			);

			if (new UsuarioDatos().Agregar(nuevoUsuario))
				Console.WriteLine("Usuario registrado correctamente.");
			else
				Console.WriteLine("No se pudo registrar el usuario.");

			Console.WriteLine();
			Console.WriteLine("Usuario registrado correctamente.");
			Console.WriteLine();
			Console.WriteLine("Presione una tecla para continuar...");
			Console.ReadKey();

			break;



		case 4:

			Console.Clear();

			Console.WriteLine("===== REGISTRAR PRÉSTAMO =====");

			Console.Write("Ingrese el ID del préstamo: ");
			int idPrestamo;

			while (!int.TryParse(Console.ReadLine(), out idPrestamo))
			{
				Console.Write("ID inválido. Ingrese un número: ");
			}

			Console.Write("Ingrese el ID del libro: ");
			int idLibroPrestamo;

			while (!int.TryParse(Console.ReadLine(), out idLibroPrestamo))
			{
				Console.Write("ID inválido. Ingrese un número: ");
			}

			Libro libroPrestamo = biblioteca.BuscarLibro(idLibroPrestamo);

			if (libroPrestamo == null)
			{
				Console.WriteLine();
				Console.WriteLine("El libro no existe.");
				Console.WriteLine("Presione una tecla para continuar...");
				Console.ReadKey();
				break;
			}

			if (!libroPrestamo.Disponible)
			{
				Console.WriteLine();
				Console.WriteLine("El libro no está disponible.");
				Console.WriteLine("Presione una tecla para continuar...");
				Console.ReadKey();
				break;
			}

			Console.Write("Ingrese el ID del usuario: ");
			int idUsuarioPrestamo;

			while (!int.TryParse(Console.ReadLine(), out idUsuarioPrestamo))
			{
				Console.Write("ID inválido. Ingrese un número: ");
			}

			Usuario usuarioPrestamo = null;

			foreach (Usuario usuario in biblioteca.ListarUsuarios())
			{
				if (usuario.Id == idUsuarioPrestamo)
				{
					usuarioPrestamo = usuario;
					break;
				}
			}

			if (usuarioPrestamo == null)
			{
				Console.WriteLine();
				Console.WriteLine("El usuario no existe.");
				Console.WriteLine("Presione una tecla para continuar...");
				Console.ReadKey();
				break;
			}

			Prestamo nuevoPrestamo = new Prestamo(
				idPrestamo,
				idLibroPrestamo,
				idUsuarioPrestamo
			);

		
			if (new PrestamoDatos().Agregar(nuevoPrestamo))
				Console.WriteLine("Préstamo guardado en la base de datos.");
			else
				Console.WriteLine("No se pudo guardar el préstamo.");



			libroPrestamo.Disponible = false;
			new LibroDatos().ActualizarDisponibilidad(idLibroPrestamo, false);


			Console.WriteLine();
			Console.WriteLine("Préstamo registrado correctamente.");
			Console.WriteLine("El libro ahora aparece como no disponible.");
			Console.WriteLine();
			Console.WriteLine("Presione una tecla para continuar...");
			Console.ReadKey();

			break;


		case 5:

			Console.Clear();

			Console.WriteLine("===== LISTA DE LIBROS =====");
			Console.WriteLine();

			List<Libro> listaLibros = new LibroDatos().ListarLibros();


			if (listaLibros.Count == 0)
			{
				Console.WriteLine("No hay libros registrados.");
			}
			else
			{
				foreach (Libro libroRegistrado in listaLibros)
				{
					Console.WriteLine("------------------------------");
					Console.WriteLine("ID: " + libroRegistrado.Id);
					Console.WriteLine("Título: " + libroRegistrado.Titulo);
					Console.WriteLine("Autor: " + libroRegistrado.Autor);
					Console.WriteLine("Año: " + libroRegistrado.AnioPublicacion);
					Console.WriteLine("Disponible: " +
						(libroRegistrado.Disponible ? "Sí" : "No"));
				}

				Console.WriteLine("------------------------------");
			}

			Console.WriteLine();
			Console.WriteLine("Presione una tecla para continuar...");
			Console.ReadKey();

			break;





		case 6:

			Console.Clear();

			Console.WriteLine("===== BUSCAR LIBRO =====");
			Console.WriteLine("1. Buscar por ID");
			Console.WriteLine("2. Buscar por título");
			Console.WriteLine();

			Console.Write("Seleccione una opción: ");
			int tipoBusqueda;

			while (!int.TryParse(Console.ReadLine(), out tipoBusqueda))
			{
				Console.Write("Opción inválida. Ingrese 1 o 2: ");
			}

			if (tipoBusqueda == 1)
			{
				Console.Write("Ingrese el ID del libro: ");
				int idBusqueda;

				while (!int.TryParse(Console.ReadLine(), out idBusqueda))
				{
					Console.Write("ID inválido. Ingrese un número: ");
				}

				Libro libroEncontrado = new LibroDatos().BuscarLibroPorId(idBusqueda);

				if (libroEncontrado == null)
				{
					Console.WriteLine();
					Console.WriteLine("No se encontró ningún libro con ese ID.");
				}
				else
				{
					Console.WriteLine();
					Console.WriteLine("===== LIBRO ENCONTRADO =====");
					Console.WriteLine("ID: " + libroEncontrado.Id);
					Console.WriteLine("Título: " + libroEncontrado.Titulo);
					Console.WriteLine("Autor: " + libroEncontrado.Autor);
					Console.WriteLine("Año: " + libroEncontrado.AnioPublicacion);
					Console.WriteLine("Disponible: " +
						(libroEncontrado.Disponible ? "Sí" : "No"));
				}
			}
			else if (tipoBusqueda == 2)
			{
				Console.Write("Ingrese el título del libro: ");
				string tituloBusqueda = Console.ReadLine();

				List<Libro> librosEncontrados =
	             new LibroDatos().BuscarLibrosPorTitulo(tituloBusqueda);


				if (librosEncontrados.Count == 0)
				{
					Console.WriteLine();
					Console.WriteLine("No se encontraron libros con ese título.");
				}
				else
				{
					Console.WriteLine();
					Console.WriteLine("===== LIBROS ENCONTRADOS =====");

					foreach (Libro libroEncontrado in librosEncontrados)
					{
						Console.WriteLine("------------------------------");
						Console.WriteLine("ID: " + libroEncontrado.Id);
						Console.WriteLine("Título: " + libroEncontrado.Titulo);
						Console.WriteLine("Autor: " + libroEncontrado.Autor);
						Console.WriteLine("Año: " + libroEncontrado.AnioPublicacion);
						Console.WriteLine("Disponible: " +
							(libroEncontrado.Disponible ? "Sí" : "No"));
					}
				}
			}
			else
			{
				Console.WriteLine();
				Console.WriteLine("La opción de búsqueda no existe.");
			}

			Console.WriteLine();
			Console.WriteLine("Presione una tecla para continuar...");
			Console.ReadKey();

			break;



		case 7:

			Console.Clear();
			Console.WriteLine("===== MODIFICAR LIBRO =====");

			Console.Write("ID del libro: ");
			int id = int.Parse(Console.ReadLine());

			Console.Write("Nuevo título: ");
			string tituloNuevo = Console.ReadLine();

			Console.Write("Nuevo autor: ");
			string autorNuevo = Console.ReadLine();

			Console.Write("Nuevo año: ");
			int anioNuevo = int.Parse(Console.ReadLine());

			Libro libroModificado = new Libro(
				id,
				tituloNuevo,
				autorNuevo,
				anioNuevo
			);

			if (new LibroDatos().ModificarLibro(libroModificado))
				Console.WriteLine("Libro modificado correctamente.");
			else
				Console.WriteLine("Libro no encontrado.");

			Console.ReadKey();
			break;




		case 8:

			Console.Clear();
			Console.WriteLine("===== ELIMINAR LIBRO =====");

			Console.Write("ID del libro: ");
			int idEliminar = int.Parse(Console.ReadLine());

			if (new LibroDatos().EliminarLibro(idEliminar))
				Console.WriteLine("Libro eliminado correctamente.");
			else
				Console.WriteLine("Libro no encontrado.");

			Console.ReadKey();
			break;




		default:
			Console.WriteLine();
			Console.WriteLine("La opción seleccionada no existe.");
			Console.WriteLine("Presione una tecla para continuar...");
			Console.ReadKey();
			break;
	}
}



