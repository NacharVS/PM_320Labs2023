using System.Globalization;
using System.Windows.Controls;
using CharacterEditor.Core;

namespace CharacterEditor.WPF.Components;

public partial class StatDisplay : UserControl
{
    public StatDisplay()
    {
        InitializeComponent();
    }

    public void UpdateValues(Character character)
    {
        HealthTextBox.Text = character.Health.ToString(CultureInfo.InvariantCulture);
        AttackTextBox.Text = character.AttackDamage.ToString(CultureInfo.InvariantCulture);
        MagicalAttackTextBox.Text = character.MagicalAttackDamage.ToString(CultureInfo.InvariantCulture);
        ManaTextBox.Text = character.Mana.ToString(CultureInfo.InvariantCulture);
        PhysicalResistTextBox.Text = character.PhysicalResistance.ToString(CultureInfo.InvariantCulture);
    }
}