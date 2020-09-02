using Avalonia.Controls;
using Avalonia.Styling;
using Avalonia.Markup.Xaml.Styling;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaUI.Skinning
{
    public class FluentSkin : ISkin
    {
        public bool HasSettings => true;

        FluentSkinSettings _settings = new FluentSkinSettings();
        public object Settings => _settings;

        FluentSkinSettingsView _settingsView = null;
        public UserControl SettingsView => _settingsView;

        string _displayName = "Fluent";
        public string DisplayName
        {
            get => _displayName;
            set {}
        }

        public IStyle GetStyles()
        {
            var styles = new Styles();
            
            Uri lightsUri = new Uri(@"avares://Avalonia.Themes.Fluent/Accents/FluentLight.xaml");
            
            if (_settings.IsDarkTheme)
                lightsUri = new Uri(@"avares://Avalonia.Themes.Fluent/Accents/FluentDark.xaml");
            
            styles.Add(new StyleInclude(lightsUri)
            {
                Source = lightsUri
            });

            if (_settings.CompactDensity)
            {
                Uri densityUri = new Uri(@"avares://Avalonia.Themes.Fluent/DensityStyles/Compact.xaml");
                styles.Add(new StyleInclude(densityUri)
                {
                    Source = densityUri
                });
            };

            return styles;
        }

        public FluentSkin()
        {
            _settingsView = new FluentSkinSettingsView()
            {
                DataContext = Settings
            };
        }
    }

    public class FluentSkinSettings : INotifyPropertyChanged
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
        bool _compactDensity = false;
        public bool CompactDensity
        {
            get => _compactDensity;
            set
            {
                _compactDensity = value;
                NotifyPropertyChanged();
            }
        }


        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}