using Exilland.GodotCon.CardEffects.Battle;
using Godot;
using System;

namespace Exilland.GodotCon.CardEffects.Card.Effects.Abstract
{
    public abstract class CardEffect : Resource
    {
        public abstract void Execute(BattleControl battle);
    }
}
