using System.Linq;
using Microsoft.Xna.Framework;
using MoreLinq;
using Nez;

namespace YetAnotherSandboxGame.Entities
{
    public static class EntityHelper
    {
        public static TEntity SetScale<TEntity>(this TEntity entity, float scale) where TEntity : Entity
            => SetScale(entity, new Vector2(scale));

        public static TEntity SetScale<TEntity>(this TEntity entity, Vector2 scale) where TEntity : Entity
        {
            entity.Scale = scale;
            return entity;
        }

        public static TEntity InitComponents<TEntity>(this TEntity entity) where TEntity : CompositeEntity
        {
            entity.CreateComponents().Select(entity.AddComponent).Consume();
            return entity;
        }
    }
}
