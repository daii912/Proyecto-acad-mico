/*
 * Created by SharpDevelop.
 * User: daiana
 * Date: 18/05/2025
 * Time: 18:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP_CLUB
{
	/// <summary>
	/// Description of socio.
	/// </summary>
	public class socio : nino
{
	private int porcentajeDescuento;

	public socio(string nom, int dni, int edad, deporte deport, categoria categ, DateTime ultip, int descuento)
		: base(nom, dni, edad, deport, categ, ultip)
	{
		this.porcentajeDescuento = descuento;
	}

	public int PORCENTAJE_DESCUENTO
	{
		set { this.porcentajeDescuento = value; }
		get { return porcentajeDescuento; }
	}

	public void imprimirSocio()
	{
		Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("DNI: " + dni);
        Console.WriteLine("Edad: " + edad);
        Console.WriteLine("Deporte: " + deporte);
        Console.WriteLine("Categoría: " + categoria);
        Console.WriteLine("Último Pago: " + ultimoPago.ToShortDateString());
        Console.WriteLine("el porcentaje de descuento es: "+ porcentajeDescuento);
	}
}

}
