/*
 * Created by SharpDevelop.
 * User: daian
 * Date: 21/05/2025
 * Time: 13:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP_CLUB
{
	/// <summary>
	/// Description of nino.
	/// </summary>
	public class nino: persona
	{
		protected int edad;
		protected deporte deporte;
		protected categoria categoria;
		protected DateTime ultimoPago;
		
		public nino(string nom, int dni, int edad, deporte deport, categoria categ, DateTime ultip)
		: base(nom, dni)
		{
			this.edad=edad;
			this.deporte=deport;
			this.categoria=categ;
			this.ultimoPago=ultip;
		}

		public int EDAD
		{
		    set { this.edad = value; }
 		    get { return edad; }
		}

		public deporte DEPORTE
		{
 		   set { this.deporte = value; }
 		   get { return deporte; }
		}

		public categoria CATEGORIA
		{
	       set { this.categoria = value; }
   		   get { return categoria; }
		}

		public DateTime ULTIMO_PAGO
		{
  		   set { this.ultimoPago = value; }
  		   get { return ultimoPago; }
		}
		
		public void ImprimirNino()
  	    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("DNI: " + dni);
        Console.WriteLine("Edad: " + edad);
        Console.WriteLine("Deporte: " + deporte);
        Console.WriteLine("Categoría: " + categoria);
        Console.WriteLine("Último Pago: " + ultimoPago.ToShortDateString());
	}
}
}
