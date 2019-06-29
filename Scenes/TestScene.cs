using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace YetAnotherSandboxGame.Scenes
{
    public class TestScene : Scene
    {
        public override void Initialize()
        {
            base.Initialize();

            // default to 1280x720 with no SceneResolutionPolicy
            SetDesignResolution(1280, 720, Scene.SceneResolutionPolicy.None);
            Screen.SetSize(1280, 720);

            var moonTex = Content.Load<Texture2D>(Contents.Shared.moon);
            var playerEntity = CreateEntity("player", new Vector2(Screen.Width / 2, Screen.Height / 2));
            playerEntity.AddComponent(new Sprite(moonTex));
        }
    }
}
