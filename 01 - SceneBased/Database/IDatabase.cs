using System.Collections.Generic;
using CardEffectsSceneBased.Card.Cards;

namespace CardEffectsSceneBased.Database
{
    public interface IDatabase
    {
        IEnumerable<CardInfo> Cards { get; }
    }
}