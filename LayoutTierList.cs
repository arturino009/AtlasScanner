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
        public List<string> FTier { get; set; } = new List<string>();

    }
    public class TierInfo
    {
        public string Tier { get; set; }
        public Color Color { get; set; }
    }

    public partial class AtlasScanner
    {
        private Dictionary<string, TierInfo> _colorAndTierByMapName;
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

                _colorAndTierByMapName = new Dictionary<string, TierInfo>();

                foreach (var map in layoutTiers.STier)
                {
                    _colorAndTierByMapName[map.ToLowerInvariant()] = new TierInfo
                    {
                        Tier = "S",
                        Color = Settings.TierColors.STierColor
                    };
                }

                foreach (var map in layoutTiers.ATier)
                {
                    _colorAndTierByMapName[map.ToLowerInvariant()] = new TierInfo
                    {
                        Tier = "A",
                        Color = Settings.TierColors.ATierColor
                    };
                }

                foreach (var map in layoutTiers.BTier)
                {
                    _colorAndTierByMapName[map.ToLowerInvariant()] = new TierInfo
                    {
                        Tier = "B",
                        Color = Settings.TierColors.BTierColor
                    };
                }

                foreach (var map in layoutTiers.CTier)
                {
                    _colorAndTierByMapName[map.ToLowerInvariant()] = new TierInfo
                    {
                        Tier = "C",
                        Color = Settings.TierColors.CTierColor
                    };
                }

                foreach (var map in layoutTiers.DTier)
                {
                    _colorAndTierByMapName[map.ToLowerInvariant()] = new TierInfo
                    {
                        Tier = "D",
                        Color = Settings.TierColors.DTierColor
                    };
                }

                foreach (var map in layoutTiers.FTier)
                {
                    _colorAndTierByMapName[map.ToLowerInvariant()] = new TierInfo
                    {
                        Tier = "F",
                        Color = Settings.TierColors.FTierColor
                    };
                }
            }
            catch (Exception e)
            {
                LogError("Failed to load layout tier list: " + e.StackTrace);
            }
        }

        private Color GetColor(string mapName)
        {
            if (!string.IsNullOrEmpty(mapName) && _colorAndTierByMapName != null &&
                _colorAndTierByMapName.TryGetValue(mapName.ToLowerInvariant(), out var tierAndColor))
            {
                return tierAndColor.Color;
            }
            return Color.White;
        }

        private string GetTier(string mapName)
        {
            if (!string.IsNullOrEmpty(mapName) && _colorAndTierByMapName != null &&
                _colorAndTierByMapName.TryGetValue(mapName.ToLowerInvariant(), out var tierAndColor))
            {
                return tierAndColor.Tier;
            }
            return string.Empty;
        }
    }
}