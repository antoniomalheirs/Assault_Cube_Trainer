using System;
using Memory;
using Swed32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace experimental_hack_ac
{
    internal class Entitylist
    {
        private Swed game;

        public int entitylist = 0x0018AC04;
        public int botnumber = 0x0018AC0C;
        public int bot0 = 0x4;
        public int name = 0x205;
        public int health = 0xEC;
        public int team = 0x30C;
        public int X = 0x2C;
        public int Y = 0x28;
        public int Z = 0x30;

        private int botnumberr;
        private IntPtr fundPtr;
        private IntPtr basePtr;
        private IntPtr entityPtr;
        private int teamm;
        private string namee = "";
        private int healthh;
        private float Yy;
        private float Xx;
        private float Zz;

        public Entitylist()
        {
            game = new Swed("ac_client");
            fundPtr = game.GetModuleBase(".exe");
            basePtr = game.ReadPointer(fundPtr, 0x0018AC04);
        }
        public int getBotnumber()
        {
            botnumberr = game.ReadInt(fundPtr, 0x0018AC0C) - 1;
            return botnumberr;
        }

        public string getName()
        {
            namee = Encoding.UTF8.GetString(game.ReadBytes(entityPtr, name, 16));
            return namee;
        }

        public int getHealth()
        {
            healthh = game.ReadInt(entityPtr, health);
            return healthh;
        }

        public int getTeam()
        {
            teamm = game.ReadInt(entityPtr, team);
            return teamm;
        }

        public float getX()
        {
            Xx = game.ReadFloat(entityPtr, X);
            return Xx;
        }

        public float getY()
        {
            Yy = game.ReadFloat(entityPtr, Y);
            return Yy;
        }

        public float getZ()
        {
            Zz = game.ReadFloat(entityPtr, Z);
            return Zz;
        }

        public List<Enemy> getEntitybotList()
        {
            int botNumber = getBotnumber();
            List<Enemy> list = new List<Enemy>();
            Enemy enemy;
            if (botNumber > 0)
            {
                for (int i = 1; i <= botNumber; i++)
                {
                    entityPtr = game.ReadPointer(basePtr, bot0 * i);
                    namee = getName();
                    healthh = getHealth();
                    teamm = getTeam();
                    Yy = getY();
                    Xx = getX();
                    Zz = getZ();

                    enemy = new Enemy(getName(), getHealth(), getTeam(), getX(), getY(), getZ(), entityPtr);
                    list.Add(enemy);
                }
            }
            return list;
        }
    }
}
