using Memory;
using System;
using Swed32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experimental_hack_ac
{
    internal class Player
    {
        private Swed game;
        private Mem games = new Mem();

        public IntPtr basePtr;

        public int playerobject = 0x0018AC00;
        public int name = 0x205;
        public int health = 0xEC;
        public int shield = 0xF0;
        public int bullets = 0x140;
        public int pbullets = 0x12C;
        public int explosive = 0x144;
        public int Y = 0x2C;
        public int X = 0x28;
        public int Z = 0x30;

        private string namee = "";
        private int healthh;
        private int shieldd;
        private int bulletss;
        private int pbulletss;
        private int explosivee;
        private float Xx;
        private float Yy;
        private float Zz;
        private int pid;

        public Player()
        {
            game = new Swed("ac_client");
            games.OpenProcess(getPid());
            basePtr = game.ReadPointer(game.GetModuleBase(".exe"), playerobject); 
        }

        public int getHealth()
        {
            healthh = game.ReadInt(basePtr, health);
            return healthh;
        }

        public int getShield()
        {
            shieldd = game.ReadInt(basePtr, shield);
            return shieldd;
        }

        public int getBullets()
        {
            bulletss = game.ReadInt(basePtr, bullets);
            return bulletss;
        }

        public int getPid()
        {
            pid = games.GetProcIdFromName("ac_client.exe");
            return pid;
        }

        public int getPbullets()
        {
            pbulletss = game.ReadInt(basePtr, pbullets);
            return pbulletss;
        }

        public int getExplosive()
        {
            explosivee = game.ReadInt(basePtr, explosive);
            return explosivee;
        }

        public float getX()
        {
            Xx = game.ReadFloat(basePtr, X);
            return Xx;
        }

        public float getY()
        {
            Yy = game.ReadFloat(basePtr, Y);
            return Yy;
        }

        public float getZ()
        {
            Zz = game.ReadFloat(basePtr, Z);
            return Zz;
        }
    }
}
