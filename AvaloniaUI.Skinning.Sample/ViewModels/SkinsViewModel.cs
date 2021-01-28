using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AvaloniaUI.Skinning;


namespace AvaloniaUI.Skinning.Sample.ViewModels
{
    public class SkinsViewModel : INotifyPropertyChanged
    {
        public SkinManager SkinManager { get; set; } = new SkinManager(true);
        
        
        ISkin _selectedSkin = null;
        
        public ISkin SelectedSkin 
        {
            get => _selectedSkin;
            set
            {
                _selectedSkin = value;
                NotifyPropertyChanged();
            }
        }

        public void ApplySkinCommand(object parameter)
        {
            if ((parameter != null) && (parameter is ISkin skin))
                SkinManager.ApplySkin(skin);
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}