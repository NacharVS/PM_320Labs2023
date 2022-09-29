using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CharacterEditor.WPF.Components;

public partial class CharacteristicSlider : UserControl
{
    public int SliderValue { get; set; }

    public CharacteristicSlider()
    {
        InitializeComponent();
        CharacteristicValue.Content = SliderValue.ToString();
        PlusButton.Click += (_, _) => { SliderValue++; };

        MinusButton.Click += (_, _) => { SliderValue--; };
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        CharacteristicValue.Content = SliderValue.ToString();
    }

    public static CharacteristicSlider? TryGetSliderByButton(Button btn)
    {
        return (btn.Parent as Grid)?.Parent as CharacteristicSlider;
    }

    public static readonly DependencyProperty CharName =
        DependencyProperty.Register("CharName", typeof(string),
            typeof(CharacteristicSlider));

    public static string GetCharName(UIElement target) =>
        (string)target.GetValue(CharName);

    public static void SetCharName(UIElement target, string value) =>
        target.SetValue(CharName, value);
}