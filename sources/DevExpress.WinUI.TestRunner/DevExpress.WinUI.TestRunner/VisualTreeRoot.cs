using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace DevExpress.WinUI.TestRunner {
    public static class VisualTreeRoot {
        static Window? MainWindow { get; set; }
        static Border? Root { get; set; }
        public static void Initialize(Window window, Border root) {
            MainWindow = window;
            Root = root;
        }

        public static FrameworkElement? Content {
            get => (FrameworkElement?)Root?.Child;
            set { if (Root != null) Root.Child = value; }
        } 
    }
}