/*
 * Created by SharpDevelop.
 * User: daiana
 * Date: 18/05/2025
 * Time: 18:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace TP_CLUB
{
	/// <summary>
	/// Description of deporte.
	/// </summary>
	public class deporte
{
	private string nombreDeporte;
	private int inscriptos;//contador de inscriptos
	private double cuota;
	private ArrayList categoria;

	public deporte(string nombre, int inscriptos, double cuota)
	{
		this.nombreDeporte=nombre;
		this.inscriptos = inscriptos;
		this.cuota = cuota;
		this.categoria = new ArrayList();
	}

	public string NOMBRE_DEPORTE
	{
		set{this.nombreDeporte=value;}
		get{return nombreDeporte;}
	}

	public int INSCRIPTOS
	{
		set { this.inscriptos = value; }
		get { return inscriptos; }
	}

	public double CUOTA
	{
		set { this.cuota = value; }
		get { return cuota; }
	}

	public ArrayList CATEGORIA
	{
		get { return categoria; }
	}

	public void agregarCategoria(categoria nuevaCat)
	{
  	  categoria.Add(nuevaCat);
	}

	public void eliminarCategoria(categoria cat)
	{
 	   categoria.Remove(cat);
	}

	public int cantidadCategoria()
	{
		return categoria.Count;
	}

	public bool existeCategoria(categoria cat)
	{
  	   return categoria.Contains(cat);
	}

	public object recuperarCategoria(int pos)
	{
    return categoria[pos];
}

	public void verCategoria()
	{
		foreach (var cat in categoria)
    {
        Console.WriteLine(cat);
    }
	}
}

}
