using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        private Entity InitTileMap()
        {
            var tiledMap = Content.Load<TiledMap>(Contents.Tilemaps.map);
            var map = CreateEntity("tilemap");

            var component = map.AddComponent(new TiledMapComponent(tiledMap));
            component.LayerIndicesToRender = null;
            component.DebugRenderEnabled = true;

            return map;
        }

        private Entity InitPlayer()
        {
            return new Player(new Vector2(-100, -100), Content.Load<Texture2D>(Contents.Actors.player))
                .InitComponents();
        }

        public override void Initialize()
        {
            base.Initialize();

            SetDesignResolution(1280, 720, SceneResolutionPolicy.BestFit);

            tileMap = InitTileMap();
            player = InitPlayer();

            var moonEntity = CreateEntity("moon", new Vector2(200, 200));
            moonEntity.AddComponent(new Sprite(Content.Load<Texture2D>(Contents.Shared.moon)));
            moonEntity.AddComponent(new ProjectileHitDetector());
            moonEntity.AddComponent<CircleCollider>();

            Camera.Entity.AddComponent(new FollowCamera(player));
        }
    }
}
