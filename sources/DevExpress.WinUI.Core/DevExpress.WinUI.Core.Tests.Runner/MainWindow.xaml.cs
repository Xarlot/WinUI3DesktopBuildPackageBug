using Microsoft.UI.Xaml;
using DevExpress.WinUI.TestRunner;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DevExpress.WinUI.Core.Tests.Runner
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        Stopwatch sw = Stopwatch.StartNew();
        public MainWindow()
        {
            this.InitializeComponent();
            RootUI.Loaded += Root_Loaded;
        }
        private void Root_Loaded(object sender, RoutedEventArgs e) {
            VisualTreeRoot.Initialize(this, RootUI);
            WinUITestRunner.DoWork(typeof(Initializer).Assembly.GetName().Name);

            TestUI.Content = WinUITestRunner.Report;
        }
    }

}
