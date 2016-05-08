using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace protocraft.sprites
{
    public static class SpriteSheetManager
    {
        private static SpriteSheet vx_sprites_;
        public static SpriteSheet vx_sprites
        {
            get
            {
                if (vx_sprites_ == null)
                {
                    vx_sprites_ = new vx_sprites();
                }
                return vx_sprites_;
            }
        }
    }

    public abstract class SpriteSheet
    {
        protected abstract Color GetAlphaChannel();
        protected abstract string GetSpritesheetPath();

        public Texture2D sheetTexture { get; private set; }
        public SpriteSheet()
        {
            using (var stream = TitleContainer.OpenStream(GetSpritesheetPath()))
            {
                sheetTexture = Texture2D.FromStream(Protocraft.self.GraphicsDevice, stream);
            }
        }
    }

    public class vx_sprites : SpriteSheet
    {
        protected override Color GetAlphaChannel() { return new Color(120, 195, 128); }
        protected override string GetSpritesheetPath() { return "Content/vx_sprites/vx_sprites.png"; }
    }
}
