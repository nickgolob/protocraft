using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace protocraft.entities
{
    public class DudeFactory
    {
        public enum Dudes {
            Deek, Cream, Ruth, Chief, 
            Marth, Tiff, Mel, Jack 
        };

        public static CharacterEntity createCharacter(Dudes dude)
        {
            var standingFrames = new Dictionary<Macros.Direction, AnimationFrame>();
            var walkAnimations = new Dictionary<Macros.Direction, Animation>();

            // X and Y offsets in the vx_sprites sheet.
            var dudeOffset = new Dictionary<Dudes, Tuple<int, int>>() 
            {
                { Dudes.Deek, new Tuple<int, int>(0, 0) }, { Dudes.Cream, new Tuple<int, int>(32 * 3, 0) },
                { Dudes.Ruth, new Tuple<int, int>(32 * 6, 0) }, { Dudes.Chief, new Tuple<int, int>(32 * 9, 0) },
                { Dudes.Marth, new Tuple<int, int>(0, 32 * 4) }, { Dudes.Tiff, new Tuple<int, int>(32 * 3, 32 * 4) },
                { Dudes.Mel, new Tuple<int, int>(32 * 6, 32 * 4) }, { Dudes.Jack, new Tuple<int, int>(32 * 9, 32 * 4) },
            };
            // Directional offsets.
            var directionOffset = new Dictionary<Macros.Direction, int>() 
            {
                { Macros.Direction.down, 0 }, { Macros.Direction.left, 32 }, { Macros.Direction.right, 64 }, { Macros.Direction.up, 96 }
            };

            foreach (Macros.Direction direction in Enum.GetValues(typeof(Macros.Direction))) {
                var still = new AnimationFrame(
                    new Rectangle(32 + dudeOffset[dude].Item1, directionOffset[direction] + dudeOffset[dude].Item2, 32, 32),
                    TimeSpan.FromSeconds(.25), sprites.SpriteSheetManager.vx_sprites);
                var step1 = new AnimationFrame(
                    new Rectangle(0 + dudeOffset[dude].Item1, directionOffset[direction] + dudeOffset[dude].Item2, 32, 32),
                    TimeSpan.FromSeconds(.25), sprites.SpriteSheetManager.vx_sprites);
                var step2 = new AnimationFrame(
                    new Rectangle(64 + dudeOffset[dude].Item1, directionOffset[direction] + dudeOffset[dude].Item2, 32, 32),
                    TimeSpan.FromSeconds(.25), sprites.SpriteSheetManager.vx_sprites);

                var walk = new Animation();
                walk.AddFrame(still);
                walk.AddFrame(step1);
                walk.AddFrame(still);
                walk.AddFrame(step2);

                standingFrames.Add(direction, still);
                walkAnimations.Add(direction, walk);
            }

            var character = new CharacterEntity(standingFrames, walkAnimations);
            return character;
        }
    }
}
