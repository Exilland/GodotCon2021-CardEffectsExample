using CardEffectsSceneBased.Battle;
using Godot;
using System;

namespace CardEffectsSceneBased.Card.Effects.Abstract
{
    public abstract class CardEffect : Node
    {
        public abstract void Execute(BattleControl battle);
    }
}