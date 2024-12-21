using ExileCore2.Shared.Attributes;
using ExileCore2.Shared.Nodes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasScanner.Settings
{
    [Submenu]
    public class TierColors
    {
        // Tier Colors
        [Menu("S Tier Color")]
        public ColorNode STierColor { get; set; } = new ColorNode(Color.Green);
        [Menu("A Tier Color")]
        public ColorNode ATierColor { get; set; } = new ColorNode(Color.Yellow);
        [Menu("B Tier Color")]
        public ColorNode BTierColor { get; set; } = new ColorNode(Color.Orange);
        [Menu("C Tier Color")]
        public ColorNode CTierColor { get; set; } = new ColorNode(Color.Red);
        [Menu("D Tier Color")]
        public ColorNode DTierColor { get; set; } = new ColorNode(Color.Purple);
        [Menu("Fuckthismap Tier Color")]
        public ColorNode FTierColor { get; set; } = new ColorNode(Color.Cornsilk);

    }
}
