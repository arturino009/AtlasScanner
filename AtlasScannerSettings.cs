using System.Drawing;
using ExileCore2.Shared.Attributes;
using ExileCore2.Shared.Interfaces;
using ExileCore2.Shared.Nodes;
using Newtonsoft.Json;

namespace AtlasScanner
{
    public class AtlasScannerSettings : ISettings
    {
        public ToggleNode Enable { get; set; } = new ToggleNode(false);

        public RangeNode<int> FrameThickness { get; set; } = new RangeNode<int>(2, 1, 20);

        [Menu("Highlight Boss")]
        public ToggleNode ShowBoss { get; set; } = new ToggleNode(false);
        [Menu("Highlight Breach")]
        public ToggleNode ShowBreach { get; set; } = new ToggleNode(false);
        [Menu("Highlight Expedition")]
        public ToggleNode ShowExpedition { get; set; } = new ToggleNode(false);
        [Menu("Highlight Ritual")]
        public ToggleNode ShowRitual { get; set; } = new ToggleNode(false);
        [Menu("Highlight Delirium")]
        public ToggleNode ShowDelirium { get; set; } = new ToggleNode(false);
        [Menu("Highlight Corruption")]
        public ToggleNode ShowCorruption { get; set; } = new ToggleNode(false);
        [Menu("Highlight Irradiated")]
        public ToggleNode ShowIrradiated { get; set; } = new ToggleNode(false);
        [Menu("Highlight Unique Maps")]
        public ToggleNode ShowUnique { get; set; } = new ToggleNode(false);
        [Menu("Highlight Hideouts")]
        public ToggleNode ShowHideout { get; set; } = new ToggleNode(false);
        [Menu("Highlight Trader")]
        public ToggleNode ShowTrader { get; set; } = new ToggleNode(false);
        [Menu("Highlight Citadel")]
        public ToggleNode ShowCitadel { get; set; } = new ToggleNode(false);
        [Menu("Highlight Other (?) Maps")]
        public ToggleNode ShowOther { get; set; } = new ToggleNode(false);

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

        public EmptyNode Space { get; set; } = new EmptyNode();
        [Menu("Draw map names")]
        public ToggleNode MapNames { get; set; } = new ToggleNode(false);
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

        [Menu("Only higlight currently available maps")]
        public ToggleNode ShowOnlyAvailable { get; set; } = new ToggleNode(false);
    }
}