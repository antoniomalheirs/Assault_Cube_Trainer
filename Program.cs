using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;
using System.Runtime.InteropServices;
using System.Numerics;
using System.ComponentModel.Design;

namespace experimental_hack_ac
{
    class Program
    {
        static int pid;
        static bool pad0, pad1, pad2, pad3, pad4, pad5, pad6;
        static bool processRunning, healthrun, shieldrun, bulletsrun, pbulletsrun;

        static CancellationTokenSource heatlhtask, shieldtask, bulletstask, pbulletstask;
        static FunctionsHack injetor;
        static ConsoleKeyInfo key;

        static void Main()
        {
            Process gameProcess;
            Player currentp = new Player();
            Entitylist enemys;
            
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
                                    if (!healthrun)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Vida infinita ativada");
                                        Healthrun();
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Vida desativada");
                                    StopHealthrun();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad1)
                            {
                                // Inverte o estado da função
                                pad1 = !pad1;

                                if (!shieldrun)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Shield infinito ativado");
                                    Shieldrun();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Shield desativado");
                                    StopShieldrun();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad2)
                            {
                                // Inverte o estado da função
                                pad2 = !pad2;

                                if (!bulletsrun)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Bullets infinitas ativado");
                                    Bulletsrun();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Bullets desativadas");
                                    StopBulletsrun();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad3)
                            {
                                // Inverte o estado da função
                                pad3 = !pad3;

                                if (!pbulletsrun)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Pistol bullets infinitas ativado");
                                    Pbulletsrun();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Pistol bullets desativado");
                                    StopPbulletsrun();
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
        
        private static void Healthrun()
        {
            heatlhtask = new CancellationTokenSource();
            CancellationToken Kcancel = heatlhtask.Token;
            healthrun = true;

            Task.Run(() =>
            {
                while (!Kcancel.IsCancellationRequested)
                {
                    injetor.Frezhealth(570);
                    Thread.Sleep(100);
                }

                healthrun = false;
            });
        }

        private static void StopHealthrun()
        {
            if (healthrun)
            {
                injetor.Frezhealth(100);
                heatlhtask.Cancel();
                heatlhtask.Dispose();
                heatlhtask = null;
            }
        }

        private static void Shieldrun()
        {
            shieldtask = new CancellationTokenSource();
            CancellationToken Kcancel = shieldtask.Token;
            shieldrun = true;

            Task.Run(() =>
            {
                while (!Kcancel.IsCancellationRequested)
                {
                    injetor.Frezshield(100);
                    Thread.Sleep(100);
                }

                shieldrun = false;
            });
        }

        private static void StopShieldrun()
        {
            if (shieldrun)
            {
                injetor.Frezshield(0);
                shieldtask.Cancel();
                shieldtask.Dispose();
                shieldtask = null;
            }
        }

        private static void Bulletsrun()
        {
            bulletstask = new CancellationTokenSource();
            CancellationToken Kcancel = bulletstask.Token;
            bulletsrun = true;

            Task.Run(() =>
            {
                while (!Kcancel.IsCancellationRequested)
                {
                    injetor.Frezbullets(30);
                    Thread.Sleep(100);
                }

                bulletsrun = false;
            });
        }

        private static void StopBulletsrun()
        {
            if (bulletsrun)
            {
                injetor.Frezbullets(20);
                bulletstask.Cancel();
                bulletstask.Dispose();
                bulletstask = null;
            }
        }

        private static void Pbulletsrun()
        {
            pbulletstask = new CancellationTokenSource();
            CancellationToken Kcancel = pbulletstask.Token;
            pbulletsrun = true;

            Task.Run(() =>
            {
                while (!Kcancel.IsCancellationRequested)
                {
                    injetor.Frezpbullets(10);
                    Thread.Sleep(100);
                }

                pbulletsrun = false;
            });
        }

        private static void StopPbulletsrun()
        {
            if (pbulletsrun)
            {
                injetor.Frezpbullets(5);
                pbulletstask.Cancel();
                pbulletstask.Dispose();
                pbulletstask = null;
            }
        }
    }
}