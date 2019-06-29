using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using YetAnotherSandboxGame.Scenes;

namespace YetAnotherSandboxGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SandboxGame : Core
    {
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            Scene = new TiledScene();
        }
    }
}
