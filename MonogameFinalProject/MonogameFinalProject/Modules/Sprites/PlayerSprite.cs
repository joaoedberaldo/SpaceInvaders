using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonogameFinalProject.Modules.Game;

namespace MonogameFinalProject.Modules.Sprites
{
    public class PlayerSprite : Sprite
    {
        private bool checkFired = false;

        public PlayerSprite(Rectangle _newPosition, Color _newColor) 
        {
            Position = _newPosition;
            Color = _newColor;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                //move to left
                Rectangle playerPos = Position;
                playerPos.X -= 2;
                if (playerPos.X <10)
                {
                    playerPos.X = 10;
                }
                Position = playerPos;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                //move to left
                Rectangle playerPos = Position;
                playerPos.X += 2;
                if (playerPos.X > 700)
                {
                    playerPos.X = 700;
                }
                Position = playerPos;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && checkFired == false)
            {
                checkFired = true;
                Fire();
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Up) && checkFired == true)
            {
                checkFired = false;
                
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Global.Global.Instance.mainGame.spriteBatch.Draw(Global.Global.Instance.PlayerTexture, Position, Color);

            //base.Draw(gameTime);
        }

        public void Fire() 
        {
                BulletSprite sprBullet = new BulletSprite(new Rectangle(Position.X, Position.Y - 10, 50, 50));
                Global.Global.Instance.mainGame.BulletControl.Add(sprBullet);
                Global.Global.Instance.bombSound.Play();
        }

    }
}
