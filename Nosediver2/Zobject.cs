using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Nosediver2
{
    internal class Zobject
    {
        public Texture2D sprite;
        public Vector2 position;
        public Rectangle collision;
        protected string tag;

        protected List<Zobject> collidableZobjects;
        protected List<Rectangle> collisions = new List<Rectangle>();

        public Zobject(Texture2D sprite, Vector2 position, string tag)
        {
            this.sprite = sprite;
            this.position = position;
            this.tag = tag;
            collision = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        public Zobject(Texture2D sprite, Vector2 position, string tag, List<Zobject> collidableZobjects)
        {
            this.sprite = sprite;
            this.position = position;
            this.tag = tag;
            collision = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            this.collidableZobjects = collidableZobjects;
            foreach (Zobject zobject in this.collidableZobjects)
            {
                collisions.Add(zobject.collision);
            }
        }

        public Zobject(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
            collision = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        public Zobject(Texture2D sprite, Vector2 position, List<Zobject> collidableZobjects)
        {
            this.sprite = sprite;
            this.position = position;
            collision = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            this.collidableZobjects = collidableZobjects;
            foreach (Zobject zobject in this.collidableZobjects)
            {
                collisions.Add(zobject.collision);
            }
        }

        public Zobject(Vector2 position, string tag)
        {
            this.position = position;
            this.tag = tag;
            collision = new Rectangle((int)position.X, (int)position.Y, 0, 0);
        }

        public Zobject(Vector2 position, string tag, List<Zobject> collidableZobjects)
        {
            this.position = position;
            this.tag = tag;
            collision = new Rectangle((int)position.X, (int)position.Y, 0, 0);
            this.collidableZobjects = collidableZobjects;
            foreach (Zobject zobject in this.collidableZobjects)
            {
                collisions.Add(zobject.collision);
            }
        }

        public Zobject(Vector2 position)
        {
            this.position = position;
            collision = new Rectangle((int)position.X, (int)position.Y, 0, 0);
        }

        public Zobject(Vector2 position, List<Zobject> collidableZobjects)
        {
            this.position = position;
            collision = new Rectangle((int)position.X, (int)position.Y, 0, 0);
            this.collidableZobjects = collidableZobjects;
            foreach (Zobject zobject in this.collidableZobjects)
            {
                collisions.Add(zobject.collision);
            }
        }

        public void CollisionCheck()
        {
            for (int i = 0; i < collidableZobjects.Count; i++)
            {
                if (collision.Intersects(collisions[i]))
                {
                    OnCollisionEnter(collidableZobjects[i]);
                }
            }
        }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (sprite != null)
            {
                spriteBatch.Draw(sprite, position, Color.White);
            }
        }

        public virtual void OnCollisionEnter(Zobject other) { }
    }
}
