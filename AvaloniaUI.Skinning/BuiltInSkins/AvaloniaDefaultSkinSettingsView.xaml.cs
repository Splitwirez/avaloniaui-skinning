using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaUI.Skinning
{
    public class AvaloniaDefaultSkinSettingsView : UserControl
    {
        public AvaloniaDefaultSkinSettingsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}