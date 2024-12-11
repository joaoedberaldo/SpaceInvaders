using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonogameFinalProject.Modules.GameControl;
using MonogameFinalProject.Modules.Global;
using MonogameFinalProject.Modules.Sprites;
using System;

namespace MonogameFinalProject
{
    public class SpaceInvaders : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont SpacebitFont;
        private Texture2D playerShip;
        private Texture2D enemyShip;
        private Texture2D playerBullet;
        private EnemySprite invaderSprite;
        private Texture2D arrowUp;
        private Texture2D arrowLeft;
        private Texture2D arrowRight;
        private Texture2D tabKey;
        private Texture2D trophy;

        Song song;
        SoundEffect bomb;

        private TManager<GameManager> spriteManager = new TManager<GameManager> ();
        private TManager<GameManager> playerManager = new TManager<GameManager>();
        private TManager<GameManager> bulletManager = new TManager<GameManager>();

        private int Score = 0;
        private enum GameState
        {

            TitleScreen,
            Gameplay,
            HelpScreen,
            AboutScreen,
            EndScreen

        }

        private GameState _gamestate;

        public SpaceInvaders()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public SpriteBatch spriteBatch
        {
            get { return _spriteBatch; }
        }

        public TManager<GameManager> BulletControl
        {
            get { return bulletManager; }
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Global.Instance.mainGame = this;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch                    = new SpriteBatch(GraphicsDevice);
            SpacebitFont                    = Content.Load<SpriteFont>("Spacebit");
            playerShip                      = Content.Load<Texture2D>("PlayerStandard");
            enemyShip                       = Content.Load<Texture2D>("spaceshipEnemy");
            playerBullet                    = Content.Load<Texture2D>("bullet");
            arrowUp                         = Content.Load<Texture2D>("ArrowUp");
            arrowLeft                       = Content.Load<Texture2D>("ArrowLeft");
            arrowRight                      = Content.Load<Texture2D>("ArrowRight");
            tabKey                          = Content.Load<Texture2D>("Tab");
            song                            = Content.Load<Song>("Audio/Zodik - Future Travel");
            bomb                            = Content.Load<SoundEffect>("Audio/bomb");
            trophy                          = Content.Load<Texture2D>("Trophy");

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.4f;
            MediaPlayer.Play(song);

            Global.Instance.InvaderTexture  = enemyShip;
            Global.Instance.PlayerTexture = playerShip;
            Global.Instance.BulletTexture = playerBullet;
            Global.Instance.bombSound = bomb;

            CreateSpriteInvaders();
            CreatePlayer();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            switch (_gamestate)
            {
                case GameState.TitleScreen:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        _gamestate = GameState.Gameplay;

                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.H))
                    {
                        _gamestate = GameState.HelpScreen;

                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.A))
                    {
                        _gamestate = GameState.AboutScreen;

                    }
                    

                    break;

                case GameState.Gameplay:
                    spriteManager.Update(gameTime);
                    playerManager.Update(gameTime);
                    bulletManager.Update(gameTime);
                    if (Keyboard.GetState().IsKeyDown(Keys.Tab))
                    {
                        _gamestate = GameState.TitleScreen;

                    }
                    if (spriteManager.CheckWinner() == 0)
                    {
                        //if destroyed all enemys, +1000 points
                        Score += 1000;
                        _gamestate = GameState.EndScreen; 
                    }
                    break;
                case GameState.HelpScreen:

                    if (Keyboard.GetState().IsKeyDown(Keys.Tab))
                    {
                        _gamestate = GameState.TitleScreen;

                    }
                    break;
                case GameState.AboutScreen:

                    if (Keyboard.GetState().IsKeyDown(Keys.Tab))
                    {
                        _gamestate = GameState.TitleScreen;

                    }
                    break;
                case GameState.EndScreen:

                    if (Keyboard.GetState().IsKeyDown(Keys.Tab))
                    {
                        _gamestate = GameState.TitleScreen;

                    }
                    break;


            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);
            

            _spriteBatch.Begin();
            
            switch (_gamestate)
            {
                case GameState.TitleScreen:
                    _spriteBatch.DrawString(SpacebitFont, "SPACE INVADERS", new Vector2(200, 10), Color.Black);
                    _spriteBatch.DrawString(SpacebitFont, "PRESS ENTER TO PLAY",
                        new Vector2(100, 100), Color.Black);
                    _spriteBatch.DrawString(SpacebitFont, "PRESS H TO HELP",
                        new Vector2(100, 150), Color.Black);
                    _spriteBatch.DrawString(SpacebitFont, "PRESS A TO ABOUT",
                        new Vector2(100, 200), Color.Black);
                    break;

                case GameState.Gameplay:
                    _spriteBatch.DrawString(SpacebitFont, "Score:" + Score, new Vector2(500, 420), Color.Black);
                    spriteManager.Draw(gameTime);
                    bulletManager.Draw(gameTime);
                    playerManager.Draw(gameTime);
                    break;

                case GameState.HelpScreen:
                    _spriteBatch.DrawString(SpacebitFont, "HOW TO PLAY", new Vector2(250, 10), Color.Black);
                    _spriteBatch.Draw(playerShip, new Rectangle(360, 300, 60, 60), Color.White);
                    _spriteBatch.DrawString(SpacebitFont, "SHOTS!", new Vector2(320, 150), Color.Black);
                    _spriteBatch.Draw(arrowUp, new Rectangle(360, 200, 60, 60), Color.White);
                    _spriteBatch.DrawString(SpacebitFont, "MOVE LEFT", new Vector2(10 ,300), Color.Black);
                    _spriteBatch.Draw(arrowLeft, new Rectangle(280, 300, 60, 60), Color.White);
                    _spriteBatch.DrawString(SpacebitFont, "MOVE RIGHT", new Vector2(520, 300), Color.Black);
                    _spriteBatch.Draw(arrowRight, new Rectangle(440, 300, 60, 60), Color.White);
                    _spriteBatch.Draw(tabKey, new Rectangle(240, 400, 60, 60), Color.White);
                    _spriteBatch.DrawString(SpacebitFont, "RETURN TO MENU", new Vector2(300, 400), Color.Black);
                    break;

                case GameState.AboutScreen:
                    _spriteBatch.DrawString(SpacebitFont, "ABOUT PAGE", new Vector2(250, 10), Color.Black);
                    _spriteBatch.DrawString(SpacebitFont, "MADE BY:", new Vector2(10, 100), Color.Black);
                    _spriteBatch.DrawString(SpacebitFont, "JOAO EDUARDO BERALDO IADA", new Vector2(50, 150), Color.Black);
                    _spriteBatch.Draw(tabKey, new Rectangle(10, 400, 60, 60), Color.White);
                    _spriteBatch.DrawString(SpacebitFont, "RETURN TO MENU", new Vector2(70, 400), Color.Black);

                    break;
                case GameState.EndScreen:
                    _spriteBatch.DrawString(SpacebitFont, "CONGRATULATIONS!", new Vector2(200, 10), Color.Black);
                    _spriteBatch.Draw(trophy, new Rectangle(400, 100, 50, 50), Color.White);
                    _spriteBatch.DrawString(SpacebitFont, "YOUR TOTAL SCORE IS: " + Score, new Vector2(50, 200), Color.Black);
                    _spriteBatch.Draw(tabKey, new Rectangle(240, 400, 60, 60), Color.White);
                    _spriteBatch.DrawString(SpacebitFont, "RETURN TO MENU", new Vector2(300, 400), Color.Black);

                    break;
            }

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void CreateSpriteInvaders()
        {
            Rectangle startRect = new Rectangle(0, 0, 50, 50);

            for (Int32 yPosition = 0; yPosition < 5; yPosition++ ) //4 rows
            {
                for(Int32 xPosition = 0; xPosition < 10; xPosition++ ) //10 invaders
                {
                    EnemySprite spriteInvaders = new EnemySprite(startRect, 1, Color.White);
                    spriteManager.Add(spriteInvaders);

                    startRect.X = 50*(xPosition);
                }
                startRect.Y = 50*(yPosition);
            }
        }
        private void CreatePlayer()
        {
            PlayerSprite sprPlayer= new PlayerSprite(new Rectangle(420, 420, 50, 50), Color.White);
            playerManager.Add(sprPlayer);
        }

        public bool CheckEnemyCollision (Rectangle checkObject)
        {
            bool checkedObject = false;

            if (spriteManager.ObjectCount > 0)
            {
                for (int objectIndex = 0; objectIndex < spriteManager.ObjectCount; objectIndex++)
                {
                    Sprite sprt = (Sprite)spriteManager[objectIndex];

                    if (sprt.Collision(checkObject) == true)
                    {
                        //collision
                        spriteManager.Kill(sprt.BaseId);
                        checkedObject = true;
                        Score += 100; //each  enemy, +100pts
                        break;
                    }
                }
            }

            return checkedObject;
        }
    }
}
