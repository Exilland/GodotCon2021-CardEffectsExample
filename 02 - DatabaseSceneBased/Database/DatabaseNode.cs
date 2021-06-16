using Exilland.GodotCon.CardEffects.Card.Cards;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exilland.GodotCon.CardEffects.Database
{
    public class DatabaseNode : Node, IDatabase
    {
        public IEnumerable<CardInfo> Cards => GetChildren().OfType<CardInfo>();
    }
}