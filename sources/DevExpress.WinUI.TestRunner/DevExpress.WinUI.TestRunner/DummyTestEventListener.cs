using System.Text;
using NUnit.Engine;

namespace DevExpress.WinUI.TestRunner {
    public class DummyTestEventListener : ITestEventListener {
        public StringBuilder Builder { get; } = new StringBuilder();
        public void OnTestEvent(string report) {
            Builder.Append(report);
            Builder.AppendLine(" ");
        }
    }
}
