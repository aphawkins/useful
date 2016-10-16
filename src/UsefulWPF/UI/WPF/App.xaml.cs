﻿namespace Useful.UI.WPF
{
    using Security.Cryptography;
    using System.Windows;
    using ViewModels;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CryptographyWindow app = new CryptographyWindow();
            ICipherRepository repository = new CipherRepository();
            CipherViewModel context = new CipherViewModel(repository);
            app.DataContext = context;
            app.Show();
        }
    }
}