using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
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

       

        private Actor InitPlayer()
        {
            var position = new Vector2(200, 200);
            var scale = new Vector2(.5f, .5f);
            var texture = Content.Load<Texture2D>(Contents.Actors.player);
            var sprite = new Sprite(texture);
            sprite.Origin = new Vector2(90, 185);

            var player = new ActivePlayer(position, sprite).InitComponents();
            player.Scale = scale;

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

            // add a collider so we can detect intersections
            var collider = entity.AddComponent<CircleCollider>();
            Flags.SetFlagExclusive(ref collider.CollidesWithLayers, 0);
            Flags.SetFlagExclusive(ref collider.PhysicsLayer, 1);


            // load up a Texture that contains a fireball animation and setup the animation frames
           // var texture = Content.Load<Texture2D>(Content.NinjaAdventure.plume);
           // var subtextures = Subtexture.subtexturesFromAtlas(texture, 16, 16);

           // var spriteAnimation = new SpriteAnimation(subtextures)
           // {
           //     loop = true,
           //     fps = 10
           // };

           // add the Sprite to the Entity and play the animation after creating it
           //var sprite = entity.addComponent(new Sprite<int>(subtextures[0]));
            // render after (under) our player who is on renderLayer 0, the default
            //sprite.renderLayer = 1;
            //sprite.addAnimation(0, spriteAnimation);
            //sprite.play(0);


            // clone the projectile and fire it off in the opposite direction
            var newEntity = entity.Clone(entity.Position);
            newEntity.GetComponent<BulletController>().velocity *= -1;
            AddEntity(newEntity);

            return entity;
        }
    }
}
