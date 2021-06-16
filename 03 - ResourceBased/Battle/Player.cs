using Godot;
using GodotOnReady.Attributes;
using System;

namespace Exilland.GodotCon.CardEffects.Battle
{
    public partial class Player : Control
    {
        [Export] public int Health
        {
            get => health;
            set
            {
                health = value;
                SetLabels();
            }
        } 
        [Export] public int Defense
        {
            get => defense;
            set
            {
                defense = value;
                SetLabels();
            }
        }
        [OnReadyGet] private Label healthLabel = null!;
        [OnReadyGet] private Label defenseLabel = null!;
        private int health;
        private int defense;

        [OnReady]
        private void SetLabels()
        {
            if (!IsInsideTree())
                return;

            healthLabel.Text = $"{Health}";
            defenseLabel.Text = $"{Defense}";
        }
    }
}
