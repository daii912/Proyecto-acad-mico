/*
 * Created by SharpDevelop.
 * User: daiana
 * Date: 18/05/2025
 * Time: 18:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP_CLUB
{
	class Program
	{
		static void Main(string[] args)
		{
			club miClub = new club("Union");
			Console.WriteLine("**PARA DAR DE ALTA UN NIÑO PRIMERO HAY QUE DAR DE ALTA UN ENTRENADOR Y LUEGO UN DEPORTE**");
			
			while (true)
			{
				Console.WriteLine("");
				Console.WriteLine("Elija una opción: ");
				Console.WriteLine("");
				Console.WriteLine("1- Dar de alta a un entrenador");
				Console.WriteLine("2- Dar de baja a un entrenador ");//
				Console.WriteLine("_______________________________________");
				Console.WriteLine("3– Dar de alta a un niño en un deporte "); //Validar que haya cupo usando una excepcion.
				Console.WriteLine("4- Dar de baja a un niño en un deporte");
				Console.WriteLine("_______________________________________");
				Console.WriteLine("5– Realizar el pago de una cuota ");// //sedebe aplicar el descuento si es socio y registrar el mes de pago.
				Console.WriteLine("6- Submenú de inscripción: ");
				Console.WriteLine("7- Listado de deudores ");
				Console.WriteLine("_______________________________________");
				Console.WriteLine("8- Agregar un deporte ");
				Console.WriteLine("9- Eliminar un deporte ");//No tiene que tener inscriptos.
				Console.WriteLine("10- salir del menu");
				Console.WriteLine("");
				string op = Console.ReadLine();

				switch (op)
				{
					case "1":
						altaEntrenador(miClub);
						break;

					case "2":
						bajaEntrenador(miClub);
						break;

					case "3":
						altaNino(miClub); //validar que haya cupo usando una excepcion
						break;

					case "4":
						bajaNino(miClub);
						break;

					case "5":
						pagarCuota(miClub);
						break;

					case "6":
						subMenu(miClub);
						break;

					case "7":
						listaDeudor(miClub);
						break;

					case "8":
						altaDeporte(miClub);
						break;

					case "9":
						eliminarDeporte(miClub);
						break;

					case "10":
						return;

					default:
						Console.WriteLine("Opción inválida.");
						break;
						
				}
				Console.WriteLine("");
				Console.WriteLine("Presione una tecla para continuar con el menu...");
				Console.WriteLine("");
				Console.WriteLine("*********************************************************************************************************");
				Console.ReadKey(true);
			}
		}

		static void altaEntrenador(club miClub)
		{
			Console.WriteLine("Ingrese nombre del entrenador: ");
			string nombre = Console.ReadLine();

			Console.WriteLine("Ingrese DNI del entrenador: ");
			int dni = int.Parse(Console.ReadLine());

			entrenador nuevoEntrenador = new entrenador(nombre, dni);
			miClub.agregarEntrenador(nuevoEntrenador);

			Console.WriteLine("Entrenador agregado correctamente."); //en categoria se asigna el entrenador.
		}

		static void bajaEntrenador(club miClub)
		{
			if (miClub.cantidadEntrenador() <= 0)
			{
				Console.WriteLine("NO HAY ENTRENADORES CARGADOS PARA ELIMINAR");
				return;
			}

			Console.WriteLine("Los entrenadores cargados son:");
			for (int i = 0; i < miClub.cantidadEntrenador(); i++)
			{
				entrenador temp = (entrenador)miClub.recuperarEntrenador(i);
				Console.WriteLine("nombre:" + temp.NOMBRE + " - DNI:" + temp.DNI);
			}
			Console.WriteLine("Ingrese DNI del entrenador a eliminar:");
			int dni = int.Parse(Console.ReadLine());

			bool eliminado = false;

			for (int i = 0; i < miClub.cantidadEntrenador(); i++)
			{
				var entrenador = (entrenador)miClub.recuperarEntrenador(i);
				if (entrenador.DNI == dni)
				{
					miClub.eliminarEntrenador(entrenador);
					Console.WriteLine("Entrenador eliminado correctamente.");
					eliminado = true;
					break;
				}
			}

			if (!eliminado)
			{
				Console.WriteLine("No se encontro un entrenador con ese DNI.");
			}
		}

		static void altaNino(club miClub)//AL DAR DE ALTA Y CREAR AL NINO pregunta si quiere ser SOCIO!!
		{
			if (miClub.cantidadDeporte() <= 0 && miClub.cantidadEntrenador() <= 0)
			{
				Console.WriteLine("NO HAY DEPORTES CARGADOS O NO HAY ENTRENADORES CARGADOS");
				return;

			}
			
			Console.WriteLine("Ingrese nombre del niño: ");
			string nombre = Console.ReadLine();

			Console.WriteLine("Ingrese el dni: ");
			int dni = int.Parse(Console.ReadLine());

			Console.WriteLine("Ingrese la edad del niño: ");
			int edad = int.Parse(Console.ReadLine());

			Console.WriteLine("Ingrese el deporte a realizar (futbol, voley, basquet y handball): ");
			string nombreDeporte = Console.ReadLine();

			deporte deporteEncontrado = null;

			for (int i = 0; i < miClub.cantidadDeporte(); i++)
			{
				deporte d = (deporte)miClub.recuperarDeporte(i);
				if (d.NOMBRE_DEPORTE == nombreDeporte)
				{
					deporteEncontrado = d;
					break;
				}
			}

			try
			{
				if (deporteEncontrado == null)
					throw new clubException("El deporte ingresado no existe, debe crear el deporte.");

				categoria categoriaAsignada = null;

				foreach (categoria cat in deporteEncontrado.CATEGORIA)
				{
					if (cat.NOMBRE_CATEGORIA == "infantil" && edad < cat.EDAD_CATEGORIA)
					{
						categoriaAsignada = cat;
						break;
					}
					if (cat.NOMBRE_CATEGORIA == "adultos" && edad >= cat.EDAD_CATEGORIA)
					{
						categoriaAsignada = cat;
						break;
					}
				}

				if (categoriaAsignada == null)
					throw new clubException("No hay una categoría disponible para la edad ingresada.");

				if (deporteEncontrado.INSCRIPTOS >= categoriaAsignada.CUPO)
					throw new clubException("No hay cupo disponible en esa categoría.");

				Console.WriteLine("Hay cupo disponible, inscribiendo al niño...");

				nino nuevoNino = new nino(nombre, dni, edad, deporteEncontrado, categoriaAsignada, default(DateTime));//se crea sin valor de pago

				miClub.agregarNino(nuevoNino);
				deporteEncontrado.INSCRIPTOS++;

				Console.WriteLine("Niño inscripto correctamente, desea ser socio del club? si/no");
				string rta=Console.ReadLine();
				
				if(rta=="si")
				{
					socio nuevoSocio = new socio(nuevoNino.NOMBRE,nuevoNino.DNI,nuevoNino.EDAD,nuevoNino.DEPORTE,nuevoNino.CATEGORIA,nuevoNino.ULTIMO_PAGO,0);

					miClub.agregarSocio(nuevoSocio);
					Console.WriteLine("nuevo socio creado, obtendra un descuento al abonar la cuota");}
				else return;
				
			}
			catch (clubException ex) //la exepcion es generica, solo imprime un mensaje.
			{
				Console.WriteLine(ex.Message);
			}
		}
		
		static void altaDeporte(club miClub)
		{
			if (miClub.cantidadEntrenador() <= 0)
			{
				Console.WriteLine("NO HAY ENTRENADORES CARGADOS, debe cargar uno antes de crear el deporte");
				return;
			}
			
			Console.WriteLine("Ingrese el nombre del deporte (futbol, voley, basquet y handball):");
			string nombreDeporte = Console.ReadLine();

			Console.WriteLine("Ingrese el valor de la cuota para este deporte (solo valores redondos, sin coma ni punto):");
			double cuota = double.Parse(Console.ReadLine());

			Console.WriteLine("Se crearán 2 categorías para este deporte: INFANTIL y ADULTOS");

			//infantil
			Console.WriteLine("Ingrese el cupo para la categoría infantil:");
			int cupoInfantil = int.Parse(Console.ReadLine());
			
			Console.WriteLine("ingrese el dia asignado a la categoria infantil:");
			string diaInfantil=Console.ReadLine();
			
			Console.WriteLine("ingrese la hora asignada a la categoria infantil (HH:MM) :");
			TimeSpan horaInfantil=TimeSpan.Parse(Console.ReadLine());
			
			Console.WriteLine("Los entrenadores disponibles son:");
			for (int i = 0; i < miClub.cantidadEntrenador(); i++)
			{
				entrenador temp = (entrenador)miClub.recuperarEntrenador(i);
				Console.WriteLine("nombre:" + temp.NOMBRE + " - DNI:" + temp.DNI);
			}

			Console.WriteLine("Ingrese el DNI del entrenador asignado a infantil:");
			int dniInfantil = int.Parse(Console.ReadLine());

			entrenador entrenadorInfantil = null;

			for (int i = 0; i < miClub.cantidadEntrenador(); i++)
			{
				var ent = (entrenador)miClub.recuperarEntrenador(i);
				if (ent.DNI == dniInfantil)
				{
					entrenadorInfantil = ent;
					break;
				}
			}

			if (entrenadorInfantil == null)
			{
				Console.WriteLine("el dni ingresado no coincide");
				return;
			}

			// adulto
			Console.WriteLine("Ingrese el cupo para la categoria adultos:");
			int cupoAdultos = int.Parse(Console.ReadLine());
			
			Console.WriteLine("ingrese el dia asignado a la categoria adultos:");
			string diaAdulto=Console.ReadLine();
			
			Console.WriteLine("ingrese la hora asignada a la categoria adultos (HH:MM) :");
			TimeSpan horaAdulto=TimeSpan.Parse(Console.ReadLine());
			
			Console.WriteLine("Los entrenadores disponibles son:");
			for (int i = 0; i < miClub.cantidadEntrenador(); i++)
			{
				entrenador temp = (entrenador)miClub.recuperarEntrenador(i);
				Console.WriteLine("nombre:" + temp.NOMBRE + " - DNI:" + temp.DNI);
			}

			Console.WriteLine("Ingrese el DNI del entrenador asignado a adultos:");
			int dniAdultos = int.Parse(Console.ReadLine());

			entrenador entrenadorAdultos = null;

			for (int i = 0; i < miClub.cantidadEntrenador(); i++)
			{
				var ent = (entrenador)miClub.recuperarEntrenador(i);
				if (ent.DNI == dniAdultos)
				{
					entrenadorAdultos = ent;
					break;
				}
			}

			if (entrenadorAdultos == null)
			{
				Console.WriteLine("el dni ingresado no coincide");
				return;
			}

			// si ambos entrenadores existen, crear el deporte y las categorias
			deporte nuevoDeporte = new deporte(nombreDeporte, 0, cuota);

			categoria infantil = new categoria("infantil", cupoInfantil, 18, entrenadorInfantil,diaInfantil,horaInfantil);
			categoria adultos = new categoria("adultos", cupoAdultos, 18, entrenadorAdultos,diaAdulto,horaAdulto);

			nuevoDeporte.agregarCategoria(infantil);
			nuevoDeporte.agregarCategoria(adultos);

			miClub.agregarDeporte(nuevoDeporte);
			Console.WriteLine("Deporte y categorías creados exitosamente.");
		}
		
		static void pagarCuota(club miClub)
		{
			if (miClub.cantidadNino() <= 0)
			{
				Console.WriteLine("NO HAY NIÑOS INSCRIPTOS");
				return;
			}

			Console.WriteLine("Los niños inscriptos que adeudan la cuota son:");
			for (int i = 0; i < miClub.cantidadNino(); i++)
			{
				nino temp = (nino)miClub.recuperarNino(i);
				
				if (temp.ULTIMO_PAGO == default(DateTime) && temp.ULTIMO_PAGO.Month != DateTime.Now.Month)
					
					Console.WriteLine("nombre:" + temp.NOMBRE + " - DNI:" + temp.DNI);
			}

			Console.WriteLine("Ingrese el DNI del niño para registrar el pago:");
			int dniPago = int.Parse(Console.ReadLine());

			nino ninoPago = null;

			for (int i = 0; i < miClub.cantidadNino(); i++)
			{
				nino temp = (nino)miClub.recuperarNino(i);
				if (temp.DNI == dniPago)
				{
					ninoPago = temp;
					break;
				}
			}

			if (ninoPago != null)
			{
				double cuotaBase = ninoPago.DEPORTE.CUOTA;
				double descuento = 0;

				for(int i=0;i<miClub.cantidadSocio();i++)
				{
					socio temp=(socio)miClub.recuperarSocio(i);
					
					if(temp.DNI==ninoPago.DNI)
					{
						
						if (temp.DEPORTE.NOMBRE_DEPORTE == "futbol")
							temp.PORCENTAJE_DESCUENTO = 10;
						else if (temp.DEPORTE.NOMBRE_DEPORTE == "voley")
							temp.PORCENTAJE_DESCUENTO = 5;
						else if (temp.DEPORTE.NOMBRE_DEPORTE == "basquet")
							temp.PORCENTAJE_DESCUENTO = 15;
						else if (temp.DEPORTE.NOMBRE_DEPORTE == "handball")
							temp.PORCENTAJE_DESCUENTO = 10;

						descuento = temp.PORCENTAJE_DESCUENTO;
						break;
					}
					
				}

				double cuotaConDescuento = cuotaBase * (1 - descuento / 100.0);
				Console.WriteLine("La cuota final con descuento es: " + cuotaConDescuento);

				ninoPago.ULTIMO_PAGO = DateTime.Now;
				Console.WriteLine("pago registrado el dia: " + ninoPago.ULTIMO_PAGO);
			}
			
			else
			{
				Console.WriteLine("niño no encontrado.");
			}
		}
		
		static void listaDeudor(club miClub)
		{
			if(miClub.cantidadNino()<=0)
				
			{Console.WriteLine("NO HAY NIÑOS INSCRIPTOS");
				return;
			}
			
			bool hayDeudores = false;
			
			for (int h = 0; h < miClub.cantidadNino(); h++)
			{
				nino deudorN = (nino)miClub.recuperarNino(h);

				if (deudorN.ULTIMO_PAGO == default(DateTime) && deudorN.ULTIMO_PAGO.Month != DateTime.Now.Month)
				{
					Console.WriteLine("Deudor: " + deudorN.NOMBRE + " -  DNI: " + deudorN.DNI);
					
					hayDeudores = true;
					
				}
			}
			if (!hayDeudores)
			{
				Console.WriteLine("NO HAY DEUDORES");
			}
		}
		
		static void bajaNino(club miClub)
		{
			
			if (miClub.cantidadNino() <= 0)
			{
				Console.WriteLine("NO HAY NIÑOS INSCRIPTOS");
				return;
			}

			Console.WriteLine("Los niños inscriptos son:");
			for (int i = 0; i < miClub.cantidadNino(); i++)
			{
				nino temp = (nino)miClub.recuperarNino(i);
				Console.WriteLine("nombre:" + temp.NOMBRE + " - DNI:" + temp.DNI);
			}
			Console.WriteLine("Ingrese el DNI del niño a dar de baja:");
			int dniBaja = int.Parse(Console.ReadLine());

			nino ninoBaja = null;

			for (int i = 0; i < miClub.cantidadNino(); i++)
			{
				nino temp = (nino)miClub.recuperarNino(i);
				if (temp.DNI == dniBaja)
				{
					ninoBaja = temp;
					break;
				}
			}

			if (ninoBaja != null)
			{
				miClub.eliminarNino(ninoBaja);

				// se elimina de socio tambien
				socio socioBaja = null;
				for (int i = 0; i < miClub.cantidadSocio(); i++)
				{
					socio temp = (socio)miClub.recuperarSocio(i);
					if (temp.DNI == dniBaja)
					{
						socioBaja = temp;
						break;
					}
				}

				if (socioBaja != null)
				{
					miClub.eliminarSocio(socioBaja);
				}

				
				ninoBaja.DEPORTE.INSCRIPTOS--;

				Console.WriteLine("Niño dado de baja correctamente.");
			}
			else
			{
				Console.WriteLine("Niño no encontrado.");
			}
		}
		
		static void eliminarDeporte(club miClub)
		{
			
			if (miClub.cantidadDeporte() <= 0)
			{
				Console.WriteLine("NO HAY DEPORTES CARGADOS PARA ELIMINAR");
				return;
			}
			Console.WriteLine("Ingrese el nombre del deporte que desea eliminar(futbol,voley,basquet,handball):");
			string nombreDeporte = Console.ReadLine();

			deporte deporteAEliminar = null;

			for (int i = 0; i < miClub.cantidadDeporte(); i++)
			{
				deporte d = (deporte)miClub.recuperarDeporte(i);
				if (d.NOMBRE_DEPORTE == nombreDeporte)
				{
					deporteAEliminar = d;
					break;
				}
			}

			if (deporteAEliminar == null)//lo separe por si no encuentra el deporte y que detalle los inscriptos
			{
				Console.WriteLine("No se encontro ese deporte.");
				return;
			}

			if (deporteAEliminar.INSCRIPTOS > 0)
			{
				Console.WriteLine("No se puede eliminar el deporte porque tiene niños inscriptos.");
			}
			else
			{
				miClub.eliminarDeporte(deporteAEliminar);
				Console.WriteLine("Deporte eliminado correctamente.");
			}
		}

		//_______________________________________SUBMENU_Y_FUNCIONES__________________________________________________________
		static void subMenu(club miClub)
		{
			while (true)
			{
				Console.WriteLine(" SUBMENU");
				Console.WriteLine("1- Listado por deporte");
				Console.WriteLine("2- Listado por deporte y categoria");
				Console.WriteLine("3- Total de inscriptos");
				Console.WriteLine("0- Volver al menu principal");
				Console.Write("Ingrese una opcion: ");

				string op = Console.ReadLine();

				switch (op)
				{
					case "1":
						listadoPorDeporte(miClub);
						break;
					case "2":
						listadoDeporteCategoria(miClub);
						break;
					case "3":
						totalIncriptos(miClub);
						break;
					case "0":
						Console.WriteLine("Volviendo al menu principal...");
						return; // sale de la funcion
					default:
						Console.WriteLine("Opcion invalida. Intente nuevamente.");
						break;
				}
			}
		}
		
		static void listadoPorDeporte(club miClub)
		{
			Console.WriteLine();
			Console.WriteLine("**lista por deporte**");
			Console.WriteLine();
			
			if (miClub.cantidadNino() == 0)
			{
				Console.WriteLine("NO HAY NIÑOS INSCRIPTOS");
				Console.WriteLine();
				
				if (miClub.cantidadDeporte() == 0)
				{
					Console.WriteLine("NO HAY DEPORTES CARGADOS");
					Console.WriteLine();
					
					if (miClub.cantidadEntrenador() == 0)
					{
						Console.WriteLine("NO HAY ENTRENADORES CARGADOS");
						Console.WriteLine();
						return;
					}
				}
			}
			
			for (int d = 0; d < miClub.cantidadDeporte(); d++)
			{
				deporte deporteActual = (deporte)miClub.recuperarDeporte(d);
				Console.WriteLine("Deporte: "+deporteActual.NOMBRE_DEPORTE);

				bool hayNinos = false;

				for (int n = 0; n < miClub.cantidadNino(); n++)
				{
					nino actual = (nino)miClub.recuperarNino(n);

					if (actual.DEPORTE == deporteActual)
					{
						Console.WriteLine(actual.NOMBRE);
						hayNinos = true;
					}
				}

				if (!hayNinos)
					Console.WriteLine("No hay niños inscriptos en este deporte");

				Console.WriteLine();
			}
		}
		
		
		static void listadoDeporteCategoria(club miClub)
		{
			Console.WriteLine();
			Console.WriteLine("**lista por deporte y categoria**");
			Console.WriteLine();
			
			if (miClub.cantidadNino() == 0)
			{
				Console.WriteLine("NO HAY NIÑOS INSCRIPTOS");
				Console.WriteLine();
				
				if (miClub.cantidadDeporte() == 0)
				{
					Console.WriteLine("NO HAY DEPORTES CARGADOS");
					Console.WriteLine();
					
					if (miClub.cantidadEntrenador() == 0)
					{
						Console.WriteLine("NO HAY ENTRENADORES CARGADOS");
						Console.WriteLine();
						return;
					}
				}
			}
			
			for (int d = 0; d < miClub.cantidadDeporte(); d++)
			{
				deporte deporteActual = (deporte)miClub.recuperarDeporte(d);
				Console.WriteLine("Deporte: " + deporteActual.NOMBRE_DEPORTE);

				for (int c = 0; c < deporteActual.cantidadCategoria(); c++)
				{
					categoria categoriaActual = (categoria)deporteActual.recuperarCategoria(c);
					Console.WriteLine("  Categoría: " + categoriaActual.NOMBRE_CATEGORIA);

					bool hayNinos = false;

					for (int n = 0; n < miClub.cantidadNino(); n++)
					{
						nino actual = (nino)miClub.recuperarNino(n);

						if (actual.DEPORTE == deporteActual && actual.CATEGORIA == categoriaActual)
						{
							Console.WriteLine(actual.NOMBRE);
							hayNinos = true;
						}
					}

					if (!hayNinos)
						Console.WriteLine("(No hay niños en esta categoría)");
				}

				Console.WriteLine();
			}
		}
		
		static void totalIncriptos(club miClub)
		{
			Console.WriteLine();
			Console.WriteLine("**lista de todos los inscriptos**");
			Console.WriteLine();
			
			if (miClub.cantidadNino() == 0)
			{
				Console.WriteLine("NO HAY NIÑOS INSCRIPTOS");
				Console.WriteLine();
				
				if (miClub.cantidadDeporte() == 0)
				{
					Console.WriteLine("NO HAY DEPORTES CARGADOS");
					Console.WriteLine();
					
					if (miClub.cantidadEntrenador() == 0)
					{
						Console.WriteLine("NO HAY ENTRENADORES CARGADOS");
						Console.WriteLine();
						return;
					}
				}
			}
			
			
			bool hayNinos = false;

			for (int n = 0; n < miClub.cantidadNino(); n++)
			{
				nino actual = (nino)miClub.recuperarNino(n);

				Console.WriteLine(actual.NOMBRE);
				hayNinos = true;
			}
		}
	}
}