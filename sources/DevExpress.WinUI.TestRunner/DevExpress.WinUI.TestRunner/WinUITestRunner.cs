using System.Diagnostics;
using System.Linq;
using System.Runtime.Loader;
using System.Xml;
using NUnit;
using NUnit.Engine;

namespace DevExpress.WinUI.TestRunner {
    public static class WinUITestRunner {
        public static string Report => Listener.Builder.ToString();
        static readonly DummyTestEventListener Listener = new DummyTestEventListener();
        public static XmlNode DoWork(string assemblyName) {
            var assembly = AssemblyLoadContext.Default.Assemblies.First(x => x.GetName().Name == assemblyName);
            ITestEngine engine = TestEngineActivator.CreateInstance();
            TestPackage package = new TestPackage(assembly.Location);
            package.Settings[FrameworkPackageSettings.RunOnMainThread] = true;
            ITestRunner runner = engine.GetRunner(package);
            return runner.Run(Listener, TestFilter.Empty);
        }
    }
}