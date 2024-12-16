using System.Drawing;
using System.Numerics;
using ExileCore2;
using ExileCore2.Shared.Enums;

namespace AtlasScanner
{
    public class AtlasScanner : BaseSettingsPlugin<AtlasScannerSettings>
    {
        public override bool Initialise()
        {
            return true;
        }


        public override void Render()
        {
            var atlasPanel = GameController.Game.IngameState.IngameUi.WorldMap.AtlasPanel;
            int uniqueMaps = 0;
            int citadelMaps = 0;
            int traderMaps = 0;
            if (atlasPanel.IsVisible)
            {
                var maps = atlasPanel.Descriptions;
                foreach (var tile in maps)
                {
                    var mapElement = tile.Element;
                    string mapName = mapElement.Area.Name;
                    bool currentlyAvailable = mapElement.IsUnlocked;
                    bool completed = mapElement.IsVisited;
                    var leagueMechanic = mapElement.Children[0].Children;
                    if (Settings.ShowOnlyAvailable && !currentlyAvailable) continue;
                    if (leagueMechanic.Count > 0)
                    {
                        foreach (var mechanic in leagueMechanic)
                        {
                            string texture = mechanic.TextureName;
                            Color finalColor = Color.Transparent;
                            switch (texture)
                            {
                                case var _ when texture.Contains("AtlasIconContentMapBoss"):
                                    if (Settings.ShowBoss) finalColor = Settings.BossColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentBreach"):
                                    if (Settings.ShowBreach) finalColor = Settings.BreachColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentExpedition"):
                                    if (Settings.ShowExpedition) finalColor = Settings.ExpeditionColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentRitual"):
                                    if (Settings.ShowRitual) finalColor = Settings.RitualColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentDelirium"):
                                    if (Settings.ShowDelirium) finalColor = Settings.DeliriumColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentCorruption"):
                                    if (Settings.ShowCorruption) finalColor = Settings.CorruptionColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentIrradiated"):
                                    if (Settings.ShowIrradiated) finalColor = Settings.IrradiatedColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentUniqueMap"):
                                    if (Settings.ShowUnique) finalColor = Settings.UniqueColor;
                                    uniqueMaps++;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentHideout"):
                                    if (Settings.ShowHideout) finalColor = Settings.HideoutColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentTrader"):
                                    if (Settings.ShowTrader) finalColor = Settings.TraderColor;
                                    traderMaps++;
                                    break;
                                default:
                                    if (Settings.ShowOther) finalColor = Settings.OtherColor;
                                    break;
                            }
                            if (finalColor != Color.Transparent) Graphics.DrawFrame(mechanic.GetClientRect(), finalColor, Settings.FrameThickness.Value);
                        }
                    }
                    if (!completed && Settings.ShowCitadel && (mapName.Contains("citadel")))
                    {
                        Graphics.DrawFrame(mapElement.GetClientRect(), Settings.CitadelColor, Settings.FrameThickness.Value);
                        citadelMaps++;
                    }
                    if (!completed && Settings.MapNames) Graphics.DrawTextWithBackground(mapName, mapElement.GetClientRect().Center, Color.White, FontAlign.Center, Color.Black);
                }
                var rect = new Vector2(10, 50);
                var rect1 = new Vector2(10, 70);
                var rect2 = new Vector2(10, 90);
                //Graphics.DrawTextWithBackground("Found " + uniqueMaps + " unique maps", rect, Color.Green, Color.Black);
                if (Settings.ShowTrader) Graphics.DrawTextWithBackground("Found " + traderMaps + " trader maps", rect1, Color.Green, Color.Black);
                //Graphics.DrawTextWithBackground("Found " + citadelMaps + " citadel maps", rect2, Color.Green, Color.Black);
            }
        }
    }
}