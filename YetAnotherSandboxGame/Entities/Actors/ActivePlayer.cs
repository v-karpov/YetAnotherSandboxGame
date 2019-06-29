using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using YetAnotherSandboxGame.Commponents;

namespace YetAnotherSandboxGame.Entities.Actors
{
    public class ActivePlayer : Player
    {

        public ActivePlayer(Vector2 postiition, Texture2D spriteTexture) : base(postiition, spriteTexture)
        {
        }

        protected override IEnumerable<Component> CreateComponents()
        {
            return base.CreateComponents()
                .Append(new InputHandler());
        }

    }
}
