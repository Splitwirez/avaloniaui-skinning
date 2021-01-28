using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;
using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace AvaloniaUI.Skinning
{
    public class SkinManager : INotifyPropertyChanged
    {
        ObservableCollection<ISkin> _skins = new ObservableCollection<ISkin>();
        public ObservableCollection<ISkin> Skins
        {
            get => _skins;
            set
            {
                _skins = value;
                NotifyPropertyChanged();
            }
        }


        ISkin _fallbackSkin = null;
        public ISkin FallbackSkin
        {
            get => _fallbackSkin;
            set
            {
                _fallbackSkin = value;
                NotifyPropertyChanged();
            }
        }

        public void ApplySkin(int index)
        {
            if ((index >= 0) && (index < Skins.Count))
                ApplySkin(Skins[index]);
        }

        public void ApplySkin(ISkin skin)
        {
            Application.Current.Styles.Clear();
            
            if (FallbackSkin != null)
                Application.Current.Styles.Add(FallbackSkin.GetStyles());
            
            
            if ((skin != null) && (Skins.Contains(skin)))
            {
                Application.Current.Styles.Add(skin.GetStyles());
            }
        }

        public SkinManager(bool useAvaloniaBuiltInThemeSkins = true)
        {
            if (useAvaloniaBuiltInThemeSkins)
            {
                Skins.Add(new FluentSkin());
                Skins.Add(new AvaloniaDefaultSkin());
            }

            var skn = Skins.FirstOrDefault();
            if (skn != null)
                ApplySkin(skn);
        }

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
