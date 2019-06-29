using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using YetAnotherSandboxGame.Entities;
using YetAnotherSandboxGame.Entities.Actors;
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

       

        private void InitPlayer()
        {
            var position = new Vector2(200, 200);
            var scale = new Vector2(1f, 1f);
            var texture = Content.Load<Texture2D>(Contents.Actors.player);

            player = new ActivePlayer(position, texture).InitComponents();
            player.Scale = scale;

            AddEntity(player);

        }

        public override void Update()
        {
            base.Update();
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
