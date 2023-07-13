using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;
using System.Runtime.InteropServices;
using System.Numerics;

namespace experimental_hack_ac
{
    public class Program
    {
        static void Main()
        {
            ConsoleKeyInfo key;
            Process gameProcess;
            Player currentp = new Player();
            FunctionsHack injetor;

            int pid;
            bool pad0 = false, pad1 = false, pad2 = false, pad3 = false, pad4 = false, pad5 = false, pad6 = false;
            bool processRunning = false;

            while (true)
            {
                while (!processRunning)
                {
                    pid = currentp.getPid();

                    if (pid != 0)
                    {
                        // Iniciar o processo do jogo
                        injetor = new FunctionsHack();

                        gameProcess = Process.GetProcessById(pid);
                        gameProcess.EnableRaisingEvents = true;
                        gameProcess.Exited += (sender, e) =>
                        {
                            Console.Clear();
                            Console.WriteLine("|Processo encerrado|");
                            processRunning = false;
                        };

                        processRunning = true;
                        Console.Clear();
                        Console.WriteLine("Aguardando ação...");

                        do
                        {
                            currentp = new Player();

                            key = Console.ReadKey();

                            if (key.Key == ConsoleKey.NumPad0)
                            {
                                // Inverte o estado da função
                                pad0 = !pad0;

                                if (pad0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Vida infinita ativada");
                                    injetor.Frezhealth("570");
                                }
                                else
                                {
                                    Console.Clear();
                                    injetor.Frezhealth("100");
                                    Console.WriteLine("Vida desativada");
                                    injetor.Unfrezhealth();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad1)
                            {
                                // Inverte o estado da função
                                pad1 = !pad1;

                                if (pad1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Shield infinito ativada");
                                    injetor.Frezshield("100");
                                }
                                else
                                {
                                    Console.Clear();
                                    injetor.Frezshield("0");
                                    Console.WriteLine("Shield desativada");
                                    injetor.Unfrezshield();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad2)
                            {
                                // Inverte o estado da função
                                pad2 = !pad2;

                                if (pad2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Bullets infinitas ativada");
                                    injetor.Frezbullets("60");
                                }
                                else
                                {
                                    Console.Clear();
                                    injetor.Frezbullets("25");
                                    Console.WriteLine("Bullets desativada");
                                    injetor.Unfrezbullets();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad3)
                            {
                            }

                            if (key.Key == ConsoleKey.NumPad4)
                            {
                            }

                            if (key.Key == ConsoleKey.NumPad5)
                            {
                            }

                            if (key.Key == ConsoleKey.NumPad6)
                            {
                            }
                        }
                        while (processRunning);

                        pad0 = false; pad1 = false; pad2 = false; pad3 = false; pad4 = false; pad5 = false; pad6 = false;
                        injetor.Unfrezhealth(); injetor.Unfrezshield(); injetor.Unfrezbullets();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Aguardando processo...");
                        Thread.Sleep(3000);
                    }
                }
            }
        }
    }
}