using Avalonia.Controls;
using Avalonia.Styling;
using System;

namespace AvaloniaUI.Skinning
{
    public interface ISkin
    {
        public IStyle GetStyles();

        public bool HasSettings { get; }

        public object Settings { get; }

        public UserControl SettingsView { get; }

        public string DisplayName { get; set; }
    }
}