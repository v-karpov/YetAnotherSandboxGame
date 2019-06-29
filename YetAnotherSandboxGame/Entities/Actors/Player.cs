using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Nez;
using Nez.Sprites;
using YetAnotherSandboxGame.Commponents;

namespace YetAnotherSandboxGame.Entities
{
    public class Player : Actor
    {
        public Player(Vector2 postiition, Texture2D spriteTexture) : base(postiition, spriteTexture)
        {
        }
    }
}
