using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Nez;

namespace YetAnotherSandboxGame.Commponents
{
    public class BulletController : Component, IUpdatable
    {
        public Vector2 velocity;

        ProjectileMover mover;


        public BulletController(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public override void OnAddedToEntity()
        {
            mover = Entity.GetComponent<ProjectileMover>();
        }

        void IUpdatable.Update()
        {
            if (mover.Move(velocity * Time.DeltaTime))
                Entity.Destroy();
        }
    }
}
