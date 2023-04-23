using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
                "    ___     ",
                "   /   |    ",
                "   |   0    ",
               @"   |  /|\   ",
               @"   |  / \   ",
               @" // \\      "            */

// 5. Crear un programa que simule un juego de ahorcado, en el que el usuario debe adivinar una palabra oculta letra por letra.


namespace ejer_2
{
    internal class Program
    {
        static void MonigoteProgresion(int fase, string[] monigote) {                

            if (fase == 0)
            {
                for (int i = 0; i < monigote.Length; i++)
                {
                    Console.SetCursorPosition(30, (i + 8));
                    Console.WriteLine(monigote[i]);
                }
            }

            switch (fase) { 

                case 1:
                    monigote[2] = monigote[2].Remove(7, 1);
                    monigote[2] = monigote[2].Insert(7, "O");
                    Console.SetCursorPosition(30, 10);
                    Console.Write(monigote[2]);
                    break;

                case 2:

                    monigote[3] = monigote[3].Remove(7, 1);
                    monigote[3] = monigote[3].Insert(7, "|");
                    Console.SetCursorPosition(30, 11);
                    Console.Write(monigote[3]);
                    break;

                case 3:

                    monigote[3] = monigote[3].Remove(6, 1);
                    monigote[3] = monigote[3].Insert(6, "/");
                    Console.SetCursorPosition(30, 11);
                    Console.Write(monigote[3]);
                    break;

                case 4:

                    monigote[3] = monigote[3].Remove(8, 1);
                    monigote[3] = monigote[3].Insert(8, @"\");
                    Console.SetCursorPosition(30, 11);
                    Console.Write(monigote[3]);
                    break;

                case 5:

                    monigote[4] = monigote[4].Remove(6, 1);
                    monigote[4] = monigote[4].Insert(6, "/");
                    Console.SetCursorPosition(30, 12);
                    Console.Write(monigote[4]);
                    break;

                case 6:

                    monigote[4] = monigote[4].Remove(8, 1);
                    monigote[4] = monigote[4].Insert(8, @"\");
                    Console.SetCursorPosition(30, 12);
                    Console.Write(monigote[4]);
                    break;
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random rnd = new Random();
            int fallos = 0;

            string[] palabras = { "Amiga", "Paloma", "Oculista", "Monumento", "Abogado", "Barba", "Flecha", "Diagonal", "Trillizos", "Imperdible", "Proteger", "Burbuja", "Valor", "Volcar", "Calavera", "Puerta", "Humor", "Pagar", "Campanario", "Elecciones" };

            string pala = palabras[rnd.Next(0, palabras.Length)];
            char[] palabra = pala.ToCharArray();
            string censura = new string('*', palabra.Length);
            int objetivo = palabra.Length;
            int puntaje = 0;

            string[] monigote = {
                "    ___     ",
                "   /   |    ",
                "   |        ",
               @"   |        ",
               @"   |        ",
               @" // \\      "
            };

            MonigoteProgresion(fallos, monigote);

            Console.SetCursorPosition(35, 14);
            Console.Write(censura);

            while (true)
            {               
                
                //Console.WriteLine("   " + pala);
                
                ConsoleKeyInfo key = Console.ReadKey(true);
                char tecla = key.KeyChar;
                int acertada = 0;
                bool coincidencia = false;
                bool noEncontrada = true;

                Console.SetCursorPosition(30, 14);

                for (int i = 0; i < palabra.Length; i++) {

                    if (palabra[i].ToString().ToLower() == tecla.ToString().ToLower()) {
                        coincidencia = true;
                        acertada = i;
                        noEncontrada = false;
                    };

                    if (coincidencia == true)
                    {
                        Console.SetCursorPosition(35, 14);
                        censura = censura.Remove(acertada, 1);
                        censura = censura.Insert(acertada, tecla.ToString());
                        Console.Write(censura);
                        puntaje++;
                        coincidencia = false;
                        acertada = 0;
                    }
                }
                if (noEncontrada == true)
                {
                    fallos++;
                }

                MonigoteProgresion(fallos, monigote);

                if (fallos == 6) {
                    Console.Clear();
                    Console.SetCursorPosition(29, 10);
                    Console.WriteLine("================== JUEGO TERMINADO ====================");
                    Console.SetCursorPosition(50, Console.CursorTop);
                    Console.WriteLine("PERDISTE :C");
                    Console.ReadKey(true);
                    break;
                }

                if (puntaje == objetivo)
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.SetCursorPosition(29, 10);
                    Console.WriteLine("================== JUEGO TERMINADO ====================");
                    Console.SetCursorPosition(46, Console.CursorTop);
                    Console.WriteLine("GANASTE WUJUUUUUUUU");
                    Console.ReadKey(true);
                    break;
                }
            }
        }
    }
}