using CardEffectsSceneBased.Card.Effects.Abstract;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardEffectsSceneBased.Card.Cards
{
    public class CardInfo : Node
    {
        [Export] private NodePath _effectsHolderNode = ".";
        [Export] public int Cost { get; set; }
        [Export] public string? Title { get; set; }
        [Export(PropertyHint.MultilineText)] public string? Description { get; set; }

        public IEnumerable<CardEffect> Effects => GetNode(_effectsHolderNode)
            .GetChildren()
            .OfType<CardEffect>();
    }
}