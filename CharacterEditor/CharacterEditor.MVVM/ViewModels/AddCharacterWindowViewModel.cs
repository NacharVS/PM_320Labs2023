using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CharacterEditor.Core;
using CharacterEditor.MVVM.Utils.Commands;
using CharacterEditor.MVVM.ViewModels.Base;

namespace CharacterEditor.MVVM.ViewModels;

public class AddCharacterWindowViewModel : ViewModel
{
    public IEnumerable<CharacterInfo> Characters { get; }
    public CharacterInfo? SelectedItem { get; set; }

    public ICommand OkCommand { get; set; }

    private bool CanOkCommandExecute(object p) => SelectedItem is not null;


    public AddCharacterWindowViewModel(string[] existingCharactersIds)
    {
        var app = (App)Application.Current;
        var repository = app.CharacterRepository;
        Characters = repository.GetAllCharacters()
            .Where(x => !existingCharactersIds.Contains(x.Id));

        OkCommand = new LambdaCommand(_ => { }, CanOkCommandExecute);
    }
}