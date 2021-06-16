using Godot;
using GodotOnReady.Attributes;
using System;

namespace Exilland.GodotCon.CardEffects.Battle
{
    public partial class Enemy : Control
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
        [Export] public int Attack
        {
            get => attack;
            set
            {
                attack = value;
                SetLabels();
            }
        }

        [OnReadyGet] private Label attackLabel = null!;
        [OnReadyGet] private Label healthLabel = null!;
        private int health;
        private int attack;

        [OnReady]
        private void SetLabels()
        {
            if (!IsInsideTree())
                return;

            attackLabel.Text = $"{Attack}";
            healthLabel.Text = $"{Health}";
        }
    }
}
