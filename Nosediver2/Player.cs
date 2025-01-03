using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Nosediver2
{
    internal class Player : Zobject
    {
        Vector2 velocity;
        Vector2 acceleration;
        float maxSpeed = 500f;
        float accelerationRate = 1750f;
        float decelerationRate = 1250f;

        public Player(Texture2D sprite, Vector2 position) : base(sprite, position) { }

        public override void Update(GameTime gameTime)
        {
            Movement(gameTime);
        }

        void Movement(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 input = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                input.Y -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                input.Y += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                input.X -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                input.X += 1;
            }

            if (input.LengthSquared() > 0)
            {
                input.Normalize();
            }

            acceleration = input * accelerationRate;

            velocity += acceleration * deltaTime;

            if (velocity.LengthSquared() > maxSpeed * maxSpeed)
            {
                velocity.Normalize();
                velocity *= maxSpeed;
            }

            if (input == Vector2.Zero && velocity.LengthSquared() > 0)
            {
                Vector2 deceleration = -velocity;
                deceleration.Normalize();
                deceleration *= decelerationRate * deltaTime;

                if (deceleration.LengthSquared() > velocity.LengthSquared())
                {
                    velocity = Vector2.Zero;
                }
                else
                {
                    velocity += deceleration;
                }
            }

            position += velocity * deltaTime;
        }
    }
}
