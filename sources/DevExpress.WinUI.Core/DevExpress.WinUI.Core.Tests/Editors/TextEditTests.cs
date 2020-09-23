using DevExpress.WinUI.TestRunner;
using Microsoft.UI.Xaml.Controls;
using NUnit.Framework;
using System.Threading;

namespace DevExpress.WinUI.Editors.Tests {

    [TestFixture]
    public class TextEditTests {
        [Test]
        public void Test() {
            TextEdit te = new() { EditValue = "123" };
            //TextBox te = new() { Text = "12" };
            VisualTreeRoot.Content = te;
            te.UpdateLayout();
        }
    }
}