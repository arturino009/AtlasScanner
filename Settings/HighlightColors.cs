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
    public class HighlightColors
    {
        // Highlight Colors
        [Menu("Boss Color")]
        public ColorNode BossColor { get; set; } = new ColorNode(Color.White);
        [Menu("Breach Color")]
        public ColorNode BreachColor { get; set; } = new ColorNode(Color.Purple);
        [Menu("Expedition Color")]
        public ColorNode ExpeditionColor { get; set; } = new ColorNode(Color.Gray);
        [Menu("Ritual Color")]
        public ColorNode RitualColor { get; set; } = new ColorNode(Color.Red);
        [Menu("Delirium Color")]
        public ColorNode DeliriumColor { get; set; } = new ColorNode(Color.DarkGray);
        [Menu("Corruption Color")]
        public ColorNode CorruptionColor { get; set; } = new ColorNode(Color.DarkRed);
        [Menu("Irradiated Color")]
        public ColorNode IrradiatedColor { get; set; } = new ColorNode(Color.Green);
        [Menu("Unique Color")]
        public ColorNode UniqueColor { get; set; } = new ColorNode(Color.Brown);
        [Menu("Hideout Color")]
        public ColorNode HideoutColor { get; set; } = new ColorNode(Color.LightBlue);
        [Menu("Trader Color")]
        public ColorNode TraderColor { get; set; } = new ColorNode(Color.Orange);
        [Menu("Other Color")]
        public ColorNode OtherColor { get; set; } = new ColorNode(Color.Pink);
        [Menu("Citadel Color")]
        public ColorNode CitadelColor { get; set; } = new ColorNode(Color.Black);

    }
}
