using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml.Controls;

namespace DevExpress.WinUI.TestRunner {
    public sealed class RootControl : Control, INotifyPropertyChanged {
        public RootControl() {
            DefaultStyleKey = typeof(RootControl);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
        }

        string? content;
        public string? Content {
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
