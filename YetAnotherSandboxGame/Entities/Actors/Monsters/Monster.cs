﻿using System;
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
            var components = base.CreateComponents();
            var collider = components.OfType<Collider>().FirstOrDefault();

            if (collider != null)
            {
                Flags.SetFlagExclusive(ref collider.CollidesWithLayers, 1);
                Flags.SetFlagExclusive(ref collider.PhysicsLayer, 0);
                Flags.SetFlag(ref collider.PhysicsLayer, 1);
                Flags.SetFlag(ref collider.PhysicsLayer, 2);
            }

            return components.Append(new MonsterRunHandler(50, 15f));
        }
    }
}
