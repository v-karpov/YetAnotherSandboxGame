using Microsoft.Xna.Framework;

using Nez;
using Nez.Sprites;

namespace YetAnotherSandboxGame.Entities.Detectors
{
    /// </summary>
    public class ProjectileHitDetector : Component, ITriggerListener
    {
        public int hitsUntilDead = 10;

        int _hitCounter;
        Sprite _sprite;


        public override void OnAddedToEntity()
        {
            _sprite = Entity.GetComponent<Sprite>();
        }


        void ITriggerListener.OnTriggerEnter(Collider other, Collider self)
        {
            _hitCounter++;
            if (_hitCounter >= hitsUntilDead)
            {
                Entity.Destroy();
                return;
            }

            _sprite.Color = Color.Red;
            Core.Schedule(0.1f, timer => _sprite.Color = Color.White);
        }


        void ITriggerListener.OnTriggerExit(Collider other, Collider self)
        { }
    }
}
