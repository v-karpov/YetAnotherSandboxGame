using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using YetAnotherSandboxGame.Commponents;

namespace YetAnotherSandboxGame.Entities.Actors
{
    public class ActivePlayer : Player
    {

        public ActivePlayer(Vector2 postiition, Sprite spriteTexture) : base(postiition, spriteTexture)
        {
            Name = "player";
        }

        public override IEnumerable<Component> CreateComponents()
        {
            var components = base.CreateComponents().Where(x => !(x is Collider));
            //var collider = components.OfType<Collider>().FirstOrDefault();

            //if (collider != null)
            //{
            //    Flags.SetFlagExclusive(ref collider.CollidesWithLayers, 0);
            //    Flags.SetFlagExclusive(ref collider.PhysicsLayer, 0);
            //    Flags.SetFlag(ref collider.PhysicsLayer, 2);
            //}

            return components.Append(new InputHandler());
        }

    }
}
