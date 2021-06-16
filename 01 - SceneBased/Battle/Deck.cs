using Godot;
using GodotOnReady.Attributes;
using MoreLinq;
using System;
using System.Collections.Generic;

namespace CardEffectsSceneBased.Battle
{
    public partial class Deck : Control
    {
        [OnReadyGet] private Label _counter = null!;
        [OnReadyGet] private Control _holder = null!;

        private List<Card.Card> _cards = new();
        public int Count => _cards.Count;

        public void AddCard(Card.Card card)
        {
            _holder.AddChild(card);
            _cards.Add(card);
            _counter.Text = $"{_cards.Count}";
        }
        
        public Card.Card? RemoveTop()
        {
            if (_cards.Count == 0)
                return null;

            var card = _cards[0];
            _holder.RemoveChild(card);
            _cards.RemoveAt(0);
            _counter.Text = $"{_cards.Count}";
            return card;
        }

        public void Shuffle()
        {
            _cards.Shuffle();
        }
    }
}