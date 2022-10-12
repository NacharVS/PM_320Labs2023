﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CharacterEditor.Core;
using CharacterEditor.Core.Misc;
using CharacterEditor.MVVM.Utils.Commands;
using CharacterEditor.MVVM.ViewModels.Base;

namespace CharacterEditor.MVVM.ViewModels;

public class AddItemWindowViewModel : ViewModel
{
    public Character Character { get; set; }
    public IEnumerable<Item> Items { get; set; }
    public Item? SelectedItem { get; set; }

    public ICommand OkCommand { get; set; }

    private bool CanOkCommandExecute(object p) => SelectedItem is not null &&
                                                  SelectedItem.MinimumLevel <=
                                                  Character.Level.CurrentLevel
                                                  && Character.CanAddItem(SelectedItem);

    public AddItemWindowViewModel(Character character)
    {
        var app = (App)Application.Current;
        var repository = app.ItemRepository;

        Character = character;
        var classItems = repository.GetItemsByClass(character.GetType().Name);
        var universalItems = repository.GetUniversalItems();
        Items = classItems.Concat(universalItems);

        OkCommand = new LambdaCommand(_ => { }, CanOkCommandExecute);
    }
}