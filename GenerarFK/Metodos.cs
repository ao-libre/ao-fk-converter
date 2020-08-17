/*
 * Creado por SharpDevelop.
 * Usuario: XX1
 * Fecha: 22/10/2016
 * Hora: 01:20 a.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System.IO;
using System;
using System.Collections.Generic;

namespace GenerarFK
{
	public partial class Program
	{
		private static string fkFile = @"INIT/FK.ind";
		private static tCabecera miCabecera;
		private static int numeroMapas;

        public static tCabecera GenerarCabezera(BinaryReader rFile)
		{
			tCabecera retval;
			
			retval.desc = rFile.ReadChars(255);
			retval.crc = rFile.ReadInt32();
			retval.magicWord = rFile.ReadInt32();
			
			return retval;
		}
		
		public static bool ExistenFK()
		{
			return File.Exists(fkFile);
		}
		
		public static bool EOF(StreamReader rFile, out string c)
		{
			return (c = rFile.ReadLine()) != null;
		}
		
		public static void CrearFK()
		{
			StreamReader rFile;
			BinaryWriter wFile;
			string tmp;
			short max = -1;

            Console.WriteLine("Indique la cantidad de mapas a crear (max: " + short.MaxValue + "): ");

            
            if (!short.TryParse(Console.ReadLine(),out max) || max <= 0)
            {
                Console.WriteLine("ERROR: no se envio un numero de mapas valido.");
                return;
            }

            if (!File.Exists(@"INIT/FK.txt"))
			{
				Console.WriteLine("No existe el archivo FK.txt");
				return;
			}
			
			try
			{
				rFile  = new StreamReader(@"INIT/FK.txt");
				wFile = new BinaryWriter(File.Create(fkFile));
				
				wFile.Write( new char[255]);
				wFile.Write(99);
				wFile.Write(33);
				
				wFile.Write(max);
				
				while(EOF(rFile,out tmp))
				{
					wFile.Write(Convert.ToByte(tmp));
				}
				rFile.Close();
				wFile.Close();
			}
			catch(Exception)
			{
				Console.WriteLine("Error al crear el archivo FK.ind");
			}
		}
		
		public static void GenerarFK()
		{
			BinaryReader rFile;
			StreamWriter wFile;
			byte tmp;
			
			try
			{
				rFile = new BinaryReader(File.OpenRead(fkFile));
				wFile = new StreamWriter(@"INIT/FK.txt");
				miCabecera = GenerarCabezera(rFile);
				numeroMapas = (int)rFile.ReadInt16();
				
				for(int x = 1; x <= numeroMapas; x++)
				{
					tmp = rFile.ReadByte();
					wFile.WriteLine(tmp);
				}
				
				rFile.Close();
				wFile.Close();
				Console.Beep();
			}
			catch(Exception)
			{
				Console.WriteLine("No se logro crear el archivo fk");
			}
		}
	}
}