using System;

namespace YetAnotherSandboxGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new SandboxGame())
                game.Run();
        }
    }
}
