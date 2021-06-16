using Godot;
using GodotOnReady.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardEffectsSceneBased.Battle
{
    public partial class Hand : Control
    {
        [Signal]
        public delegate void CardSelected(Card.Card card);

        [OnReadyGet] private Control _cardHolder = null!;
        public IEnumerable<Card.Card> Cards => _cardHolder.GetChildren().OfType<Card.Card>();

        public void AddCard(Card.Card card)
        {
            _cardHolder.AddChild(card);
            card.Connect("gui_input", this, nameof(CardInput), new Godot.Collections.Array { card });
        }

        public void RemoveCard(Card.Card card)
        {
            _cardHolder.RemoveChild(card);
            if (card.IsConnected("gui_input", this, nameof(CardInput))) 
            {
                card.Disconnect("gui_input", this, nameof(CardInput));
            }
        }

        private void CardInput(InputEvent @event, Card.Card card)
        {
            if (@event is not InputEventMouseButton {Pressed: true, ButtonIndex: (int) ButtonList.Left})
            {
                return;
            }
            EmitSignal(nameof(CardSelected), card);
        }
    }
}