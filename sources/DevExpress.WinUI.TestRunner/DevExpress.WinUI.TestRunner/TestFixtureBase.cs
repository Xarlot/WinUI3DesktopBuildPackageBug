using NUnit.Framework;

namespace DevExpress.WinUI.TestRunner {
    [TestFixture]
    public class TestFixtureBase {
        [SetUp]
        public void SetUp() {
            SetUpCore();
        }
        protected virtual void SetUpCore() {
        }
        [TearDown]
        public void TearDown() {
            TearDownCore();
        }
        protected virtual void TearDownCore() {
            VisualTreeRoot.Content = null;
        }
    }
}