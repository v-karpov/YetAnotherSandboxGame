using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using YetAnotherSandboxGame.Commponents;

namespace YetAnotherSandboxGame.Entities.Actors
{
    public class Monster : Actor
    {
        public Monster(Vector2 position, Sprite sprite) : base(position, sprite)
        {
        }

        public override IEnumerable<Component> CreateComponents()
        {
            return base.CreateComponents()
                .Append(new MonsterRunHandler(50, 15f));
        }
    }
}
