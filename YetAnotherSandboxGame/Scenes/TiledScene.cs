using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Tiled;

namespace YetAnotherSandboxGame.Scenes
{
    public class TiledScene : Scene
    {
        TiledMap tiledMap;
        TiledMapComponent component;

        public override void Initialize()
        {
            base.Initialize();

            tiledMap = Content.Load<TiledMap>(Contents.Tilemaps.map);
            var map = CreateEntity("tilemap");

            component = map.AddComponent(new TiledMapComponent(tiledMap));
            component.LayerIndicesToRender = null;

            component.DebugRenderEnabled = true;
        }
    }
}
