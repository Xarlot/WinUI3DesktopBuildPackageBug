using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Xml;
using NUnit.Engine;

namespace DevExpress.TestRunner {
    public static class WinUITestRunner {
        public static string Report => Listener.Builder.ToString();
        static readonly DummyTestEventListener Listener = new DummyTestEventListener();
        public static XmlNode DoWork(string assemblyName) {
            var assembly = AssemblyLoadContext.Default.Assemblies.First(x => x.GetName().Name == assemblyName);
            ITestEngine engine = TestEngineActivator.CreateInstance();
            TestPackage package = new TestPackage(assembly.Location);
            ITestRunner runner = engine.GetRunner(package);
            return runner.Run(Listener, TestFilter.Empty);
        }
    }

    public class DummyTestEventListener : ITestEventListener {
        public StringBuilder Builder { get; } = new StringBuilder();
        public void OnTestEvent(string report) {
            Builder.Append(report);
            Builder.AppendLine(" ");
        }
    }
}
