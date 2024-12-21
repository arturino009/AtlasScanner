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
    public class GeneralSettings
    {
        // General Settings
        public RangeNode<int> FrameThickness { get; set; } = new RangeNode<int>(2, 1, 20);
        public EmptyNode Space { get; set; } = new EmptyNode();
        [Menu("Draw map names")]
        public ToggleNode MapNames { get; set; } = new ToggleNode(false);
        [Menu("Only highlight currently available maps")]
        public ToggleNode ShowOnlyAvailable { get; set; } = new ToggleNode(false);
        [Menu("Higlight currently available maps that have not been attempted")]
        public ToggleNode ShowOnlyNotAttempted { get; set; } = new ToggleNode(false);
        [Menu("Draw line to important tiles")]
        public ToggleNode DrawLine { get; set; } = new ToggleNode(false);

    }
}
