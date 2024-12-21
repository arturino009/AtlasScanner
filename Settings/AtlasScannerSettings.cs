using System.Drawing;
using ExileCore2.Shared.Attributes;
using ExileCore2.Shared.Interfaces;
using ExileCore2.Shared.Nodes;
using Newtonsoft.Json;

namespace AtlasScanner.Settings
{
    public class AtlasScannerSettings : ISettings
    {
        public ToggleNode Enable { get; set; } = new(false);
        public GeneralSettings GeneralSettings { get; set; } = new();
        public HighlightToggles HighlightToggles { get; set; } = new();
        public HighlightColors HighlightColors { get; set; } = new();
        public TierColors TierColors { get; set; } = new();
    }

}