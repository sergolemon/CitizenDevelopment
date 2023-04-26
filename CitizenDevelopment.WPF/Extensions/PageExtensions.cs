using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CitizenDevelopment.WPF.Extensions
{
    internal static class PageExtensions
    {
        private static DoubleAnimation GetNotifyStandartAnimation()
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

        public static void ShowSuccessNotifyStandartAnimation(
            this Page page, 
            string successMessage)
        {
            var notify = ((MainWindow)Window.GetWindow(page)).Notify;

            notify.Text = successMessage;
            notify.Background = new SolidColorBrush(Color.FromRgb(90, 230, 90));

            notify.BeginAnimation(TextBlock.WidthProperty, GetNotifyStandartAnimation());
        }

        public static void ShowFailureNotifyStandartAnimation(
            this Page page,
            string failureMessage)
        {
            var notify = ((MainWindow)Window.GetWindow(page)).Notify;

            notify.Text = failureMessage;
            notify.Background = new SolidColorBrush(Color.FromRgb(250, 90, 90));

            notify.BeginAnimation(TextBlock.WidthProperty, GetNotifyStandartAnimation());
        }
    }
}
