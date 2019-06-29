using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using YetAnotherSandboxGame.Scenes;

namespace YetAnotherSandboxGame.Commponents
{
    public class InputHandler : Component, ITriggerListener, IUpdatable
    {
        Mover mover;
        float moveSpeed = 100f;

        VirtualIntegerAxis xAxisInput;
        VirtualIntegerAxis yAxisInput;

        VirtualButton fireInput;

        Vector2 projectileVelocity = new Vector2(175);

        public override void OnAddedToEntity()
        {
            mover = Entity.AddComponent(new Mover());

            setupInput();
        }

        public bool Enabled => true;

        public int UpdateOrder => throw new NotImplementedException();

        public void OnTriggerEnter(Collider other, Collider local)
        {
            Debug.Log("triggerEnter: {0}", other.Entity.Name);
        }

        public void OnTriggerExit(Collider other, Collider local)
        {
            throw new NotImplementedException();
        }

        void setupInput()
        {
            // setup input for shooting a fireball. we will allow z on the keyboard or a on the gamepad
            fireInput = new VirtualButton();
            fireInput.Nodes.Add(new Nez.VirtualButton.MouseLeftButton());

            // horizontal input from dpad, left stick or keyboard left/right
            xAxisInput = new VirtualIntegerAxis();
            xAxisInput.Nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.A, Keys.D));

            // vertical input from dpad, left stick or keyboard up/down
            yAxisInput = new VirtualIntegerAxis();
            yAxisInput.Nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.W, Keys.S));
        }

        public override void OnRemovedFromEntity()
        {
            fireInput.Deregister();
        }

        void IUpdatable.Update()
        {
            var move = new Vector2(xAxisInput.Value, yAxisInput.Value);

            if (move != Vector2.Zero)
            {
                var movement = move * moveSpeed * Time.DeltaTime;

                mover.CalculateMovement(ref movement, out var res);
                mover.ApplyMovement(movement);
            }
            
            // слежение на мышью
            var mousePosition = Entity.Scene.Camera.MouseToWorldPoint();
            var lookVector = mousePosition -  Entity.Position;

            var rotate = Mathf.Atan2(lookVector.Y, lookVector.X) + (Mathf.Deg2Rad * 90);

            Entity.Rotation = rotate;

            // handle firing a projectile
            if (fireInput.IsPressed)
            {
                // fire a projectile in the direction we are facing
                var dir = Vector2.Zero;

                var tiledScene = Entity.Scene as TiledScene;
                tiledScene.CreateProjectiles(Entity.Position, projectileVelocity * dir);
            }
        }
    }
}
