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
    }
}
