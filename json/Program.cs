using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace convertirjson
{
    public class Datos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }

    }
    class Program
    {
        public static string _path = "products.json";
        public static Random num = new Random();
        public static Random dec = new Random();
        public static Random a = new Random();
        public static string[] nombre = { "Pera", "Manzana", "Limon", "Mango" };
        private static void Main(string[] args)
        {
            List<Datos> datos = new List<Datos>();
            for (long i = 1; i <= 90; i++)
            {
                string cadena = num.Next(1, 99).ToString() + "." + dec.Next(0, 99).ToString();
                int feed = Convert.ToInt32(i);
                Datos data = new Datos
                {
                    id = feed,
                    nombre = nombre[a.Next(0, 4)],
                    precio = Convert.ToDouble(cadena)
                };
                datos.Add(data);
            }
            //Hilos de proceso
            Thread hJsonFile1 = new Thread(new ThreadStart(() => hProceso1(datos)));
            hJsonFile1.Start();
            Thread hJsonFile2 = new Thread(new ThreadStart(() => hProceso2(datos)));
            hJsonFile2.Start();
            Thread hJsonFile3 = new Thread(new ThreadStart(() => hProceso3(datos)));
            hJsonFile3.Start();
            Thread hJsonFile4 = new Thread(new ThreadStart(() => hProceso4(datos)));
            hJsonFile4.Start();
            Thread hJsonFile5 = new Thread(new ThreadStart(() => hProceso5(datos)));
            hJsonFile5.Start();
            Thread hJsonFile6 = new Thread(new ThreadStart(() => hProceso6(datos)));
            hJsonFile6.Start();
            
            //Pausa
            Console.WriteLine("Se modificaran los precios de los productos");
            Console.ReadLine();
            
            //Hilos de modifcacion
            Thread hModificarJson1 = new Thread(new ThreadStart(() => hModificar1(datos)));
            hModificarJson1.Start();
            Thread hModificarJson2 = new Thread(new ThreadStart(() => hModificar2(datos)));
            hModificarJson2.Start();
            Thread hModificarJson3 = new Thread(new ThreadStart(() => hModificar3(datos)));
            hModificarJson3.Start();
            Thread hModificarJson4 = new Thread(new ThreadStart(() => hModificar4(datos)));
            hModificarJson4.Start();
            Jsonsecuencial(datos);
            
            //JSON DE FORMA SECUENCIAL
            Jsonsecuencial(datos);
            Modificacion(datos);
            
            //Pausa
            Console.WriteLine("Modificacion de datos en proceso");
            Console.ReadLine();
            
            Jsonsecuencial(datos);
            
            /*GetJsonFromFile();
            var data = GetJsonFromFile();
            DeserealizeJsonFile(data);*/
        }
        public static void Jsonsecuencial(List<Datos> datos)
        {
            try
            {
                string json = JsonConvert.SerializeObject(datos, Formatting.Indented);
                File.WriteAllText(_path, json);
                Console.WriteLine("Se pudo realizar el JSON con exito");
                //CODIGO BASURA
                /*File.WriteAllText("products.json", JsonConvert.SerializeObject(datos, Formatting.Indented));
                using (StreamWriter file = File.CreateText("products.json"))
                {
                     JsonSerializer serializer = new JsonSerializer();
                     serializer.Serialize(file, datos);
                }*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static string GetJsonFromFile()
        {
            string JsonFromFile;
            string nulo = "No hay datos";
            try
            {
                using (var reader = new StreamReader(_path))
                {
                    JsonFromFile = reader.ReadToEnd();
                }
                return JsonFromFile;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return nulo;
            }
        }
        public static void DeserealizeJsonFile(string JsonFromFile)
        {
            Console.WriteLine(JsonFromFile);
        }
        public static void Modificacion(List<Datos> datos)
        {
            //Peras
            var data = datos.Where(elemento => elemento.nombre.Equals("Pera", StringComparison.InvariantCultureIgnoreCase));
            foreach (var item in data)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
            data = data.Select(x => { x.precio = x.precio - 2; return x; }).ToList();
            foreach (var item in data)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
            //Manzanas
            var data1 = datos.Where(elemento => elemento.nombre.Equals("Manzana", StringComparison.InvariantCultureIgnoreCase));
            foreach (var item in data1)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
            data1 = data1.Select(x => { x.precio = x.precio + 5; return x; }).ToList();
            foreach (var item in data1)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
            //Limones
            var data2 = datos.Where(elemento => elemento.nombre.Equals("Limon", StringComparison.InvariantCultureIgnoreCase));
            foreach (var item in data2)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
            data2 = data2.Select(x => { x.precio = x.precio + 2; return x; }).ToList();
            foreach (var item in data2)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
            //Mangos
            var data3 = datos.Where(elemento => elemento.nombre.Equals("Mango", StringComparison.InvariantCultureIgnoreCase));
            foreach (var item in data3)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
            data3 = data3.Select(x => { x.precio = x.precio + 2; return x; }).ToList();
            foreach (var item in data3)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }

        }
        public static void hProceso1(List<Datos> datos)
        {
            for (long i = 1; i <= 150000; i++)
            {
                string cadena = num.Next(1, 99).ToString() + "." + dec.Next(0, 99).ToString();
                int feed = Convert.ToInt32(i);
                Datos data = new Datos
                {
                    id = feed,
                    nombre = nombre[a.Next(0, 4)],
                    precio = Convert.ToDouble(cadena)
                };
                datos.Add(data);
                //Console.WriteLine($"Iteracion {i}: {data}");
            }
        }
        public static void hProceso2(List<Datos> datos)
        {
            for (long i = 150000; i <= 300000; i++)
            {
                string cadena = num.Next(1, 99).ToString() + "." + dec.Next(0, 99).ToString();
                int feed = Convert.ToInt32(i);
                Datos data = new Datos
                {
                    id = feed,
                    nombre = nombre[a.Next(0, 4)],
                    precio = Convert.ToDouble(cadena)
                };
                datos.Add(data);
                //Console.WriteLine($"Iteracion {i}: {data}");
            }
        }
        public static void hProceso3(List<Datos> datos)
        {
            for (long i = 300000; i <= 450000; i++)
            {
                string cadena = num.Next(1, 99).ToString() + "." + dec.Next(0, 99).ToString();
                int feed = Convert.ToInt32(i);
                Datos data = new Datos
                {
                    id = feed,
                    nombre = nombre[a.Next(0, 4)],
                    precio = Convert.ToDouble(cadena)
                };
                datos.Add(data);
                //Console.WriteLine($"Iteracion {i}: {data}");
            }
        }
        public static void hProceso4(List<Datos> datos)
        {
            for (long i = 450000; i <= 600000; i++)
            {
                string cadena = num.Next(1, 99).ToString() + "." + dec.Next(0, 99).ToString();
                int feed = Convert.ToInt32(i);
                Datos data = new Datos
                {
                    id = feed,
                    nombre = nombre[a.Next(0, 4)],
                    precio = Convert.ToDouble(cadena)
                };
                datos.Add(data);
                //Console.WriteLine($"Iteracion {i}: {data}");
            }
        }
        public static void hProceso5(List<Datos> datos)
        {
            for (long i = 600000; i <= 750000; i++)
            {
                string cadena = num.Next(1, 99).ToString() + "." + dec.Next(0, 99).ToString();
                int feed = Convert.ToInt32(i);
                Datos data = new Datos
                {
                    id = feed,
                    nombre = nombre[a.Next(0, 4)],
                    precio = Convert.ToDouble(cadena)
                };
                datos.Add(data);
                //Console.WriteLine($"Iteracion {i}: {data}");
            }
        }
        public static void hProceso6(List<Datos> datos)
        {
            for (long i = 750000; i <= 900000; i++)
            {
                string cadena = num.Next(1, 99).ToString() + "." + dec.Next(0, 99).ToString();
                int feed = Convert.ToInt32(i);
                Datos data = new Datos
                {
                    id = feed,
                    nombre = nombre[a.Next(0, 4)],
                    precio = Convert.ToDouble(cadena)
                };
                datos.Add(data);
                //Console.WriteLine($"Iteracion {i}: {data}");
            }
        }
        public static void hModificar1(List<Datos> datos) 
        {
            var data = datos.Where(elemento => elemento.nombre.Equals("Pera", StringComparison.InvariantCultureIgnoreCase));
            foreach (var item in data)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
            data = datos.Select(x => { x.precio = x.precio - 2; return x; }).ToList();
            foreach (var item in data)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
        }
        public static void hModificar2(List<Datos> datos)
        {
            var data1 = datos.Where(elemento => elemento.nombre.Equals("Manzana", StringComparison.InvariantCultureIgnoreCase));
            foreach (var item in data1)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
            data1 = data1.Select(x => { x.precio = x.precio + 5; return x; }).ToList();
            foreach (var item in data1)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
        }
        public static void hModificar3(List<Datos> datos)
        {
            var data2 = datos.Where(elemento => elemento.nombre.Equals("Limon", StringComparison.InvariantCultureIgnoreCase));
            foreach (var item in data2)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
            data2 = data2.Select(x => { x.precio = x.precio + 2; return x; }).ToList();
            foreach (var item in data2)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
        }
        public static void hModificar4(List<Datos> datos)
        {
            var data3 = datos.Where(elemento => elemento.nombre.Equals("Mango", StringComparison.InvariantCultureIgnoreCase));
            foreach (var item in data3)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
            data3 = data3.Select(x => { x.precio = x.precio + 2; return x; }).ToList();
            foreach (var item in data3)
            {
                //Console.WriteLine("{0} - {1} - {2}", item.id, item.nombre, item.precio);
            }
        }
    }
}
