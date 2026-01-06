/*
 * Created by SharpDevelop.
 * User: daiana
 * Date: 18/05/2025
 * Time: 18:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP_CLUB
{
	/// <summary>
	/// Description of categoria.
	/// </summary>
	public class categoria
{
    private string nombreCategoria;
    private int edadCategoria;
    private int cupo;
    private string dia;
    private TimeSpan hora;    //aca cambie datetime horario.
    private entrenador entrenador;
    
    public categoria(string nombreCategoria,int cupo, int edadCategoria, entrenador entrenador, string dia, TimeSpan hora)
    {
        this.nombreCategoria = nombreCategoria;
        this.cupo = cupo;
        this.edadCategoria = edadCategoria;
        this.entrenador = entrenador;
        this.dia=dia;
        this.hora=hora;
    }

    public string NOMBRE_CATEGORIA
    {
        get { return nombreCategoria; }
        set { nombreCategoria = value; }
    }

    public int EDAD_CATEGORIA
    {
        get { return edadCategoria; }
        set { edadCategoria = value; }
    }
    
    public int CUPO
	{
		set { this.cupo = value; }
		get { return cupo; }
	}

    public entrenador ENTRENADOR
    {
        get { return entrenador; }
        set { entrenador = value; }
    }
    
    public string DIA
	{
		set { this.dia = value; }
		get { return dia; }
	}
    
    public TimeSpan HORA
	{
		set { this.hora = value; }
		get { return hora; }
	}

    public void imprimirCategoria()
    {
        Console.WriteLine("Nombre Categoría: " + nombreCategoria);
        Console.WriteLine("Edad Categoría: " + edadCategoria);
        Console.WriteLine("Entrenador: " + entrenador.NOMBRE);
        Console.WriteLine("DNI Entrenador: " + entrenador.DNI);
    }
}
}
