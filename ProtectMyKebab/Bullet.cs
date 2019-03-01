using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace ProtectMyKebab
{
     class Bullet:Basklass
     {
 
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 direction;

        public Vector2 Position
        {
            get { return position; }
        }


        private bool isVisible;


        public Bullet(Texture2D newTexture, Vector2 position,Vector2 velocity):base(newTexture, new Rectangle(position.ToPoint(),new Point(4,4)))
        {
            this.position = position;
            this.velocity = velocity;
            isVisible = true;   
        }

        public override void Update()
        {
            position += velocity;
        }

    }
}
