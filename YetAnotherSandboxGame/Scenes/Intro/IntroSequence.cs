using System.Collections.Generic;

using Nez;

using YetAnotherSandboxGame.Scenes.Sequence;

namespace YetAnotherSandboxGame.Scenes
{
    public class IntroSceneTransaltion : SceneSequence
    {
        public override IReadOnlyList<Scene> Scenes { get; } =
            new List<Scene>
            {

            };

        public override SceneTransition DefaultTransition => new SquaresTransition();

    }
}
