using System;
using System.IO;
namespace TallerPractico01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("===Taller 01===");
			
			// 1. El dato del usuario
			string registroUsuario = "    	  ID_1314; Pedro Sanchez; Evaluacion_Guiada; 95";
			
			Console.WriteLine("Registro con espacios: \n{0}", registroUsuario);
			
			string registroLimpio = registroUsuario.Trim();
			Console.WriteLine("Registro Limpio: \n{0}", registroLimpio);
			
			string[] partes = registroLimpio.Split(';');
			
			string id = partes[0].Trim();
			string nombre = partes[1].Trim();
			string tarea = partes[2].Trim();
			string nota = partes[3].Trim();
			
			Console.WriteLine(string.Format("El ID es: {0} del usuario {1}. Tarea: {2} con la nota total de: {3}", id, nombre, tarea, nota));
			
			// Flujo en archivos
			string rutaraiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DatosIUJO");

            string rutaReportes = Path.Combine(rutaraiz, "Reportes");

            if (!Directory.Exists(rutaReportes)){
                Directory.CreateDirectory(rutaReportes);
                Console.WriteLine("Directorio creado exitosamente");
                }

            string archivotexto = Path.Combine(rutaraiz,"Notas.txt");

            Console.WriteLine(archivotexto);

            using(StreamWriter sw = new StreamWriter(archivotexto,true)){

                sw.WriteLine(string.Format("ID: {0} | Nota: {1} | Fecha: {2: yyyy-MM-dd HH:mm}", id,nota,DateTime.Now));

            }
            	
            Console.WriteLine("Iniciando programa...");
            
           
			
            int i = 0;

			while ( i != 4){
            	 Console.Write("Seleccione una opcion (1-5):\n 1. Desafío 1\n 2. Desafío 2\n 3. Desafío 3\n 4. Salir\n 5. Limpiar pantalla  ");
            	i = int.Parse(Console.ReadLine());
			switch (i) {
    	
            	case 1:  DesafioUno();
            	break;
            case 2: DesafioDos();
            break;
            
           case 3:  DesafioTres();
           break;
            
           case 4:
           break;
           
           case 5: Console.Clear();
           break;
           
          default: 
           Console.WriteLine("Opcion no valida");
           break;
				}
			}
   
    
   
    
            
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		





		static void DesafioUno() {
        Console.WriteLine("Desafío 1: El Validador de Seguridad");
       
        string datos = "Rafael;clave123";
        string[] partes = datos.Split(';');
        
        if (partes[1].Contains("123")) {
            
            using (StreamWriter sw = new StreamWriter("seguridad.txt", true)) {
                sw.WriteLine("Clave Débil detectada para: " + partes[0]);
            }
            Console.WriteLine("Aviso guardado en seguridad.txt");
            
        }
        Console.WriteLine("Presiona cualquier tecla para volver al menu");
        Console.ReadKey();
        Console.Clear();
    }

    
		
		
		
		
		
		static void DesafioDos() {
        Console.WriteLine("Desafío 2: El Clonador de Imágenes (FileStream)");
        
        if (File.Exists("avatar.jpg")) {
            using (FileStream origen = new FileStream("avatar.jpg", FileMode.Open))
            using (FileStream destino = new FileStream("respaldo.jpg", FileMode.Create)) {
                byte[] buffer = new byte[1024];
                int bytesLeidos;
                
                while ((bytesLeidos = origen.Read(buffer, 0, buffer.Length)) > 0) {
                    destino.Write(buffer, 0, bytesLeidos);
                }
            }
            Console.WriteLine("Imagen copiada byte a byte.");
        } 
        
        else {
            Console.WriteLine("Error: Coloca una imagen llamada 'avatar.jpg' en bin/Debug");
        }
        Console.WriteLine("Presiona cualquier tecla para volver al menu");
        Console.ReadKey();
        Console.Clear();
    }
		
		
		
		
		static void DesafioTres() {
        Console.WriteLine("Desafio 3: El Buscador de Archivos Pesados");

        // Obtenemos la ruta de la carpeta donde se ejecuta el programa
        string ruta = AppDomain.CurrentDomain.BaseDirectory;

        // Obtenemos la lista de todos los archivos en esa carpeta
        string[] archivos = Directory.GetFiles(ruta);

        foreach (string arc in archivos) {
            // Creamos un objeto FileInfo para ver los detalles del archivo
            FileInfo info = new FileInfo(arc);

            // Comparamos el tamaño. Nota: .Length devuelve bytes.
            // 5KB = 5 * 1024 = 5120 bytes.
            if (info.Length > 5120) {
                Console.WriteLine("Archivo detectado (>5KB): " + info.Name);

                // ¡Cuidado! La guía dice borrarlo. Descomenta la línea de abajo para que funcione:
                // File.Delete(arc); 
                // Console.WriteLine("Archivo eliminado satisfactoriamente.");
            }
        }
        Console.WriteLine("Presiona cualquier tecla para volver al menu");
        Console.ReadKey();
        Console.Clear();
    }
	}
}