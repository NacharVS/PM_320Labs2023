using System.Windows.Controls;
using CharacterEditor.MVVM.ViewModels.Base;

namespace CharacterEditor.MVVM.Utils;

public static class PageExtensions
{
    public static ViewModel GetViewModel(this Page page)
    {
        return (ViewModel)page.DataContext;
    }
}