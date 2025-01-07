using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Nosediver2
{
    internal class Barrier : Zobject
    {
        Direction enterDirection;

        public Barrier(Texture2D sprite, Vector2 position, string tag, List<Zobject> collidableZobjects, Direction enterDirection) :
            base(sprite, position, tag, collidableZobjects) {
            this.enterDirection = enterDirection;
        }

        public override void Update(GameTime gameTime)
        {
            CollisionCheck();
        }

        public override void OnCollisionEnter(Zobject other)
        {
            if (other.tag == "Player")
            {
                //if (playerBounds.Intersects(wallBounds))
                //{
                //    if (previousPosition.X + playerWidth <= wallBounds.X) // Left side
                //        playerPosition.X = wallBounds.X - playerWidth;
                //    else if (previousPosition.X >= wallBounds.X + wallWidth) // Right side
                //        playerPosition.X = wallBounds.X + wallWidth;
                //    else if (previousPosition.Y + playerHeight <= wallBounds.Y) // Top side
                //        playerPosition.Y = wallBounds.Y - playerHeight;
                //    else if (previousPosition.Y >= wallBounds.Y + wallHeight) // Bottom side
                //        playerPosition.Y = wallBounds.Y + wallHeight;
                //}

                if (enterDirection == Direction.East && other.position.X + other.collision.Width <= collision.Width)
                {
                    other.position.X = collision.Width - other.collision.Width;
                }
            }
        }
    }
}
