
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace protocraft
{
    public static class Constants
    {
        public const int TileWidth = 32;  // pixels.
        public const int ScaleFactor = 2;
        public const int ScreenWidthParameter = 7;
        public const int ScreenHeightParameter = 7;

        public static int ScreenWidth { get { return Constants.ScaleFactor * Constants.TileWidth * (Constants.ScreenWidthParameter * 2 + 1); } }
        public static int ScreenHeight { get { return Constants.ScaleFactor * Constants.TileWidth * (Constants.ScreenHeightParameter * 2 + 1); } }




    }
}
