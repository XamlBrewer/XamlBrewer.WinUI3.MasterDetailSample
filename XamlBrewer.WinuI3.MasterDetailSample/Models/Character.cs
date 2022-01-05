using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
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
        private string description;

        [ObservableProperty]
        private string imagePath;

        public static List<Character> GettingStarted => new List<Character>
        {
            new Character
            {
                Name = "Grogu",
                Kind = "Alien",
                Description = "Grogu, known to many simply as 'the Child', was a male Force-sensitive Jedi and Mandalorian foundling who belonged to the same species as Jedi Grand Master Yoda and Jedi Master Yaddle. Grogu was born in the year 41 BBY, and was raised at the Jedi Temple on Coruscant.",
                ImagePath = "/Assets/Grogu.png"
            },
            new Character
            {
                Name = "IG-11",
                Kind = "Droid",
                Description = "IG-11, also known as Eyegee-Eleven or simply as IG or Eyegee, was a masculine-programmed IG-series assassin droid who was a bounty hunter during the New Republic Era. IG-11 was programmed to follow protocols of the Bounty Hunters' Guild, and had a built-in self-destruct mechanism to prevent himself from being captured while working as a hired gun.",
                ImagePath = "/Assets/IG11.png"
            },
            new Character
            {
                Name = "Blurgg",
                Kind = "Animal",
                Description = "A blurrg (plural: blurrg or blurrgs) was a non-sentient, two-legged reptilian beast of burden found throughout the galaxy. Blurrgs were notably used by the Twi'lek Resistance and Free Ryloth Movement during the Clone Wars and the Imperial Era. They were also corralled by the moisture farmer Kuiil on Arvala-7.",
                ImagePath = "/Assets/Blurrg.png"
            },
            new Character
            {
                Name = "Dark Trooper",
                Kind = "Droid",
                Description = "The third-generation design Dark Trooper was a type of experimental third-generation battle droid manufactured by the Imperial Department of Military Research and used by the Imperial remnant of Moff Gideon. The black and silver-plated droids were humanoid in shape and featured a pair of red photoreceptors.",
                ImagePath = "/Assets/DarkTrooper.png"
            },
            new Character
            {
                Name = "Din Djarin",
                Kind = "Human",
                Description = "Din Djarin, also known as 'the Mandalorian' or simply 'Mando', was a renowned human male Mandalorian warrior during the era of the New Republic. With his Mandalorian armor, IB-94 blaster pistol, Amban sniper rifle, and distinctive beskar helmet, Djarin was both well-equipped and enigmatic—a stranger whose past was shrouded in mystery to others.",
                ImagePath = "/Assets/DinDjarin.png"
            },
            new Character
            {
                Name = "Moff Gideon",
                Kind = "Human",
                Description = "Gideon was a notorious human male warlord of the scattered Galactic Empire who led an Imperial remnant as Moff during the era of New Republic. Gideon valued power and knowledge, and was a patriot of the Galactic Empire, while also being imposing and ruthless, even willing to kill fellow Imperials to achieve his goals.",
                ImagePath = "/Assets/MoffGideon.png"
            },
            new Character
            {
                Name = "Kuiil",
                Kind = "Alien",
                Description = "Kuiil was an Ugnaught male who had worked a lifetime to be free of servitude. He came to the out-of-the-way planet of Arvala-7 seeking peace, and worked as a vapor farmer who offered valuable skills to those who could meet his price. Eventually, criminals and mercenaries trespassed on his world during the time of the New Republic, and at some point Kuiil encountered the Mandalorian bounty hunter Din Djarin. After the plan to relieve Grogu from being hunted went poorly, Kuiil was eventually tracked down, shot, and killed by Imperial scout troopers on speeder bikes.",
                ImagePath = "/Assets/Kuiil.png"
            },
            new Character
            {
                Name = "Boba Fett",
                Kind = "Human",
                Description = "Boba Fett was a human male bounty hunter and crime lord of Tatooine whose career spanned decades, from the fall of the Galactic Republic to the end of the rule of the Galactic Empire, culminating in his ascension to the Daimyo of Tatooine during the era of the New Republic. Originally code-named Alpha, he was an unaltered clone of the famed Mandalorian bounty hunter Jango Fett.",
                ImagePath = "/Assets/BobaFett.png"
            }
        };

        public Character Clone()
        {
            return new Character
            {
                Name = $"{Name} clone",
                Kind = Kind,
                Description = Description,
                ImagePath = ImagePath
            };
        }

        public bool ApplyFilter(string filter)
        {
            return Name.Contains(
                   filter, StringComparison.InvariantCultureIgnoreCase)
                || Kind.Contains(filter, StringComparison.InvariantCultureIgnoreCase)
                || Description.Contains(filter, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
