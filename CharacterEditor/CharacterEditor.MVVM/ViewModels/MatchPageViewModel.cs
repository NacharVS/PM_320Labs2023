using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CharacterEditor.Core;
using CharacterEditor.Core.Db;
using CharacterEditor.Core.Matching;
using CharacterEditor.MVVM.Utils.Commands;
using CharacterEditor.MVVM.ViewModels.Base;
using CharacterEditor.MVVM.Views;

// ReSharper disable ValueParameterNotUsed

namespace CharacterEditor.MVVM.ViewModels;

public class MatchPageViewModel : ViewModel
{
    private readonly ICharacterRepository _repository;
    private Match? _match;

    public Match? Match
    {
        get => _match;
        set => OnPropertyChanged();
    }

    public Team? TeamA
    {
        get => _match?.TeamA;
        set => OnPropertyChanged();
    }
    
    public CharacterInfo? TeamASelectedCharacter { get; set; }

    public Team? TeamB
    {
        get => _match?.TeamB;
        set => OnPropertyChanged();
    }
    
    public CharacterInfo? TeamBSelectedCharacter { get; set; }


    public ICommand RemoveFromTeamCommand { get; }

    private bool CanRemoveFromTeamCommandExecute(object p) =>
        _match is not null && GetSelectedItemByTeamParameter(p) is not null;

    private void OnRemoveFromTeamCommandExecuted(object p)
    {
        var team = GetTeamByParameter(p);
        var item = GetSelectedItemByTeamParameter(p);
        team.RemoveCharacter(item);
        UpdatePage();
    }

    public ICommand AddToTeamCommand { get; }

    private bool CanAddToTeamCommandExecute(object p) => _match is not null &&
        GetTeamByParameter(p).Characters.Length != Team.MaximumParticipants;

    private void OnAddToTeamCommandExecuted(object p)
    {
        var team = GetTeamByParameter(p);
        var prompt = new AddCharacterWindow
        {
            DataContext = new AddCharacterWindowViewModel(
                TeamA!.Characters.Concat(TeamB!.Characters).Select(x => x.Id)
                    .ToArray())
        };
        if (prompt.ShowDialog() == true)
        {
            team.AddCharacter(
                (prompt.DataContext as AddCharacterWindowViewModel)!
                .SelectedItem!);
            UpdatePage();
        }
    }

    private void UpdatePage()
    {
        OnPropertyChanged(nameof(TeamA));
        OnPropertyChanged(nameof(TeamB));
        OnPropertyChanged(nameof(Match));
    }

    public ICommand AutoGenerateMatchCommand { get; }

    private bool CanAutoGenerateMatchCommandExecute(object p) =>
        _match is not null;

    private void OnAutoGenerateMatchCommandExecuted(object p)
    {
        try
        {
            _match!.AutoGenerateTeams();
            UpdatePage();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    private Team GetTeamByParameter(object p)
    {
        string param = p as string ?? throw new Exception();
        switch (param)
        {
            case "TeamA":
                return TeamA!;
            case "TeamB":
                return TeamB!;
            default:
                throw new Exception();
        }
    }
    
    private CharacterInfo? GetSelectedItemByTeamParameter(object p)
    {
        string param = p as string ?? throw new Exception();
        switch (param)
        {
            case "TeamA":
                return TeamASelectedCharacter;
            case "TeamB":
                return TeamBSelectedCharacter;
            default:
                throw new Exception();
        }
    }

    public MatchPageViewModel()
    {
        var app = (App)Application.Current;
        _repository = app.CharacterRepository;

        _match = new Match(_repository, "Orange", "Blue");
        AutoGenerateMatchCommand = new LambdaCommand(
            OnAutoGenerateMatchCommandExecuted,
            CanAutoGenerateMatchCommandExecute);
        AddToTeamCommand = new LambdaCommand(OnAddToTeamCommandExecuted,
            CanAddToTeamCommandExecute);
        RemoveFromTeamCommand = new LambdaCommand(
            OnRemoveFromTeamCommandExecuted, CanRemoveFromTeamCommandExecute);
    }
}