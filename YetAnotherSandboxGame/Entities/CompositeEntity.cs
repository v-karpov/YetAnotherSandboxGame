using System.Collections.Generic;

using Nez;

namespace YetAnotherSandboxGame.Entities
{
    public abstract class CompositeEntity : Entity
    {
        public virtual IEnumerable<Component> CreateComponents()
        {
            yield break;
        }
    }
}
