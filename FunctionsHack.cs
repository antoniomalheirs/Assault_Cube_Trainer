using Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experimental_hack_ac
{
    internal class FunctionsHack
    {
        private Mem game = new Mem();
        private readonly Player player = new Player();

        private int pid;

        public FunctionsHack()
        {
            pid = game.GetProcIdFromName("ac_client.exe");
            game.OpenProcess(pid);
        }
        public void Frezhealth(string health)
        {
            game.FreezeValue((player.playerobject + player.health), "int", health);
        }
        public void Unfrezhealth()
        {
            game.UnfreezeValue(player.playerobject + player.health);
        }
        public void Frezshield(string shield)
        {
            game.FreezeValue((player.playerobject + player.shield), "int", shield);
        }
        public void Unfrezshield()
        {
            game.UnfreezeValue(player.playerobject + player.shield);
        }
        public void Frezbullets(string bullets)
        {
            game.FreezeValue((player.playerobject + player.bullets), "int", bullets);
        }
        public void Unfrezbullets()
        {
            game.UnfreezeValue(player.playerobject + player.bullets);
        }
        public void Frezpbullets(string pbullets)
        {
            game.FreezeValue((player.playerobject + player.pbullets), "int", pbullets);
        }
        public void Unfrezpbullets()
        {
            game.UnfreezeValue(player.playerobject + player.pbullets);
        }
        public void Frezexplosive(string explosive)
        {
            game.FreezeValue((player.playerobject + player.explosive), "int", explosive);
        }
        public void Unfrezexplosive()
        {
            game.UnfreezeValue(player.playerobject + player.explosive);
        }
        public void FrezX()
        {
            game.FreezeValue((player.playerobject + player.X), "float", player.getX().ToString());
        }
        public void UnfrezX()
        {
            game.UnfreezeValue((player.playerobject + player.X));
        }
        public void FrezY()
        {
            game.FreezeValue((player.playerobject + player.Y), "float", player.getY().ToString());
        }
        public void UnfrezY()
        {
            game.UnfreezeValue((player.playerobject + player.Y));
        }
        public void FrezZ()
        {
            game.FreezeValue((player.playerobject + player.Z), "float", player.getZ().ToString());
        }
        public void UnfrezZ()
        {
            game.UnfreezeValue((player.playerobject + player.Z));
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
    }
}
