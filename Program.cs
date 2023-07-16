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
    class Program
    {
        static int pid;
        static bool pad0, pad1, pad2, pad3, pad4, pad5, pad6;
        static bool processRunning;
        static void Main()
        {
            ConsoleKeyInfo key;
            Process gameProcess;
            Player currentp = new Player();
            Entitylist enemys;
            FunctionsHack injetor;

            //int pid;
            //bool pad0 = false, pad1 = false, pad2 = false, pad3 = false, pad4 = false, pad5 = false, pad6 = false;
            //bool processRunning = false;

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
                            enemys = new Entitylist();

                            key = Console.ReadKey();

                            if (key.Key == ConsoleKey.NumPad0)
                            {
                                // Inverte o estado da função
                                pad0 = !pad0;

                                if (pad0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Vida infinita ativada");

                                    while (pad0)
                                    {
                                        injetor.Frezhealth(570);
                                        // Aguarda um pequeno intervalo de tempo antes de verificar a condição novamente
                                        Thread.Sleep(100);

                                        if (Console.KeyAvailable)
                                        {
                                            key = Console.ReadKey(true);
                                            if (key.Key == ConsoleKey.NumPad0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Vida desativada");
                                                pad0 = false;
                                            }
                                        }
                                    }
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
                                    injetor.Frezshield(100);
                                }
                                else
                                {
                                    Console.Clear();
                                    injetor.Frezshield(0);
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
                                    injetor.Frezbullets(60);
                                }
                                else
                                {
                                    Console.Clear();
                                    injetor.Frezbullets(25);
                                    Console.WriteLine("Bullets desativada");
                                    injetor.Unfrezbullets();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad3)
                            {
                                // Inverte o estado da função
                                pad3 = !pad3;

                                if (pad3)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Pistol Bullets infinito ativada");
                                    injetor.Frezpbullets(30);
                                }
                                else
                                {
                                    Console.Clear();
                                    injetor.Frezpbullets(15);
                                    Console.WriteLine("Pistol Bullets desativada");
                                    injetor.Unfrezpbullets();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad4)
                            {
                                // Inverte o estado da função
                                pad4 = !pad4;

                                if (pad4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Explosive infinito ativada");
                                    injetor.Frezexplosive(10);
                                }
                                else
                                {
                                    Console.Clear();
                                    injetor.Frezexplosive(0);
                                    Console.WriteLine("Explosive desativada");
                                    injetor.Unfrezexplosive();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad5)
                            {
                                // Inverte o estado da função
                                pad5 = !pad5;

                                if (pad5)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Posicao travada ativada");
                                    injetor.FrezX(); injetor.FrezY(); injetor.FrezZ();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Posicao desativada");
                                    injetor.UnfrezX(); injetor.UnfrezY(); injetor.UnfrezZ();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad6)
                            {
                                // Inverte o estado da função
                                pad6 = !pad6;

                                if (pad6)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lista ativada");
                                    injetor.showEntitylist(enemys.getEntitybotList());
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lista desativada");
                                }
                            }
                        }
                        while (processRunning);

                        pad0 = false; pad1 = false; pad2 = false; pad3 = false; pad4 = false; pad5 = false; pad6 = false;
                        injetor.Unfrezhealth(); injetor.Unfrezshield(); injetor.Unfrezbullets(); injetor.Unfrezpbullets(); injetor.Unfrezexplosive(); injetor.UnfrezX(); injetor.UnfrezY(); injetor.UnfrezZ();
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