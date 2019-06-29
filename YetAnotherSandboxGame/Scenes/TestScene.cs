using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace YetAnotherSandboxGame.Scenes
{
    public class TestScene : Scene
    {
        const float CircleTime = 10.0f;

        const float FullCircle = Mathf.Deg2Rad * 360;
        const float RotationSpeed = FullCircle / CircleTime;
        const float Distance = 250.0f;

        Entity playerEntity;
        Vector2 origin;
        float rotationAngle = 0.0f;

        public override void Initialize()
        {
            base.Initialize();

            // default to 1280x720 with no SceneResolutionPolicy
            SetDesignResolution(1280, 720, Scene.SceneResolutionPolicy.None);
            Screen.SetSize(1280, 720);

            var moonTex = Content.Load<Texture2D>(Contents.Shared.moon);
            origin = new Vector2(Screen.Width / 2, Screen.Height / 2);

            playerEntity = CreateEntity("player", CalculatePosition(origin, Distance, rotationAngle));
            playerEntity.AddComponent(new Sprite(moonTex));
        }

        private Vector2 CalculatePosition(Vector2 origin, float distance, float angle)
        {
            var offset = new Vector2(Mathf.Cos(angle) * distance, Mathf.Sin(angle) * distance);
            return origin + offset;
        }

        public override void Update()
        {
            base.Update();

            rotationAngle = MathHelper.WrapAngle(rotationAngle + Time.UnscaledDeltaTime * RotationSpeed);
            playerEntity.Position = CalculatePosition(origin, Distance, rotationAngle);

            playerEntity.Rotation = rotationAngle;
        }
    }
}
