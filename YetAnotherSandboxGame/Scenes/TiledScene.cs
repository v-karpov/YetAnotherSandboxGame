﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Nez.Tiled;
using YetAnotherSandboxGame.Commponents;
using YetAnotherSandboxGame.Entities;
using YetAnotherSandboxGame.Entities.Actors;
using YetAnotherSandboxGame.Entities.Detectors;

namespace YetAnotherSandboxGame.Scenes
{
    public class TiledScene : Scene
    {
        Entity player, tileMap;
        TiledMap mapData;

        VirtualIntegerAxis xAxisInput;
        VirtualIntegerAxis yAxisInput;

        private Entity InitTileMap()
        {
            mapData = Content.Load<TiledMap>(Contents.Tilemaps.map);
            var map = CreateEntity("tilemap");
            
            var component = map.AddComponent(new TiledMapComponent(mapData));
            component.LayerIndicesToRender = null;
            component.DebugRenderEnabled = true;

            return map;
        }

        private IEnumerable<Monster> InitMonsters(int maxCount)
        {
            var minDistance = 200;
            var maxDistance = 5000;

            var count = Random.NextInt(maxCount) + maxCount / 5;
            var monsterTexture = Content.Load<Texture2D>(Contents.Actors.alien);

            while (count-- > 0)
            {
                var sprite = new Sprite(monsterTexture);
                var position = new Vector2(Random.NextInt(mapData.WidthInPixels), Random.NextInt(mapData.HeightInPixels));

                var monster = new Monster(position, sprite)
                    .InitComponents()
                    .SetScale(0.25f);
                AddEntity(monster);

                yield return monster;
            }
        }

        private Actor InitPlayer()
        {
            var position = new Vector2(200, 200);
            var scale = new Vector2(.5f, .5f);
            var texture = Content.Load<Texture2D>(Contents.Actors.player);
            var sprite = new Sprite(texture);
            sprite.Origin = new Vector2(90, 185);

            var player = new ActivePlayer(position, sprite)
                .InitComponents()
                .SetScale(scale);
            
            AddEntity(player);

            return player;
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
            player = InitPlayer();

            var monsters = InitMonsters(Random.NextInt(25) + 10).ToList();

            Camera.Entity.AddComponent(new FollowCamera(player));
        }

        /// <summary>
		/// creates a projectile and sets it in motion
		/// </summary>
		/// <returns>The projectile.</returns>
		/// <param name="position">Position.</param>
		/// <param name="velocity">Velocity.</param>
		public Entity CreateProjectiles(Vector2 position, Vector2 velocity)
        {
            // create an Entity to house the projectile and its logic
            var entity = CreateEntity("bullet");
            entity.Position = position;
            entity.AddComponent(new ProjectileMover());
            entity.AddComponent(new BulletController(velocity));
            entity.SetScale(0.1f);
            // add a collider so we can detect intersections
            var collider = entity.AddComponent<CircleCollider>();
            Flags.SetFlagExclusive(ref collider.CollidesWithLayers, 1);
            Flags.SetFlagExclusive(ref collider.PhysicsLayer, 1);


            // load up a Texture that contains a fireball animation and setup the animation frames
            var texture = Content.Load<Texture2D>(Contents.Shared.bullet);

            // add the Sprite to the Entity and play the animation after creating it
            var sprite = entity.AddComponent(new Sprite(texture));
            // render after (under) our player who is on renderLayer 0, the default
            sprite.RenderLayer = 1;

            return entity;
        }
    }
}
