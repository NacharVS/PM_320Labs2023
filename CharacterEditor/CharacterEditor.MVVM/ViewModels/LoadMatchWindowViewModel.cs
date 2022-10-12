using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CharacterEditor.Core.Matching;
using CharacterEditor.MVVM.Utils.Commands;
using CharacterEditor.MVVM.ViewModels.Base;

namespace CharacterEditor.MVVM.ViewModels;

public class LoadMatchWindowViewModel : ViewModel
{
    public IEnumerable<MatchInfo> Matches { get; }
    public MatchInfo? SelectedItem { get; set; }

    public ICommand OkCommand { get; set; }

    private bool CanOkCommandExecute(object p) => SelectedItem is not null;


    public LoadMatchWindowViewModel()
    {
        var app = (App)Application.Current;
        Matches = app.MatchRepository.GetAllMatchesInfo();
        OkCommand = new LambdaCommand(_ => { }, CanOkCommandExecute);
    }
}