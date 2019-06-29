using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using Nez;

namespace YetAnotherSandboxGame.Entities
{
    public abstract class CompositeEntity : Entity
    {

        public CompositeEntity InitComponents()
        { 
            CreateComponents().Select(AddComponent).Consume();
            return this;
        }

        protected virtual IEnumerable<Component> CreateComponents()
        {
            yield break;
        }
    }
}
