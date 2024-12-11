using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameFinalProject.Modules.Game
{
    public interface IGameInterface
    {
        abstract void Initialize();
        abstract void LoadContent();
        abstract void Update(GameTime gameTime);
        abstract void Draw(GameTime gameTime);

    }
}
