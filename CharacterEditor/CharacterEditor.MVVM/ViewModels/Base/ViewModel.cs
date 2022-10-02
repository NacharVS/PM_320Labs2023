using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CharacterEditor.MVVM.ViewModels.Base;

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value,
        [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    protected bool OnPropertyUpdate([CallerMemberName] string? propertyName = null)
    {
        OnPropertyChanged(propertyName);
        return true;
    }
}