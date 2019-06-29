using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace YetAnotherSandboxGame.Commponents
{
    public class InputHandler : Component, ITriggerListener, IUpdatable
    {
        Mover mover;
        float moveSpeed = 100f;

        VirtualIntegerAxis xAxisInput;
        VirtualIntegerAxis yAxisInput;

        public override void OnAddedToEntity()
        {
            mover = Entity.AddComponent(new Mover());

            setupInput();
        }

        public bool Enabled => true;

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
            xAxisInput.Nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.A, Keys.D));

            // vertical input from dpad, left stick or keyboard up/down
            yAxisInput = new VirtualIntegerAxis();
            yAxisInput.Nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.W, Keys.S));
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
        }
    }
}
