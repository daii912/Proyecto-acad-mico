/*
 * Created by SharpDevelop.
 * User: daiana
 * Date: 18/05/2025
 * Time: 18:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP_CLUB
{
	/// <summary>
	/// Description of entrenador.
	/// </summary>
	public class entrenador : persona
{
	public entrenador(string nom, int dni)
		: base(nom, dni)
	{
		
	}

	public void imprimirEntrenador()
	{
		Console.WriteLine("Entrenador: " + nombre);
		Console.WriteLine("DNI: " + dni);
	}
}
}
