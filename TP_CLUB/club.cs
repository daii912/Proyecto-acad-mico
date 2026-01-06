/*
 * Created by SharpDevelop.
 * User: daiana
 * Date: 18/05/2025
 * Time: 18:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace TP_CLUB
{
	/// <summary>
	/// Description of club.
	/// </summary>
	public class club
{
    private string nombreClub;
    private ArrayList listaNino;
    private ArrayList listaSocio;
    private ArrayList listaEntrenador;
    private ArrayList listaDeporte;

    public club(string nombreClub)
    {
        this.nombreClub = nombreClub;
        this.listaNino = new ArrayList();
        this.listaSocio = new ArrayList();
        this.listaEntrenador = new ArrayList();
        this.listaDeporte = new ArrayList();
    }

    public string NOMBRECLUB
    {
        get { return nombreClub; }
        set { nombreClub = value; }
    }
    
    // nino
	public void agregarNino(nino nuevoNino)
	{
  	    listaNino.Add(nuevoNino);
	}

	public void eliminarNino(nino nuevoNino)
	{
  	   listaNino.Remove(nuevoNino);
	}

	public int cantidadNino()
	{
    return listaNino.Count;
	}

	public bool existeNino(nino nuevoNino)
	{
    return listaNino.Contains(nuevoNino);
	}

	public object recuperarNino(int pos)
	{
    return listaNino[pos];
	}

	public ArrayList verListaNino()
	{
		return listaNino;
	}

// SOCIO
	public void agregarSocio(socio nuevoSocio)
	{
	    listaSocio.Add(nuevoSocio);
	}

	public void eliminarSocio(socio s)
	{
 	   listaSocio.Remove(s);
	}

	public int cantidadSocio()
	{
  	  return listaSocio.Count;
	}

	public bool existeSocio(socio s)
	{
  	  return listaSocio.Contains(s);
	}

	public object recuperarSocio(int pos)
	{
 	   return listaSocio[pos];
	}

	public ArrayList verListaSocio()
	{
		return listaSocio;
	}

// ENTRENADOR
	public void agregarEntrenador(entrenador nuevoEntrenador)
	{
   		listaEntrenador.Add(nuevoEntrenador);
	}

	public void eliminarEntrenador(entrenador nuevoEntrenador)
	{
  	   listaEntrenador.Remove(nuevoEntrenador);
	}

	public int cantidadEntrenador()
	{
  	  return listaEntrenador.Count;
	}	

	public bool existeEntrenador(entrenador nuevoEntrenador)
	{
  	  return listaEntrenador.Contains(nuevoEntrenador);
	}

	public object recuperarEntrenador(int pos)
	{
  	  return listaEntrenador[pos];
	}

	public ArrayList verListaEntrenador()
	{
		return listaEntrenador;
	}

// DEPORTE
	public void agregarDeporte(deporte nuevoDeporte)
	{
  		  listaDeporte.Add(nuevoDeporte);
	}

	public void eliminarDeporte(deporte d)
	{
  	  listaDeporte.Remove(d);
	}

	public int cantidadDeporte()
	{
  	  return listaDeporte.Count;
	}

	public bool existeDeporte(deporte d)
	{
  	  return listaDeporte.Contains(d);
	}

	public object recuperarDeporte(int pos)
	{
 	   return listaDeporte[pos];
	}

	public ArrayList verListaDeporte()
	{
		return listaDeporte;
	}

    
    }//clase
}//namespace
