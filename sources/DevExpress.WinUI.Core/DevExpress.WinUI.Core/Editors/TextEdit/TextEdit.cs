using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace DevExpress.WinUI.Editors {
    public class TextEdit : Control, INotifyPropertyChanged {
        public static readonly DependencyProperty TextBoxStyleProperty;
        public static readonly DependencyProperty AcceptsReturnProperty;
        public static readonly DependencyProperty CharacterCasingProperty;
        public static readonly DependencyProperty IsReadOnlyProperty;
        public static readonly DependencyProperty MaxLengthProperty;
        public static readonly DependencyProperty TextAlignmentProperty;
        public static readonly DependencyProperty TextWrappingProperty;
        public static readonly DependencyProperty TextProperty;
        public static readonly DependencyProperty EditValueProperty;

        static TextEdit() {
            var ownerType = typeof(TextEdit);
            TextBoxStyleProperty = DependencyProperty.Register(nameof(TextBoxStyle), typeof(Style), ownerType, new PropertyMetadata(null));
            AcceptsReturnProperty = DependencyProperty.Register(nameof(AcceptsReturn), typeof(bool), ownerType, PropertyMetadata.Create(false));
            CharacterCasingProperty = DependencyProperty.Register(nameof(CharacterCasing), typeof(CharacterCasing), ownerType, PropertyMetadata.Create(CharacterCasing.Normal));
            IsReadOnlyProperty = DependencyProperty.Register(nameof(IsReadOnly), typeof(bool), ownerType, PropertyMetadata.Create(false));
            MaxLengthProperty = DependencyProperty.Register(nameof(MaxLength), typeof(int), ownerType, PropertyMetadata.Create(-1));
            TextAlignmentProperty = DependencyProperty.Register(nameof(TextAlignment), typeof(TextAlignment), ownerType, PropertyMetadata.Create(TextAlignment.Left));
            TextWrappingProperty = DependencyProperty.Register(nameof(TextWrapping), typeof(TextWrapping), ownerType, PropertyMetadata.Create(TextWrapping.Wrap));
            TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), ownerType, new PropertyMetadata(null));
            EditValueProperty = DependencyProperty.Register(nameof(EditValue), typeof(object), ownerType, new PropertyMetadata(null, (d, e) => ((TextEdit)d).EditValueChanged(e.OldValue, e.NewValue)));
        }

        string? displayText;
        object? editCore;

        public bool AcceptsReturn {
            get => (bool)GetValue(AcceptsReturnProperty);
            set => SetValue(AcceptsReturnProperty, value);
        }
        public CharacterCasing CharacterCasing {
            get => (CharacterCasing)GetValue(CharacterCasingProperty);
            set => SetValue(CharacterCasingProperty, value);
        }
        public bool IsReadOnly {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }
        public int MaxLength {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }
        public TextAlignment TextAlignment {
            get => (TextAlignment)GetValue(TextAlignmentProperty);
            set => SetValue(TextAlignmentProperty, value);
        }
        public TextWrapping TextWrapping {
            get => (TextWrapping)GetValue(TextWrappingProperty);
            set => SetValue(TextWrappingProperty, value);
        }
        public Style TextBoxStyle {
            get => (Style)GetValue(TextBoxStyleProperty);
            set => SetValue(TextBoxStyleProperty, value);
        }
        public string Text {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public object EditValue {
            get => GetValue(EditValueProperty);
            set => SetValue(EditValueProperty, value);
        }

        public object? EditCore {
            get => this.editCore;
            private set => this.editCore = value;
        }
        public string? DisplayText {
            get => this.displayText;
            private set {
                if (this.displayText == value)
                    return;
                this.displayText = value;
                OnPropertyChanged();
            }
        }

        public TextEdit() {
            DefaultStyleKey = typeof(TextEdit);
        }

        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
            EditCore = GetTemplateChild("PART_Editor");
        }

        protected virtual void EditValueChanged(object oldValue, object newValue) {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}