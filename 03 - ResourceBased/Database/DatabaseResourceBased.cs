using System.Collections.Generic;
using Exilland.GodotCon.CardEffects.Card.Cards;
using Godot;

namespace Exilland.GodotCon.CardEffects.Database
{
    public class DatabaseResourceBased : Node, IDatabase
    {
        private const string CardsDirectory = "res://Card/Cards/";
        public IEnumerable<CardInfo> Cards => LoadFromDirectory(CardsDirectory);

        public static List<CardInfo> LoadFromDirectory(string cardsDir)
        {
            using var dir = new Godot.Directory();
            var cards = new List<CardInfo>();
            dir.Open(cardsDir);
            dir.ListDirBegin(skipNavigational: true, skipHidden: true);

            string filename;
            while (!string.IsNullOrWhiteSpace(filename = dir.GetNext()))
            {
                if (dir.CurrentIsDir())
                {
                    continue;
                }
                var fullPath = System.IO.Path.Combine(CardsDirectory, filename);
                if (System.IO.Path.GetExtension(fullPath) != ".tres")
                {
                    continue;
                }
                var card = Godot.GD.Load<CardInfo>(fullPath);
                if (card != null)
                {
                    cards.Add(card);
                }
            }
            return cards;
        }
    }
}