using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using YetAnotherSandboxGame.Entities;
using YetAnotherSandboxGame.Entities.Detectors;

namespace YetAnotherSandboxGame.Scenes
{
    public class TiledScene : Scene
    {
        Entity player, tileMap;

        VirtualIntegerAxis xAxisInput;
        VirtualIntegerAxis yAxisInput;

        private Entity InitTileMap()
        {
            var tiledMap = Content.Load<TiledMap>(Contents.Tilemaps.map);
            var map = CreateEntity("tilemap");

            var component = map.AddComponent(new TiledMapComponent(tiledMap));
            component.LayerIndicesToRender = null;
            component.DebugRenderEnabled = true;

            return map;
        }

        void setupInput()
        {
            // horizontal input from dpad, left stick or keyboard left/right
            xAxisInput = new VirtualIntegerAxis();
            xAxisInput.Nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Left, Keys.Right));

            // vertical input from dpad, left stick or keyboard up/down
            yAxisInput.Nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Up, Keys.Down));
        }

        private void InitPlayer()
        {
            var position = new Vector2(200, 200);
            var scale = new Vector2(0.1f, 0.1f);
            var texture = Content.Load<Texture2D>(Contents.Actors.player);

            player = new Player(position, texture).InitComponents();
            player.Scale = scale;

            AddEntity(player);

            //player.AddComponent(new Sprite(Content.Load<Texture2D>(Contents.Actors.player)));
            //player.AddComponent(new ProjectileHitDetector());
            //player.AddComponent<CircleCollider>();

        }

        public override void Update()
        {
            base.Update();
            
            if (Input.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
            {
                player.LocalPosition += new Vector2(1,0);
            }
        }

        public override void Initialize()
        {
            base.Initialize();

            SetDesignResolution(1280, 720, SceneResolutionPolicy.BestFit);

            tileMap = InitTileMap();
            InitPlayer();

            Camera.Entity.AddComponent(new FollowCamera(player));
        }
    }
}
