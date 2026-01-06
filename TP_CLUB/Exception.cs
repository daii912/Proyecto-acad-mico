/*
 * Created by SharpDevelop.
 * User: daian
 * Date: 21/05/2025
 * Time: 15:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP_CLUB
{
	/// <summary>
	/// Description of Exception.
	/// </summary>
	public class clubException : Exception
{
    public clubException(string mensaje) : base(mensaje) { }
}
}
