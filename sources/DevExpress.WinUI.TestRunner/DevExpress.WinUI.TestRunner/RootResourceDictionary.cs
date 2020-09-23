using Microsoft.UI.Xaml;
using System;

namespace DevExpress.WinUI.TestRunner {
    public partial class RootResourceDictionary : ResourceDictionary {
        public RootResourceDictionary() {
            Source = new Uri("ms-appx:///DevExpress.WinUI.TestRunner/Themes/RootControl.xaml");
            InitializeComponent();
        }
    }
}