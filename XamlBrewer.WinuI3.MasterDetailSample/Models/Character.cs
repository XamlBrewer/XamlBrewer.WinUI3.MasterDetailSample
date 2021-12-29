using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using XamlBrewer.WinuI3.Services;

namespace XamlBrewer.WinUI3.MasterDetailSample.Models
{
    public partial class Character : ObservableObject, IMasterDetail
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string kind;

        [ObservableProperty]
        private string imagePath;

        [ObservableProperty]
        private ICommand deleteCommand;

        [ObservableProperty]
        private ICommand duplicateCommand;

        public static List<Character> GettingStarted => new List<Character>
        {
            new Character
            {
                Name = "Grogu",
                Kind = "Alien",
                ImagePath = "/Assets/Grogu.png"
            },
            new Character
            {
                Name = "IG-11",
                Kind = "Droid",
                ImagePath = "/Assets/IG11.png"
            },
            new Character
            {
                Name = "Blurgg",
                Kind = "Animal",
                ImagePath = "/Assets/Blurrg.png"
            },
            new Character
            {
                Name = "Dark Trooper",
                Kind = "Droid",
                ImagePath = "/Assets/DarkTrooper.png"
            },
            new Character
            {
                Name = "Din Djarin",
                Kind = "Human",
                ImagePath = "/Assets/DinDjarin.png"
            },
            new Character
            {
                Name = "Moff Gideon",
                Kind = "Human",
                ImagePath = "/Assets/MoffGideon.png"
            }
        };

        public Character Clone()
        {
            return new Character
            {
                Name = $"{Name} clone",
                Kind = Kind,
                ImagePath = ImagePath,
                DeleteCommand = DeleteCommand,
                DuplicateCommand = DuplicateCommand
            };
        }

        public bool ApplyFilter(string filter)
        {
            return Name.Contains(
                   filter, StringComparison.InvariantCultureIgnoreCase)
                || Kind.Contains(filter, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
