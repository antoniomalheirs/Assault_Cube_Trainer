using Memory;
using Swed32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experimental_hack_ac
{
    internal class Enemy
    {
        public IntPtr enemyPtr;
        private string namee = "";
        public int healthh;
        private int teamm;
        private float Xx;
        private float Yy;
        private float Zz;

        public int name = 0x205;
        public int health = 0xEC;
        public int team = 0x30C;
        public int X = 0x2C;
        public int Y = 0x28;
        public int Z = 0x30;

        public Enemy(String name, int health, int teammm, float x, float y, float z, IntPtr enemyPtr)
        {
            this.enemyPtr = enemyPtr;
            this.namee = name;
            this.healthh = health;
            this.teamm = teammm;
            this.Xx = x;
            this.Yy = y;
            this.Zz = z;
        }

        public IntPtr getPointer()
        {
            return enemyPtr;
        }

        public string getName()
        {
            return namee;
        }

        public int getHealth()
        {
            return healthh;
        }

        public int getTeam()
        {
            return teamm;
        }

        public float getX()
        {
            return Xx;
        }

        public float getY()
        {
            return Yy;
        }

        public float getZ()
        {
            return Zz;
        }
    }
}
