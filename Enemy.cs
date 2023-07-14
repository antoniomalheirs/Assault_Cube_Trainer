using Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experimental_hack_ac
{
    internal class Enemy
    {
        private Mem game = new Mem();

        private IntPtr enemyPtr;
        private string namee = "";
        private int healthh;
        private int teamm;
        private float Xx;
        private float Yy;
        private float Zz;

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
