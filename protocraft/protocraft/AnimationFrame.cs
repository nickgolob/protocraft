using System;
using Microsoft.Xna.Framework;

namespace protocraft
{
    public class AnimationFrame
    {
        public Rectangle sourceRectangle { get; set; }
        public TimeSpan duration { get; set; }
        public sprites.SpriteSheet spriteSheet { get; set; }

        public AnimationFrame(Rectangle sourceRectangle, TimeSpan duration, sprites.SpriteSheet spriteSheet)
        {
            this.sourceRectangle = sourceRectangle;
            this.duration = duration;
            this.spriteSheet = spriteSheet;
        }
    }
}
