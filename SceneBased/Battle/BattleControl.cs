using Godot;
using GodotOnReady.Attributes;
using System;

namespace CardEffectsSceneBased.Battle
{
    public partial class BattleControl : Control
    {
        [OnReadyGet] public Control Enemy { get; set; } = null!;
        [OnReadyGet] public Control Player { get; set; } = null!;
        [OnReadyGet] public Control Hand { get; set; } = null!;
        [OnReadyGet] public Control Deck { get; set; } = null!;
        [OnReadyGet] public Control Discard { get; set; } = null!;

        [OnReady]
        private void StartBattle()
        {

        }
    }
}