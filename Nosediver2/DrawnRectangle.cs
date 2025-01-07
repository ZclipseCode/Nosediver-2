using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Nosediver2
{
    internal class DrawnRectangle
    {
        Vector2 position;
        int width;
        int height;
        GraphicsDevice graphicsDevice;
        Texture2D pixel;

        public DrawnRectangle(Vector2 position, int width, int height, GraphicsDevice graphicsDevice)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.graphicsDevice = graphicsDevice;
            pixel = CreatePixel(this.graphicsDevice);
        }

        Texture2D CreatePixel(GraphicsDevice graphicsDevice)
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
            return texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, width, height), Color.Black);
        }
    }
}
