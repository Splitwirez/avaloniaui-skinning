using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace AvaloniaUI.Skinning.Sample
{
    public class App : Application
    {
        public SkinManager SkinManager = new SkinManager(true);
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow()
                {
                    DataContext = SkinManager
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
   }
}