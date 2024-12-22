using System.Drawing;

namespace ChildrenGardenInterface
{
    public static class Styles
    {
        public static Color MainBackgroundColor = Color.FromArgb(230, 240, 255); //lightblue
        public static Color SidePanelGradientStartColor = Color.FromArgb(230, 240, 255);
        public static Color SidePanelGradientEndColor = Color.FromArgb(200, 220, 255);
        public static Font MainFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point); // 10F
        public static Font ButtonFont = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point); // 10F
        public static Color ButtonBackColor = Color.FromArgb(100, 149, 237); 
        public static Color ButtonForeColor = Color.White;
        public static int ButtonWidth = 120;
        public static int ButtonHeight = 35;
        public static int ControlSpacing = 8;
    }
}