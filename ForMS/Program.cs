using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForMS
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\evandre.s\Desktop\Nova pasta\marcas.txt";
            string pathInsertMarcas = @"C:\Users\evandre.s\Desktop\Nova pasta\marcasInsert.txt";
            string pathInserModelos = @"C:\Users\evandre.s\Desktop\Nova pasta\modelosInsert.txt";

            // This text is added only once to the file.
            int idMarca = 101;
            int idModelo = 102;
            List<string> marcasInsert = new List<string>();

            List<string> modelosInset = new List<string>();
            if (File.Exists(path))
            {
                // Create a file to write to.

                var marcasModelos = File.ReadLines(path,Encoding.UTF8);
                foreach (var item in marcasModelos)
                {
                    if (item.EndsWith(";"))
                    {
                        //Console.WriteLine($"Marca: {item.Replace(";","")}");
                        var fitem = item.Replace(";", "").Replace("'"," ");
                        string value = ($"('{idMarca}','{fitem}'),");
                      
                        marcasInsert.Add(value);
                        Console.WriteLine($"Modelo: {value}");

                      
                    }
                    else
                    {
                        idMarca--;
                        //Console.WriteLine($"Marca: {item.Replace(";","")}");
                        var fitem = item.Replace(";", "").Replace("'", " ");
                        string value = ($"('{idModelo}','{fitem}','{idMarca}'),");
                        modelosInset.Add(value);
                        Console.WriteLine($" {value}");
                      
                        idModelo++;
                    }
                    idMarca++;
                 
                }
                File.WriteAllLines(pathInsertMarcas,marcasInsert,Encoding.UTF8);
                File.WriteAllLines(pathInserModelos,modelosInset,Encoding.UTF8);

                Console.ReadKey();
              
            }
            else
            {
                Console.WriteLine("Caminho não encontrado.");
                Console.ReadKey();
            }
        }
    }
}
