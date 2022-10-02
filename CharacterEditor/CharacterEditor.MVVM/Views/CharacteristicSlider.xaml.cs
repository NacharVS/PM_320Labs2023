using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CharacterEditor.MVVM.Utils.Parameters;

namespace CharacterEditor.MVVM.Views;

public partial class CharacteristicSlider : UserControl
{
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register(
            "Command",
            typeof(ICommand),
            typeof(CharacteristicSlider),
            new PropertyMetadata(null, OnCommandPropertyChanged));

    private static void OnCommandPropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var control = d as CharacteristicSlider;
        if (control is null) return;

        control.PlusButton.Command = e.NewValue as ICommand;
        control.PlusButton.CommandParameter = new CharacteristicSliderParameters
            { ChangeValue = 1, Characteristic = control.CharName };

        control.MinusButton.Command = e.NewValue as ICommand;
        control.MinusButton.CommandParameter =
            new CharacteristicSliderParameters
            {
                ChangeValue = -1, Characteristic = control.CharName
            };
    }

    public CharacteristicSlider()
    {
        InitializeComponent();
    }

    public int CharValue
    {
        get => (int)GetValue(CharValueProperty);
        set => SetValue(CharValueProperty, value);
    }

    public static readonly DependencyProperty CharValueProperty =
        DependencyProperty.Register("CharValue", typeof(int),
            typeof(CharacteristicSlider),
            new PropertyMetadata(default(int), OnCharValuePropertyChanged));

    private static void OnCharValuePropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as CharacteristicSlider;
        if (c is null) return;

        c.CharacteristicValue.Content = c.CharValue.ToString();
    }

    public string CharName
    {
        get => (string)GetValue(CharNameProperty);
        set => SetValue(CharValueProperty, value);
    }

    public static readonly DependencyProperty CharNameProperty =
        DependencyProperty.Register("CharName", typeof(string),
            typeof(CharacteristicSlider),
            new PropertyMetadata(null, OnCharNamePropertyChanged));

    private static void OnCharNamePropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as CharacteristicSlider;
        if (c is null) return;

        c.CharacteristicName.Content = c.CharName;
    }
}