using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CitizenDevelopment.WPF.Extensions
{
    internal static class PageExtensions
    {
        public static DoubleAnimation GetNotifyStandartAnimation(this Page page)
        {
            var easing = new CircleEase();
            easing.EasingMode = EasingMode.EaseOut;

            DoubleAnimation notifyAnimation = new DoubleAnimation();
            notifyAnimation.From = 0;
            notifyAnimation.To = 190;
            notifyAnimation.AutoReverse = true;
            notifyAnimation.EasingFunction = easing;
            notifyAnimation.Duration = TimeSpan.FromSeconds(1.2);

            return notifyAnimation;
        }
    }
}
