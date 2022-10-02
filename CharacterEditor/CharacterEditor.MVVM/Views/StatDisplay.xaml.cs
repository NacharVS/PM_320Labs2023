using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace CharacterEditor.MVVM.Views;

public partial class StatDisplay : UserControl
{
    public StatDisplay()
    {
        InitializeComponent();
    }
    
    public double HealthValue
    {
        get => (double)GetValue(HealthProperty);
        set => SetValue(HealthProperty, value);
    }

    public static readonly DependencyProperty HealthProperty =
        DependencyProperty.Register("HealthValue", typeof(double),
            typeof(StatDisplay),
            new PropertyMetadata(default(double), OnCharValuePropertyChanged));

    private static void OnCharValuePropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        c.HealthTextBox.Text = c.HealthValue.ToString(CultureInfo.InvariantCulture);
    }
    
    public double ManaValue
    {
        get => (double)GetValue(ManaProperty);
        set => SetValue(ManaProperty, value);
    }

    public static readonly DependencyProperty ManaProperty =
        DependencyProperty.Register("ManaValue", typeof(double),
            typeof(StatDisplay),
            new PropertyMetadata(default(double), OnManaPropertyChanged));

    private static void OnManaPropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        c.ManaTextBox.Text = c.ManaValue.ToString(CultureInfo.InvariantCulture);
    }
    
    public double AttackValue
    {
        get => (double)GetValue(AttackProperty);
        set => SetValue(AttackProperty, value);
    }

    public static readonly DependencyProperty AttackProperty =
        DependencyProperty.Register("AttackValue", typeof(double),
            typeof(StatDisplay),
            new PropertyMetadata(default(double), OnAttackPropertyChanged));

    private static void OnAttackPropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        c.AttackTextBox.Text = c.AttackValue.ToString(CultureInfo.InvariantCulture);
    }
    
    public double MagicalAttackValue
    {
        get => (double)GetValue(MagicalAttackProperty);
        set => SetValue(MagicalAttackProperty, value);
    }

    public static readonly DependencyProperty MagicalAttackProperty =
        DependencyProperty.Register("MagicalAttackValue", typeof(double),
            typeof(StatDisplay),
            new PropertyMetadata(default(double), OnMagicalAttackPropertyChanged));

    private static void OnMagicalAttackPropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        c.MagicalAttackTextBox.Text = c.MagicalAttackValue.ToString(CultureInfo.InvariantCulture);
    }
    
    public double PhysicalResistValue
    {
        get => (double)GetValue(PhysicalResistProperty);
        set => SetValue(PhysicalResistProperty, value);
    }

    public static readonly DependencyProperty PhysicalResistProperty =
        DependencyProperty.Register("PhysicalResistValue", typeof(double),
            typeof(StatDisplay),
            new PropertyMetadata(default(double), OnPhysicalResistPropertyChanged));

    private static void OnPhysicalResistPropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        c.PhysicalResistTextBox.Text = c.PhysicalResistValue.ToString(CultureInfo.InvariantCulture);
    }
}