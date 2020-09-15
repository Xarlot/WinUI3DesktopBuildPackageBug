using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DevExpress.TestRunner {
    public sealed class RootControl : Control, INotifyPropertyChanged {
        public RootControl() {
            this.DefaultStyleKey = typeof(RootControl);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        object content;
        public object Content {
            get => this.content;
            set {
                if (ReferenceEquals(this.content, value))
                    return;
                this.content = value;
                OnPropertyChanged();
            }
        }
    }
}
