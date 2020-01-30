﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.DualScreen
{
    public static class WindowHelper
    {
        static IDualScreenService DualScreenService => (DependencyService.Get<IDualScreenService>() ?? NoDualScreenServiceImpl.Instance);
        public static bool HasCompactModeSupport()
        {
            return DualScreenService.HasCompactModeSupport(); ;
        }

        public static Task<CompactModeArgs> OpenCompactMode(ContentPage contentPage)
        {
            return DualScreenService.OpenCompactMode(contentPage);
        }

        public static Rectangle[] GetSpanningRects()
        {
            var guide = TwoPaneViewLayoutGuide.Instance;
            var hinge = guide.Hinge;
            guide.UpdateLayouts();

            if (hinge == Rectangle.Zero)
                return new Rectangle[0];

            if(guide.Pane2 == Rectangle.Zero)
                return new Rectangle[0];

            return new []{ guide.Pane1, guide.Pane2 };
        }

        public static Rectangle GetHingeRect()
        {
            var guide = TwoPaneViewLayoutGuide.Instance;
            guide.UpdateLayouts();
            return guide.Hinge;
        }
    }
}
