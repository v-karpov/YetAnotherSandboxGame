using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using YetAnotherSandboxGame.Entities.Detectors;

namespace YetAnotherSandboxGame.Entities
{
    public abstract class Actor : CompositeEntity
    {
        public Texture2D SpriteTexture { get; set; }

        public Actor(Vector2 position, Texture2D spriteTexture)
        {
            Position = position;
            SpriteTexture = spriteTexture;
        }

        protected override IEnumerable<Component> CreateComponents()
        {
            yield return new CircleCollider();
            yield return new ProjectileHitDetector();
            yield return new Sprite(SpriteTexture);
        }
    }
}
