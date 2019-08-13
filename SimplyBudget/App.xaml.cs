using System.Globalization;
using System.Windows;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using SimplyBudget.Properties;

namespace SimplyBudget
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppCenter.LogLevel = LogLevel.Verbose;
            AppCenter.Start(Settings.Default.AppCenterKey, typeof(Analytics), typeof(Crashes));
        }
    }
}
