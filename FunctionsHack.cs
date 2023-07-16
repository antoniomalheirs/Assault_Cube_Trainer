using Memory;
using Swed32;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experimental_hack_ac
{
    internal class FunctionsHack
    {
        private Mem game = new Mem();
        private Swed games;

        private readonly Player player = new Player();

        private int pid;

        public FunctionsHack()
        {
            games = new Swed("ac_client");
            pid = game.GetProcIdFromName("ac_client.exe");
            game.OpenProcess(pid);
        }

        public void Frezhealth(int health)
        {
             games.WriteInt(player.basePtr + player.health, health);
        }

        public void Unfrezhealth()
        {
            games.WriteInt(player.basePtr + player.health, 100);
        }

        public void Frezshield(int shield)
        {
            games.WriteInt(player.basePtr + player.shield, shield);
        }

        public void Unfrezshield()
        {
            games.WriteInt(player.basePtr + player.shield, 0);
        }

        public void Frezbullets(int bullets)
        {
            games.WriteInt(player.basePtr + player.bullets, bullets);
        }

        public void Unfrezbullets()
        {
            games.WriteInt(player.basePtr + player.bullets, 30);
        }

        public void Frezpbullets(int pbullets)
        {
            games.WriteInt(player.basePtr + player.pbullets, pbullets);
        }

        public void Unfrezpbullets()
        {
            games.WriteInt(player.basePtr + player.pbullets, 10);
        }

        public void Frezexplosive(int explosive)
        {
            games.WriteInt(player.basePtr + player.explosive, explosive);
        }

        public void Unfrezexplosive()
        {
            games.WriteInt(player.basePtr + player.explosive, 0);
        }

        public void FrezX()
        {
            games.WriteFloat(player.basePtr + player.X, player.getX());
        }

        public void UnfrezX()
        {
            games.WriteFloat(player.basePtr + player.X, player.getX());
        }

        public void FrezY()
        {
            games.WriteFloat(player.basePtr + player.Y, player.getY());
        }

        public void UnfrezY()
        {
            games.WriteFloat(player.basePtr + player.Y, player.getY());
        }

        public void FrezZ()
        {
            games.WriteFloat(player.basePtr + player.Z, player.getZ());
        }

        public void UnfrezZ()
        {
            games.WriteFloat(player.basePtr + player.Z, player.getZ());
        }

        public void showEntitylist(List<Enemy> list)
        {
            foreach (Enemy enemy in list)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Enemy Pointer: " + enemy.getPointer());
                Console.WriteLine("Name: " + enemy.getName());
                Console.WriteLine("Health: " + enemy.getHealth());
                Console.WriteLine("Team: " + enemy.getTeam());
                Console.WriteLine("X: " + enemy.getX());
                Console.WriteLine("Y: " + enemy.getY());
                Console.WriteLine("Z: " + enemy.getZ());
                Console.WriteLine("------------------------");
            }
        }

        public void showPlayer()
        {
                Console.WriteLine("------------------------");
                Console.WriteLine("Health: " + player.getHealth());
                Console.WriteLine("Shield: " + player.getShield());
                Console.WriteLine("Bullets: " + player.getBullets());
                Console.WriteLine("pBullets: " + player.getPbullets());
                Console.WriteLine("Bullets: " + player.getExplosive());
                Console.WriteLine("X: " + player.getX());
                Console.WriteLine("Y: " + player.getY());
                Console.WriteLine("Z: " + player.getZ());
                Console.WriteLine("------------------------");
        }
    }
}
