using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace YetAnotherSandboxGame.Commponents
{
    public class InputHandler : Component, ITriggerListener, IUpdatable
    {
        float moveSpeed = 100f;

        Mover mover;
        float moveSpeed = 100f;

        VirtualIntegerAxis xAxisInput;
        VirtualIntegerAxis yAxisInput;

        public InputHandler()
        {
            setupInput();
        }

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public void OnTriggerEnter(Collider other, Collider local)
        {
            throw new NotImplementedException();
        }

        public void OnTriggerExit(Collider other, Collider local)
        {
            throw new NotImplementedException();
        }

        void setupInput()
        {

            // horizontal input from dpad, left stick or keyboard left/right
            xAxisInput = new VirtualIntegerAxis();
            xAxisInput.Nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Left, Keys.Right));

            // vertical input from dpad, left stick or keyboard up/down
            yAxisInput = new VirtualIntegerAxis();
            yAxisInput.Nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Up, Keys.Down));
        }

        void IUpdatable.Update()
        {
            // handle movement and animations
            var move = new Vector2(xAxisInput.Value, yAxisInput.Value);
            //var animation = Animations.WalkDown;

            //if (moveDir.X < 0)
            //    animation = Animations.WalkLeft;
            //else if (moveDir.X > 0)
            //    animation = Animations.WalkRight;

            //if (moveDir.Y < 0)
            //    animation = Animations.WalkUp;
            //else if (moveDir.Y > 0)
            //    animation = Animations.WalkDown;


            //if (move != Vector2.Zero)
            //{
            //    var movement = move * moveSpeed * Time.DeltaTime;

            //    .calculateMovement(ref movement, out var res);
            //    _subpixelV2.update(ref movement);
            //    _mover.applyMovement(movement);
            //}
            //else
            //{
            //    _animation.stop();
            //}

            // handle firing a projectile
            //if (_fireInput.isPressed)
            //{
            //    // fire a projectile in the direction we are facing
            //    var dir = Vector2.Zero;
            //    switch (_animation.currentAnimation)
            //    {
            //        case Animations.WalkUp:
            //            dir.Y = -1;
            //            break;
            //        case Animations.WalkDown:
            //            dir.Y = 1;
            //            break;
            //        case Animations.WalkRight:
            //            dir.X = 1;
            //            break;
            //        case Animations.WalkLeft:
            //            dir.X = -1;
            //            break;
            //    }

            //    var ninjaScene = entity.scene as NinjaAdventureScene;
            //    ninjaScene.createProjectiles(entity.position, _projectileVelocity * dir);
            //}
        }
    }
}
