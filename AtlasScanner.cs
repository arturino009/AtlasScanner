using System.Drawing;
using System.Numerics;
using ExileCore2;
using ExileCore2.Shared.Enums;

namespace AtlasScanner
{

    public partial class AtlasScanner : BaseSettingsPlugin<AtlasScannerSettings>
    {
        public override bool Initialise()
        {
            LoadLayoutTierList();
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
                    bool unlocked = mapElement.IsUnlocked;
                    bool visited = mapElement.IsVisited;
                    var leagueMechanic = mapElement.Children[0].Children;
                    if (Settings.ShowOnlyAvailable && (!unlocked != visited)) continue;
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
                                //case var _ when texture.Contains("AtlasIconContentTrader"):
                                //    if (Settings.ShowTrader) finalColor = Settings.TraderColor;
                                //    traderMaps++;
                                //    break;
                            }
                            if (finalColor != Color.Transparent)
                            {
                                Graphics.DrawFrame(mechanic.GetClientRect(), finalColor, Settings.FrameThickness.Value);
                            }
                        }
                    }
                    // Citadel drawing
                    if (Settings.ShowCitadel && mapName.Contains("Citadel") && !visited)
                    {
                        Graphics.DrawFrame(mapElement.GetClientRect(), Settings.CitadelColor, Settings.FrameThickness.Value);
                        citadelMaps++;
                        if (Settings.DrawLine) Graphics.DrawLine(GameController.Window.GetWindowRectangleTimeCache.Center, mapElement.GetClientRect().Center, Settings.FrameThickness, Settings.CitadelColor);
                    }
                    // Trader drawing
                    if (Settings.ShowTrader && mapName == "Moment of Zen" && !visited)
                    {
                        Graphics.DrawFrame(mapElement.GetClientRect(), Settings.TraderColor, Settings.FrameThickness.Value);
                        traderMaps++;
                        if (Settings.DrawLine) Graphics.DrawLine(GameController.Window.GetWindowRectangleTimeCache.Center, mapElement.GetClientRect().Center, Settings.FrameThickness, Settings.TraderColor);
                    }
                    // Map name drawing
                    if (Settings.MapNames  && !(unlocked && visited)) Graphics.DrawTextWithBackground(mapName, mapElement.GetClientRect().Center, GetColor(mapName), FontAlign.Center, Color.Black);
                    // Not attempted map drawing
                    if (Settings.ShowOnlyNotAttempted && !visited && unlocked)
                    {
                        Graphics.DrawFrame(mapElement.GetClientRect(), GetColor(mapName), Settings.FrameThickness.Value);
                    }
                }
                var rect = new Vector2(10, 50);
                int offset = 15;
                if (Settings.ShowCitadel)
                {
                    Graphics.DrawTextWithBackground("Found " + citadelMaps + " citadel maps", rect, Color.Green, Color.Black);
                }
                if (Settings.ShowTrader)
                {
                    Graphics.DrawTextWithBackground("Found " + traderMaps + " trader maps", new Vector2(rect.X, rect.Y += offset), Color.Green, Color.Black);
                }
            }
        }
    }
}