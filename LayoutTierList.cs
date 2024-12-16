using System;
using System.Drawing;
using System.Numerics;
using System.Collections.Generic;
using System.IO;
using ExileCore2;
using ExileCore2.Shared.Enums;
using Newtonsoft.Json;

namespace AtlasScanner
{
    public class TierList 
    {
        public List<string> STier { get; set; } = new List<string>();
        public List<string> ATier { get; set; } = new List<string>();
        public List<string> BTier { get; set; } = new List<string>();
        public List<string> CTier { get; set; } = new List<string>();
        public List<string> DTier { get; set; } = new List<string>();
    }

    public partial class AtlasScanner
    {
        private Dictionary<string, Color> _colorByMapName;

        private void LoadLayoutTierList()
        {
            LogMessage("Loading map layout tier list ...");
            var tierList = Path.Combine(DirectoryFullName, "map_layout_tiers.json");
            if (!File.Exists(tierList))
            {
                LogError("Layout tier list file not found: " + tierList);
                return;
            }

            try
            {
                var json = File.ReadAllText(tierList);
                var layoutTiers = JsonConvert.DeserializeObject<TierList>(json);
                if (layoutTiers == null)
                {
                    LogError("Failed to parse layout tier list file: " + tierList);
                    return;
                }

                _colorByMapName = new Dictionary<string, Color>();
                foreach (var map in layoutTiers.STier)
                {
                    _colorByMapName[map.ToLowerInvariant()] = Settings.STierColor;
                }
                foreach (var map in layoutTiers.ATier)
                {
                    _colorByMapName[map.ToLowerInvariant()] = Settings.ATierColor;
                }
                foreach (var map in layoutTiers.BTier)
                {
                    _colorByMapName[map.ToLowerInvariant()] = Settings.BTierColor;
                }
                foreach (var map in layoutTiers.CTier)
                {
                    _colorByMapName[map.ToLowerInvariant()] = Settings.CTierColor;
                }
                foreach (var map in layoutTiers.DTier)
                {
                    _colorByMapName[map.ToLowerInvariant()] = Settings.DTierColor;
                }
            }
            catch (Exception e)
            {
                LogError("Failed to load layout tier list: " + e.StackTrace);
            }
        }

        private Color GetColor(string mapName)
        {
            if (!string.IsNullOrEmpty(mapName) && _colorByMapName != null && _colorByMapName.TryGetValue(mapName.ToLowerInvariant(), out var color))
            {
                return color;
            }
            return Color.White;
        }
    }
}