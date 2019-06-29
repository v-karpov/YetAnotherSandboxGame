using System.Collections;
using System.Collections.Generic;

using CSharpFunctionalExtensions;

using Nez;

namespace YetAnotherSandboxGame.Scenes.Sequence
{
    public abstract class SceneSequence : IEnumerator<Scene>
    {
        public abstract IReadOnlyList<Scene> Scenes { get; }

        public abstract SceneTransition DefaultTransition { get; }

        public Scene Current => Scenes[index];

        object IEnumerator.Current => Current;

        int index = -1;

        public virtual SceneTransition GetTransitionBetween(Maybe<Scene> source, Maybe<Scene> target) => default;

        public void Dispose() => Reset();

        public bool MoveNext()
        {
            index++;

            var sourceScene = index < 0 ? default : Scenes[index - 1];
            var targetScene = index == Scenes.Count ? default : Current;

            var transition = GetTransitionBetween(sourceScene, targetScene) ?? DefaultTransition;
            Core.StartSceneTransition(transition);

            return index < Scenes.Count;
        }

        public void Reset() => index = -1;
    }
}
