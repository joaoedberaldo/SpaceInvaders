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
using MonogameFinalProject.Modules.GameControl;


namespace MonogameFinalProject.Modules.Sprites
{
    public class Sprite : GameManager
    {
        //private Vector2         _position;
        //private Rectangle       _source;
        //private float           _fScale;
        //private Vector2         _origin;
        //private float           _fRotation;
        //private SpriteEffects   _spriteEffect;
        //private float           _depth;

        private Rectangle _Position;
        private int _Speed;
        private Color _color;

        public Rectangle Position
        {
            get { return (_Position); }
            set { _Position = value; }
        }
        public int Speed
        {
            get { return (_Speed); }
            set { _Speed = value; }
        }
        public Color Color
        {
            get { return (_color); }
            set { _color = value; }
        }

        //#region Can be deleted
        //public Vector2 Position
        //{
        //    get { return (_position); }
        //    set { _position = value; }
        //}
        //public Rectangle Source
        //{
        //    get { return (_source); }
        //    set { _source = value; }
        //}
        //public float Scale
        //{
        //    get { return (_fScale); }
        //    set { _fScale = value; }
        //}
        //public Vector2 Origin
        //{
        //    get { return (_origin); }
        //    set { _origin = value; }
        //}
        //public float Rotation
        //{
        //    get { return (_fRotation); }
        //    set { _fRotation = value; }
        //}
        //public SpriteEffects spriteEffect
        //{
        //    get { return (_spriteEffect); }
        //    set { _spriteEffect = value; }
        //}
        //public float Depth
        //{
        //    get { return (_depth); }
        //    set { _depth = value; }
        //}
        //#endregion

        public Sprite()
        {
            Reset();
        }
        public Sprite(Rectangle _newPosition, int _newSpeed, Color _newColor)
        {
            Reset();
            Position = _newPosition;
            Speed = _newSpeed;
            Color = _newColor;
        }


        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(GameTime gameTime)
        {
        }

        private void Reset() 
        {
            Position = new Rectangle(0, 0, 50, 50);
            Color = Color.White;
            Speed = 0;
        }


        public Rectangle getSpritRectangle()
        {
            return (new Rectangle(Position.X, Position.Y, 50, 50));
        }
        public bool Collision(Rectangle checkObject)
        {
            bool checkedObject = false;

            checkedObject = checkObject.Intersects(getSpritRectangle());
            return checkedObject;

        }
    }
}
