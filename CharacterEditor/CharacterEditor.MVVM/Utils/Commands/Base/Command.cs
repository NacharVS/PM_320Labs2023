using System;
using System.Windows.Input;

namespace CharacterEditor.MVVM.Utils.Commands.Base;

public abstract class Command : ICommand
{
    public abstract bool CanExecute(object? parameter);

    public abstract void Execute(object? parameter);

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}