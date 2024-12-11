using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameFinalProject.Modules.Game;
using MonogameFinalProject.Modules.Global;

namespace MonogameFinalProject.Modules.Sprites
{
    public class BulletSprite : Sprite
    {
        private Int32 _bulletY = 2;
        public BulletSprite(Rectangle _newPosition)
        {
            Position = _newPosition;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle bulletPos = Position;

            if (bulletPos.Y < 0)
            {
                //end of the screen -> destroy bullet
                Global.Global.Instance.mainGame.BulletControl.Kill(BaseId);
            }
            else
            {
                bulletPos.Y -= _bulletY;
                Position = bulletPos;
            }

            //if (Global.Global.Instance.mainGame.CheckEnemyCollision(new Rectangle(Position.X, Position.Y, 50, 50)))
            if (Global.Global.Instance.mainGame.CheckEnemyCollision(getSpritRectangle())) 
            {
                Global.Global.Instance.mainGame.BulletControl.Kill(BaseId);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Global.Global.Instance.mainGame.spriteBatch.Draw(Global.Global.Instance.BulletTexture, Position, Color);


            //base.Draw(gameTime);
        }


    }
}
