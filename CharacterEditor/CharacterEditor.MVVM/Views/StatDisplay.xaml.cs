using System;
using System.Windows;
using System.Windows.Controls;
using CharacterEditor.MVVM.Utils;

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
            new PropertyMetadata(default(double),
                OnHealthValuePropertyChanged));

    private static void OnHealthValuePropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        var additional = c.AdditionalHealthValue == 0
            ? ""
            : $"{ApplicationUtils.GetSign(c.AdditionalHealthValue)} {Math.Abs(c.AdditionalHealthValue)}";
        c.HealthTextBox.Text = $"{c.HealthValue} {additional}";
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

        var additional = c.AdditionalManaValue == 0
            ? ""
            : $"{ApplicationUtils.GetSign(c.AdditionalManaValue)} {Math.Abs(c.AdditionalManaValue)}";
        c.ManaTextBox.Text = $"{c.ManaValue} {additional}";
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

        var additional = c.AdditionalAttackValue == 0
            ? ""
            : $"{ApplicationUtils.GetSign(c.AdditionalAttackValue)} {Math.Abs(c.AdditionalAttackValue)}";
        c.AttackTextBox.Text = $"{c.AttackValue} {additional}";
    }

    public double MagicalAttackValue
    {
        get => (double)GetValue(MagicalAttackProperty);
        set => SetValue(MagicalAttackProperty, value);
    }

    public static readonly DependencyProperty MagicalAttackProperty =
        DependencyProperty.Register("MagicalAttackValue", typeof(double),
            typeof(StatDisplay),
            new PropertyMetadata(default(double),
                OnMagicalAttackPropertyChanged));

    private static void OnMagicalAttackPropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        var additional = c.AdditionalMagicalAttackValue == 0
            ? ""
            : $"{ApplicationUtils.GetSign(c.AdditionalMagicalAttackValue)} {Math.Abs(c.AdditionalMagicalAttackValue)}";
        c.MagicalAttackTextBox.Text = $"{c.MagicalAttackValue} {additional}";
    }

    public double PhysicalResistValue
    {
        get => (double)GetValue(PhysicalResistProperty);
        set => SetValue(PhysicalResistProperty, value);
    }

    public static readonly DependencyProperty PhysicalResistProperty =
        DependencyProperty.Register("PhysicalResistValue", typeof(double),
            typeof(StatDisplay),
            new PropertyMetadata(default(double),
                OnPhysicalResistPropertyChanged));

    private static void OnPhysicalResistPropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        var additional = c.AdditionalPhysicalResistValue == 0
            ? ""
            : $"{ApplicationUtils.GetSign(c.AdditionalPhysicalResistValue)} {Math.Abs(c.AdditionalPhysicalResistValue)}";
        c.PhysicalResistTextBox.Text = $"{c.PhysicalResistValue} {additional}";
    }

    public double AdditionalHealthValue
    {
        get => (double)GetValue(AdditionalHealthProperty);
        set => SetValue(AdditionalHealthProperty, value);
    }

    public static readonly DependencyProperty AdditionalHealthProperty =
        DependencyProperty.Register("AdditionalHealthValue", typeof(double),
            typeof(StatDisplay),
            new PropertyMetadata(default(double),
                OnAdditionalHealthValuePropertyChanged));

    private static void OnAdditionalHealthValuePropertyChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        var additional = c.AdditionalHealthValue == 0
            ? ""
            : $"{ApplicationUtils.GetSign(c.AdditionalHealthValue)} {Math.Abs(c.AdditionalHealthValue)}";
        c.HealthTextBox.Text = $"{c.HealthValue} {additional}";
    }

    public double AdditionalManaValue
    {
        get => (double)GetValue(AdditionalManaProperty);
        set => SetValue(AdditionalManaProperty, value);
    }

    public static readonly DependencyProperty AdditionalManaProperty =
        DependencyProperty.Register("AdditionalManaValue", typeof(double),
            typeof(StatDisplay),
            new PropertyMetadata(default(double),
                OnAdditionalManaPropertyChanged));

    private static void OnAdditionalManaPropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        var additional = c.AdditionalManaValue == 0
            ? ""
            : $"{ApplicationUtils.GetSign(c.AdditionalManaValue)} {Math.Abs(c.AdditionalManaValue)}";
        c.ManaTextBox.Text = $"{c.ManaValue} {additional}";
    }

    public double AdditionalAttackValue
    {
        get => (double)GetValue(AdditionalAttackProperty);
        set => SetValue(AdditionalAttackProperty, value);
    }

    public static readonly DependencyProperty AdditionalAttackProperty =
        DependencyProperty.Register("AdditionalAttackValue", typeof(double),
            typeof(StatDisplay),
            new PropertyMetadata(default(double),
                OnAdditionalAttackPropertyChanged));

    private static void OnAdditionalAttackPropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        var additional = c.AdditionalAttackValue == 0
            ? ""
            : $"{ApplicationUtils.GetSign(c.AdditionalAttackValue)} {Math.Abs(c.AdditionalAttackValue)}";
        c.AttackTextBox.Text = $"{c.AttackValue} {additional}";
    }

    public double AdditionalMagicalAttackValue
    {
        get => (double)GetValue(AdditionalMagicalAttackProperty);
        set => SetValue(AdditionalMagicalAttackProperty, value);
    }

    public static readonly DependencyProperty AdditionalMagicalAttackProperty =
        DependencyProperty.Register("AdditionalMagicalAttackValue", typeof(double),
            typeof(StatDisplay),
            new PropertyMetadata(default(double),
                OnAdditionalMagicalAttackPropertyChanged));

    private static void OnAdditionalMagicalAttackPropertyChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        var additional = c.AdditionalMagicalAttackValue == 0
            ? ""
            : $"{ApplicationUtils.GetSign(c.AdditionalMagicalAttackValue)} {Math.Abs(c.MagicalAttackValue)}";
        c.MagicalAttackTextBox.Text = $"{c.MagicalAttackValue} {additional}";
    }

    public double AdditionalPhysicalResistValue
    {
        get => (double)GetValue(AdditionalPhysicalResistProperty);
        set => SetValue(AdditionalPhysicalResistProperty, value);
    }

    public static readonly DependencyProperty AdditionalPhysicalResistProperty =
        DependencyProperty.Register("AdditionalPhysicalResistValue", typeof(double),
            typeof(StatDisplay),
            new PropertyMetadata(default(double),
                OnAdditionalPhysicalResistPropertyChanged));

    private static void OnAdditionalPhysicalResistPropertyChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var c = d as StatDisplay;
        if (c is null) return;

        var additional = c.AdditionalPhysicalResistValue == 0
            ? ""
            : $"{ApplicationUtils.GetSign(c.AdditionalPhysicalResistValue)} {Math.Abs(c.AdditionalPhysicalResistValue)}";
        c.PhysicalResistTextBox.Text = $"{c.PhysicalResistValue} {additional}";
    }
}