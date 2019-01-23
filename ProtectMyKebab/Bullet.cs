using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace ProtectMyKebab
{
     class Bullet
    {
        public Texture2D texture;
 
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Direction;


        public bool isVisible;

        public Bullet(Texture2D newTexture)
        {
            texture = newTexture;
            isVisible = false;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //         spriteBatch.Draw(texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0);
             spriteBatch.Draw(texture,Position, new Rectangle(0, 0, 40, 40), Color.White);

           
        }

    }




}
