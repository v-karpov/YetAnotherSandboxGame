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
        public Sprite SpriteTexture { get; set; }

        public Actor(Vector2 position, Sprite spriteTexture)
        {
            Position = position;
            SpriteTexture = spriteTexture;
        }

        public override IEnumerable<Component> CreateComponents()
        {
            yield return new CircleCollider();
            yield return new ProjectileHitDetector();
            yield return SpriteTexture;
        }
    }
}
