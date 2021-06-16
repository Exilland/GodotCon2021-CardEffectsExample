using System.Collections.Generic;
using Exilland.GodotCon.CardEffects.Card.Cards;

namespace Exilland.GodotCon.CardEffects.Database
{
    public interface IDatabase
    {
        IEnumerable<CardInfo> Cards { get; }
    }
}
