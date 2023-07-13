using Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experimental_hack_ac
{
    internal class Player
    {
        private Mem game = new Mem();

        public string playerobject = "ac_client.exe+0017E0A8";
        public string name = ",0x205";
        public string health = ",0xEC";
        public string shield = ",0xF0";
        public string bullets = ",0x140";
        public string pbullets = ",0x12C";
        public string explosive = ",0x144";
        public string Y = ",0x2C";
        public string X = ",0x28";
        public string Z = ",0x30";

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
            game.OpenProcess(getPid());
        }
        public int getHealth()
        {
            healthh = game.ReadInt(playerobject + health);
            return healthh;
        }
        public int getShield()
        {
            shieldd = game.ReadInt(playerobject + shield);
            return shieldd;
        }
        public int getBullets()
        {
            bulletss = game.ReadInt(playerobject + bullets);
            return bulletss;
        }
        public int getPid()
        {
            pid = game.GetProcIdFromName("ac_client.exe");
            return pid;
        }
    }
}
