using System;

namespace TallerPractico01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("===Taller 01===");
			
			// 1. El dato del usuario
			string registroUsuario = "         ID_1314; Pedro Sanchez; Evaluacion_Guiada; 95";
			
			Console.WriteLine(registroUsuario);
			
			string registroLimpio = registroUsuario.Trim();
			Console.WriteLine(registroLimpio);
			
			string[] partes = registroLimpio.Split(';');
			
			string id = partes[0].Trim();
			string nombre = partes[1].Trim();
			string tarea = partes[2].Trim();
			string nota = partes[3].Trim();
			
			Console.WriteLine(string.Format("El ID es: {0} del usuario {1}. Tarea: {2} con la nota total de: {3}", id, nombre, tarea, nota));
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}