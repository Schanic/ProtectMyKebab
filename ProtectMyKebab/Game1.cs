using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ProtectMyKebab
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Player,Background;
        Vector2 PlayerPosition;
        Vector2 distance;
        
        Vector2 BackgroundPos;
        List<Bullet> bullets = new List<Bullet>();

        float rotation;
    
       
       
        

        public Game1()
        {
           
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 900;

        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent()
        {
 
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Player = Content.Load<Texture2D>("Player");
            Background = Content.Load<Texture2D>("Background");

            PlayerPosition = new Vector2(50, 50);
            BackgroundPos = new Vector2(0, 0);
            

 
        }


        protected override void UnloadContent()
        {
  
        }

  
        protected override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            IsMouseVisible = true;
          

          

            distance.X = mouse.X - PlayerPosition.X;
            distance.Y = mouse.Y - PlayerPosition.Y;

            rotation = (float)Math.Atan2(distance.Y, distance.X) ;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                PlayerPosition.Y -= 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                PlayerPosition.X -= 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                PlayerPosition.Y += 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                PlayerPosition.X += 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Shoot();
            }

            

            IsMouseVisible = true;




            UpdateBullet();
            base.Update(gameTime);


        }
            public void UpdateBullet()
            {
                foreach(Bullet bullet in bullets)
                {
                    bullet.Position +=  bullet.Velocity;
                    if (Vector2.Distance(bullet.Position, PlayerPosition) > 1000)
                        bullet.isVisible = false;
                }
                for (int i = 0; i < bullets.Count; i++)
                {
                    if(!bullets[i].isVisible)
                    {
                        bullets.RemoveAt(i);
                        i--;
                    }
                }
            }

            public void Shoot()
            {
                Bullet newBullet = new Bullet(Content.Load<Texture2D>("Bullet"));
             
                newBullet.Velocity = new Vector2((float)Math.Cos(rotation) * 12, (float)Math.Sin(rotation) * 12) ;
                newBullet.Position = PlayerPosition;
                newBullet.isVisible = true;

                if (bullets.Count() < 2000)
                    bullets.Add(newBullet);
            }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            spriteBatch.Draw(Background, new Rectangle(0,0, 1200, 900), Color.White);
            spriteBatch.Draw(Player, new Rectangle(PlayerPosition.ToPoint(), new Point(75, 75)), null, Color.White, rotation + (float)Math.PI / 2, new Vector2(Player.Width / 2, Player.Height / 2), SpriteEffects.None, 0);
            foreach (Bullet bullet in bullets)
                bullet.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
