using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Globalization;
namespace Assistenze
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() { }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

           CultureInfo cultureInfo = new CultureInfo("it-IT");
            DateTimeFormatInfo dtfInfo = new DateTimeFormatInfo();

            dtfInfo.DateSeparator = "/";
            dtfInfo.LongDatePattern = "dd/MM/yyyy";
            dtfInfo.ShortDatePattern = "dd/MM/yy";
            dtfInfo.LongTimePattern = "hh:mm:ss tt";
            dtfInfo.ShortTimePattern = "hh:mm";
            cultureInfo.DateTimeFormat = dtfInfo;

            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(System.Windows.Markup.XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));



        }
    }
}
