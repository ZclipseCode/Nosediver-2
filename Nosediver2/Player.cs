using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Nosediver2
{
    internal class Player
    {
        Texture2D sprite;
        Vector2 position;
        Vector2 velocity;
        float speed = 500f;

        public Player(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            Movement(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }

        void Movement(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity.Y -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity.Y += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X += 1;
            }

            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            position += velocity * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            velocity = Vector2.Zero;
        }
    }
}
