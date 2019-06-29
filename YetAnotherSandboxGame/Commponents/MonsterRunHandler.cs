using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using YetAnotherSandboxGame.Entities;

namespace YetAnotherSandboxGame.Commponents
{
    public class MonsterRunHandler : Component, IUpdatable
    {
        Mover mover;
        Actor player; 

        public MonsterRunHandler(float maxSpeed, float acceleration)
        {
            CurrentSpeed = 0;
            CanAccelearte = true;

            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
        }

        public float MaxSpeed { get; }

        public bool CanAccelearte { get; set; }

        public float CurrentSpeed { get; set; }

        public float Acceleration { get; }

        public override void OnAddedToEntity()
        {
            mover = Entity.AddComponent(new Mover());
            player = Entity.Scene.FindEntity("player") as Actor;
        }

        public void Update()
        {
            if (CanAccelearte)
            {
                CurrentSpeed += Acceleration * Time.DeltaTime;

                if (CurrentSpeed > MaxSpeed)
                {
                    CurrentSpeed = MaxSpeed;
                    CanAccelearte = false;
                }
            }
            
            var motion = Vector2Ext.Normalize(player.Position - Entity.Position) * CurrentSpeed * Time.DeltaTime;
            mover.ApplyMovement(motion);
        }
    }
}
