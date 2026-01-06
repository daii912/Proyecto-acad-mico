/*
 * Created by SharpDevelop.
 * User: daiana
 * Date: 18/05/2025
 * Time: 18:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP_CLUB
{
	/// <summary>
	/// Description of persona.
	/// </summary>
	public class persona
	{
		protected string nombre;
		protected int dni;
		
		public persona(string nom, int dni)
		{
			this.nombre=nom;
			this.dni=dni;
		}
		
		public string NOMBRE
		{
			set {this.nombre= value;}
			get {return nombre;}
		}
		
		public int DNI
		{
 		   set { this.dni = value; }
 		   get { return dni; }
		}

		public void Imprimir()
  	    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("DNI: " + dni);
        
   		 }
	}
}
