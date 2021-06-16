using System.Collections.Generic;
using System.Linq;
using Exilland.GodotCon.CardEffects.Card.Cards;
using Godot;

namespace Exilland.GodotCon.CardEffects.Database
{
    public class DatabaseSceneBased : Node, IDatabase
    {
        [Export] private List<PackedScene> cards = null!;
        public IEnumerable<CardInfo> Cards => cards.Select(c => c.Instance<CardInfo>());
    }
}
