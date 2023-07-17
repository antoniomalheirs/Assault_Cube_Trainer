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
    internal class Program
    {
        static bool processRunning, healthrun, shieldrun, bulletsrun, pbulletsrun, explosiverun, locationrun, listarun, enemyliferun, enemylocationrun;

        static CancellationTokenSource heatlhtask, shieldtask, bulletstask, pbulletstask, explosivetask, locationtask, listatask, enemylifetask, enemylocationtask;
        static FunctionsHack injetor;
        static Entitylist enemys;
        static ConsoleKeyInfo key;

        static void Main()
        {
            int pid;
            bool pad0 = false, pad1 = false, pad2 = false, pad3 = false, pad4 = false, pad5 = false, pad6 = false, pad7 = false;

            Process gameProcess;
            Player currentp = new Player();
            
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
                                    StopShieldrun(shieldtask);
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

                                if (!explosiverun)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Explosive infinito ativada");
                                    Explosiverun();
                                }
                                else
                                {
                                    Console.Clear();
                                    injetor.Frezexplosive(0);
                                    Console.WriteLine("Explosive desativada");
                                    StopExplosiverun();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad5)
                            {
                                // Inverte o estado da função
                                pad5 = !pad5;

                                if (!locationrun)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Posicao travada ativada");
                                    Locationrun(currentp.getX(), currentp.getY(), currentp.getZ());
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Posicao desativada");
                                    StopLocationrun();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad6)
                            {
                                // Inverte o estado da função
                                pad6 = !pad6;

                                if (!listarun)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lista ativada");
                                    Listarun();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lista desativada");
                                    StopListarun();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad7)
                            {
                                // Inverte o estado da função
                                pad7 = !pad7;

                                if (!enemyliferun)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enemy life ativada");
                                    Enemyliferun();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enemy life desativada");
                                    StopEnemyliferun();
                                }
                            }

                            if (key.Key == ConsoleKey.NumPad8)
                            {
                                // Inverte o estado da função
                                pad7 = !pad7;

                                if (!enemylocationrun)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enemy location ativada");
                                    Enemylocationrun();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enemy location desativada");
                                    StopEnemylocationrun();
                                }
                            }
                        }
                        while (processRunning);

                        pad0 = false; pad1 = false; pad2 = false; pad3 = false; pad4 = false; pad5 = false; pad6 = false; pad7 = false;
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

        private static void StopShieldrun(CancellationTokenSource? shieldtask)
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

        private static void Explosiverun()
        {
            explosivetask = new CancellationTokenSource();
            CancellationToken Kcancel = explosivetask.Token;
            explosiverun = true;

            Task.Run(() =>
            {
                while (!Kcancel.IsCancellationRequested)
                {
                    injetor.Frezexplosive(10);
                    Thread.Sleep(100);
                }

                explosiverun = false;
            });
        }

        private static void StopExplosiverun()
        {
            if (explosiverun)
            {
                injetor.Frezexplosive(0);
                explosivetask.Cancel();
                explosivetask.Dispose();
                explosivetask = null;
            }
        }

        private static void Locationrun(float x, float y, float z)
        {
            locationtask = new CancellationTokenSource();
            CancellationToken Kcancel = locationtask.Token;
            locationrun = true;

            Task.Run(() =>
            {
                while (!Kcancel.IsCancellationRequested)
                {
                    injetor.FrezX(x); injetor.FrezY(y); injetor.FrezZ(z);
                    Thread.Sleep(500);
                }

                locationrun = false;
            });
        }

        private static void StopLocationrun()
        {
            if (locationrun)
            {
                locationtask.Cancel();
                locationtask.Dispose();
                locationtask = null;
            }
        }

        private static void Listarun()
        {
            listatask = new CancellationTokenSource();
            CancellationToken Kcancel = listatask.Token;
            listarun = true;

            Task.Run(() =>
            {
                while (!Kcancel.IsCancellationRequested)
                {
                    Console.Clear();
                    injetor.showEntitylist(enemys.getEntitybotList());
                    Thread.Sleep(500);
                }

                listarun = false;
            });
        }

        private static void StopListarun()
        {
            if (listarun)
            {
                listatask.Cancel();
                listatask.Dispose();
                listatask = null;
            }
        }

        private static void Enemyliferun()
        {
            enemylifetask = new CancellationTokenSource();
            CancellationToken Kcancel = enemylifetask.Token;
            enemyliferun = true;

            Task.Run(() =>
            {
                while (!Kcancel.IsCancellationRequested)
                {
                    injetor.setEntitylife(enemys.getEntitybotList(),10);
                    Thread.Sleep(500);
                }

                enemyliferun = false;
            });
        }

        private static void StopEnemyliferun()
        {
            if (enemyliferun)
            {
                enemylifetask.Cancel();
                enemylifetask.Dispose();
                enemylifetask = null;
            }
        }

        private static void Enemylocationrun()
        {
            enemylocationtask = new CancellationTokenSource();
            CancellationToken Kcancel = enemylocationtask.Token;
            List<Enemy> enemyys = new List<Enemy>();
            enemyys = enemys.getEntitybotList();
            enemylocationrun = true;

            Task.Run(() =>
            {
                while (!Kcancel.IsCancellationRequested)
                {
                    injetor.setEntitylocation(enemyys);
                    Thread.Sleep(10);
                }

                enemylocationrun = false;
            });
        }

        private static void StopEnemylocationrun()
        {
            if (enemylocationrun)
            {
                enemylocationtask.Cancel();
                enemylocationtask.Dispose();
                enemylocationtask = null;
            }
        }
    }
}