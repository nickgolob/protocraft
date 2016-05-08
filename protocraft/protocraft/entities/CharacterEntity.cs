using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace protocraft.entities
{
    public class CharacterEntity
    {
        int X { get; set; }
        int Y { get; set; }

        Dictionary<Macros.Direction, AnimationFrame> standingFrames;
        Dictionary<Macros.Direction, Animation> walkAnimations;

        Animation currentAnimation;

        public CharacterEntity(
            Dictionary<Macros.Direction, AnimationFrame> standingFrames,
            Dictionary<Macros.Direction, Animation> walkAnimations)
        {
            this.standingFrames = standingFrames;
            this.walkAnimations = walkAnimations;
        }

        public void Update(GameTime gameTime)
        {
            // temporary - we'll replace this with logic based off of which way the
            // character is moving when we add movement logic
            currentAnimation = walkAnimations[Macros.Direction.down];

            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftOfSprite = new Vector2(this.X, this.Y);
            Color tintColor = Color.White;
            var sourceRectangle = currentAnimation.CurrentRectangle;
            var texture = currentAnimation.currentTexture;

            spriteBatch.Draw(texture, topLeftOfSprite, sourceRectangle, new Color(120, 195, 128));
        }
    }
}
