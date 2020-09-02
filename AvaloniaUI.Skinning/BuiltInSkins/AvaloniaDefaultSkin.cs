using Avalonia.Controls;
using Avalonia.Styling;
using Avalonia.Markup.Xaml.Styling;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaUI.Skinning
{
    public class AvaloniaDefaultSkin : ISkin
    {
        public bool HasSettings => true;

        AvaloniaDefaultSkinSettings _settings = new AvaloniaDefaultSkinSettings();
        public object Settings => _settings;

        AvaloniaDefaultSkinSettingsView _settingsView = null;
        public UserControl SettingsView => _settingsView;

        public IStyle GetStyles()
        {
            var styles = new Styles();
            
            Uri themeUri = new Uri(@"avares://Avalonia.Themes.Default/DefaultTheme.xaml");
            styles.Add(new StyleInclude(themeUri)
            {
                Source = themeUri
            });
            
            Uri lightsUri = new Uri(@"avares://Avalonia.Themes.Default/Accents/BaseLight.xaml");
            
            if (_settings.IsDarkTheme)
                lightsUri = new Uri(@"avares://Avalonia.Themes.Default/Accents/BaseDark.xaml");
            
            styles.Add(new StyleInclude(lightsUri)
            {
                Source = lightsUri
            });

            return styles;
        }

        string _displayName = "Avalonia \"Default\" Theme";
        public string DisplayName
        {
            get => _displayName;
            set {}
        }

        public AvaloniaDefaultSkin()
        {
            _settingsView = new AvaloniaDefaultSkinSettingsView()
            {
                DataContext = Settings
            };
        }
    }

    public class AvaloniaDefaultSkinSettings : INotifyPropertyChanged
    {
        bool _isDarkTheme = false;
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                _isDarkTheme = value;
                NotifyPropertyChanged();
            }
        }


        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}