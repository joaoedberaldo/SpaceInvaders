using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameFinalProject.Modules.Global
{
    public class Global
    {
        //singleton
        private static readonly Global mInstance = new Global();

        static Global()
        {

        }

        public static Global Instance
        {
            get { return mInstance; }
        }
        //properties
        public SpaceInvaders mainGame { get; set; }

        public Texture2D InvaderTexture { get; set; }
        public Texture2D PlayerTexture { get; set; }
        public Texture2D BulletTexture { get; set; }
        public SoundEffect bombSound { get; set; }

    }
}
