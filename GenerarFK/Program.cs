/*
 * Creado por SharpDevelop.
 * Usuario: XX1
 * Fecha: 22/10/2016
 * Hora: 01:09 a.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
using AO;

namespace GenerarFK
{
	public struct tCabecera
	{
		public char[] desc;
		public int crc;
		public int magicWord;
	}
	
	public partial class Program
	{
		public static void Main(string[] args)
		{
			int opcion = -1;
			if (!ExistenFK())
			{
				Console.WriteLine("No se logro encontrar el archivo FK.ind");
				Console.ReadKey(true);
				return;
			}
			
			
			do
			{
				try
				{
					Console.WriteLine();
					Console.WriteLine();
					
					Console.WriteLine("Selecione una opcion:");
					Console.WriteLine("1: Generar fk.txt");
					Console.WriteLine("2: Generar fk.ind");
					Console.WriteLine("3: Salir");
					Console.Write(">> ");
					opcion = Convert.ToInt32(Console.ReadLine());
					
					switch(opcion)
					{
						case 1:
							GenerarFK();
							break;
							
						case 2:
							CrearFK();
							break;
							
						case 3:
							Console.WriteLine("Adios!");
							break;
							
					}
				}
				catch(Exception)
				{
					Console.WriteLine("Opcion invalida.");
				}
				
			}while(opcion != 3);
			
			Console.ReadKey(true);
		}
	}
}