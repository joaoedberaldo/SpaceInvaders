using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameFinalProject.Modules.Game;

namespace MonogameFinalProject.Modules.Sprites
{
    public class EnemySprite : Sprite
    {

        public EnemySprite()
        {
            Reset();
        }
        public EnemySprite(Rectangle _newPosition, int _newSpeed, Color _newColor)
        {
            Reset();
            Position = _newPosition;
            Speed = _newSpeed;
            Color = _newColor;
        }

        public override void Update(GameTime gameTime)
        {
            if(Speed != 0)
            {
                Rectangle rect = Position;
                rect.X += Speed;

                if (Position.X < 10)
                { Speed = 1; }
                if (Position.X > 700)
                { Speed = -1; }
                Position = rect;
            }
        }
        public override void Draw(GameTime gameTime)
        {
            Global.Global.Instance.mainGame.spriteBatch.Draw(Global.Global.Instance.InvaderTexture, Position, Color);

        }

        private void Reset()
        {
            Position = new Rectangle(0, 0, 50, 50);
            Color = Color.White;
            Speed = 0;
        }
    }
}
