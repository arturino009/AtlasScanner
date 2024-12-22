using System.Drawing;
using System.Numerics;
using AtlasScanner.Settings;
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
                    string mapTier = GetTier(mapName);
                    bool unlocked = mapElement.IsUnlocked;
                    bool visited = mapElement.IsVisited;
                    var leagueMechanic = mapElement.Children[0].Children;
                    if (Settings.GeneralSettings.ShowOnlyAvailable && (!unlocked != visited)) continue;
                    if (leagueMechanic.Count > 0)
                    {
                        foreach (var mechanic in leagueMechanic)
                        {
                            string texture = mechanic.TextureName;
                            Color finalColor = Color.Transparent;
                            switch (texture)
                            {
                                case var _ when texture.Contains("AtlasIconContentMapBoss"):
                                    if (Settings.HighlightToggles.ShowBoss) finalColor = Settings.HighlightColors.BossColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentBreach"):
                                    if (Settings.HighlightToggles.ShowBreach) finalColor = Settings.HighlightColors.BreachColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentExpedition"):
                                    if (Settings.HighlightToggles.ShowExpedition) finalColor = Settings.HighlightColors.ExpeditionColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentRitual"):
                                    if (Settings.HighlightToggles.ShowRitual) finalColor = Settings.HighlightColors.RitualColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentDelirium"):
                                    if (Settings.HighlightToggles.ShowDelirium) finalColor = Settings.HighlightColors.DeliriumColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentCorruption"):
                                    if (Settings.HighlightToggles.ShowCorruption) finalColor = Settings.HighlightColors.CorruptionColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentIrradiated"):
                                    if (Settings.HighlightToggles.ShowIrradiated) finalColor = Settings.HighlightColors.IrradiatedColor;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentUniqueMap"):
                                    if (Settings.HighlightToggles.ShowUnique) finalColor = Settings.HighlightColors.UniqueColor;
                                    uniqueMaps++;
                                    break;
                                case var _ when texture.Contains("AtlasIconContentHideout"):
                                    if (Settings.HighlightToggles.ShowHideout) finalColor = Settings.HighlightColors.HideoutColor;
                                    break;
                                    //case var _ when texture.Contains("AtlasIconContentTrader"):
                                    //    if (Settings.ShowTrader) finalColor = Settings.TraderColor;
                                    //    traderMaps++;
                                    //    break;
                            }
                            if (finalColor != Color.Transparent)
                            {
                                Graphics.DrawFrame(mechanic.GetClientRect(), finalColor, Settings.GeneralSettings.FrameThickness.Value);
                            }
                        }
                    }
                    // Citadel drawing
                    if (Settings.HighlightToggles.ShowCitadel && mapName.Contains("Citadel") && !visited)
                    {
                        Graphics.DrawFrame(mapElement.GetClientRect(), Settings.HighlightColors.CitadelColor, Settings.GeneralSettings.FrameThickness.Value);
                        citadelMaps++;
                        if (Settings.GeneralSettings.DrawLine) 
                            Graphics.DrawLine(GameController.Window.GetWindowRectangleTimeCache.Center, mapElement.GetClientRect().Center, Settings.GeneralSettings.FrameThickness, Settings.HighlightColors.CitadelColor);
                    }
                    // Trader drawing
                    if (Settings.HighlightToggles.ShowTrader && mapName == "Moment of Zen" && !visited)
                    {
                        Graphics.DrawFrame(mapElement.GetClientRect(), Settings.HighlightColors.TraderColor, Settings.GeneralSettings.FrameThickness.Value);
                        traderMaps++;
                        if (Settings.GeneralSettings.DrawLine) Graphics.DrawLine(GameController.Window.GetWindowRectangleTimeCache.Center, mapElement.GetClientRect().Center, Settings.GeneralSettings.FrameThickness, Settings.HighlightColors.TraderColor);
                    }

                    // Map name drawing
                    if (Settings.GeneralSettings.MapNames && !(unlocked && visited) && GetTier(mapName) != "")
                    {
                        Graphics.DrawTextWithBackground(mapName + " (" + mapTier + ")", mapElement.GetClientRect() .Center, GetColor(mapName), FontAlign.Center, Color.Black);
                    }
                    
                    // Map name drawing
                    if (Settings.GeneralSettings.MapNames && !(unlocked && visited) && GetTier(mapName) == "")
                    {
                        Graphics
                            .DrawTextWithBackground(mapName, mapElement.GetClientRect()
                            .Center, GetColor(mapName), FontAlign.Center, Color.Black);
                    }

                    // Not attempted map drawing
                    if (Settings.GeneralSettings.ShowOnlyNotAttempted && !visited && unlocked)
                    {
                        Graphics.DrawFrame(mapElement.GetClientRect(), GetColor(mapName), Settings.GeneralSettings.FrameThickness.Value);
                    }
                }
                var rect = new Vector2(10, 50);
                int offset = 15;
                if (Settings.HighlightToggles.ShowCitadel)
                {
                    Graphics.DrawTextWithBackground("Found " + citadelMaps + " citadel maps", rect, Color.Green, Color.Black);
                }
                if (Settings.HighlightToggles.ShowTrader)
                {
                    Graphics.DrawTextWithBackground("Found " + traderMaps + " trader maps", new Vector2(rect.X, rect.Y += offset), Color.Green, Color.Black);
                }
            }
        }
    }
}