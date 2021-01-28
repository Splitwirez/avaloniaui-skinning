using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaUI.Skinning;

namespace AvaloniaUI.Skinning.Sample.Views
{
    public class MainWindow : Window
    {
        //public SkinManager SkinManager => DataContext as SkinManager;
        public MainWindow()
        {
            InitializeComponent();
        }

        ListBox _skinsListBox = null;

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            /*_skinsListBox = this.Find<ListBox>("SkinsListBox");
            _skinsListBox.SelectedIndex = 0;
            ApplySelectedSkin();
            this.Find<Button>("ApplyButton").Click += (sneder, args) => ApplySelectedSkin();*/
        }

        //void ApplySelectedSkin() => (Application.Current as App).SkinManager.ApplySkin(_skinsListBox.SelectedIndex);
    }
}