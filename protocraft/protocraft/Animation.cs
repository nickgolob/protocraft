using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace protocraft
{
    public class Animation
    {
        List<AnimationFrame> frames = new List<AnimationFrame>();
        TimeSpan timeIntoAnimation;

        TimeSpan Duration
        {
            get
            {
                double totalSeconds = 0;
                foreach (var frame in frames)
                {
                    totalSeconds += frame.duration.TotalSeconds;
                }

                return TimeSpan.FromSeconds(totalSeconds);
            }
        }

        private AnimationFrame currentFrame
        {
            get
            {
                AnimationFrame currentFrame = null;

                // See if we can find the frame
                TimeSpan accumulatedTime = TimeSpan.Zero;
                foreach (var frame in frames)
                {
                    if (accumulatedTime + frame.duration >= timeIntoAnimation)
                    {
                        currentFrame = frame;
                        break;
                    }
                    else
                    {
                        accumulatedTime += frame.duration;
                    }
                }

                // If no frame was found, then try the last frame, 
                // just in case timeIntoAnimation somehow exceeds Duration
                if (currentFrame == null)
                {
                    currentFrame = frames.LastOrDefault();
                }

                return currentFrame;
            }
        }

        public Rectangle CurrentRectangle
        {
            get
            {
                AnimationFrame currentFrame = this.currentFrame;

                // If we found a frame, return its rectangle, otherwise
                // return an empty rectangle (one with no width or height)
                if (currentFrame != null)
                {
                    return currentFrame.sourceRectangle;
                }
                else
                {
                    return Rectangle.Empty;
                }
            }
        }

        public Texture2D currentTexture
        {
            get
            {
                return this.currentFrame.spriteSheet.sheetTexture;
            }
        }

        public void AddFrame(Rectangle rectangle, TimeSpan duration, sprites.SpriteSheet spriteSheet)
        {
            frames.Add(new AnimationFrame(rectangle, duration, spriteSheet));
        }
        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
        }

        public void Update(GameTime gameTime)
        {
            double secondsIntoAnimation = timeIntoAnimation.TotalSeconds + gameTime.ElapsedGameTime.TotalSeconds;

            double remainder = secondsIntoAnimation % Duration.TotalSeconds;
            timeIntoAnimation = TimeSpan.FromSeconds(remainder);
        }
    }
}
