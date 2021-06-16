using System.Collections.Generic;
using System.Linq;
using CardEffectsSceneBased.Card.Cards;
using Godot;

namespace CardEffectsSceneBased.Database
{
    public class DatabaseSceneBased : Node, IDatabase
    {
        [Export] private List<PackedScene> cards = null!;
        public IEnumerable<CardInfo> Cards => cards.Select(c => c.Instance<CardInfo>());
    }
}