using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using YetAnotherSandboxGame.Scenes;

namespace YetAnotherSandboxGame
{
    public class SandboxGame : Core
    {
        protected override void Initialize()
        {
            base.Initialize();

            Window.AllowUserResizing = false;
            Scene = new TestScene();
        }
    }
}
