using ExileCore2.Shared.Attributes;
using ExileCore2.Shared.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasScanner.Settings
{
    [Submenu]
    public class HighlightToggles
    {
        // Highlight Toggles
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
    }
}
