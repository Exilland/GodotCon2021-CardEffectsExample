using Exilland.GodotCon.CardEffects.Database;
using Godot;
using GodotOnReady.Attributes;
using JetBrains.Annotations;
using System;
using System.Linq;

namespace Exilland.GodotCon.CardEffects.Battle
{
    public partial class BattleControl : Control
    {
        [OnReadyGet] public Enemy Enemy { get; set; } = null!;
        [OnReadyGet] public Player Player { get; set; } = null!;
        [OnReadyGet] public Hand Hand { get; set; } = null!;
        [OnReadyGet] public Deck Deck { get; set; } = null!;
        [OnReadyGet] public Deck Discard { get; set; } = null!;
        [Export] private PackedScene? _cardScene { get; set; }

        private bool mouseOverPlayArea;
        private Card.Card? currentCard;

        [OnReady]
        private void InitFromDatabase()
        {
            if (_cardScene == null)
                return;

            var database = GetNode<IDatabase>("/root/Database");
            if (database == null)
                return;

            foreach (var cardInfo in database.Cards)
            {
                var card = _cardScene.Instance<Card.Card>();
                card.CardInfo = cardInfo;
                Deck.AddCard(card);
            }
            Deck.Shuffle();
        }

        [OnReady]
        private void StartOfTurn()
        {
            for (int i = 0; i < 5; i++)
            {
                DrawCard();
            }
        }

        private void EndTurn()
        {
            foreach (var card in Hand.Cards)
            {
                Hand.RemoveCard(card);
                Discard.AddCard(card);
            }
            Player.Health -= Math.Max(Enemy.Attack - Player.Defense, 0);
            StartOfTurn();
        }

        private void DrawCard()
        {
            var card = Deck.RemoveTop();
            if (card == null)
            {
                ShuffleDiscardToDeck();
                card = Deck.RemoveTop();
            }
            if (card != null)
            {
                Hand.AddCard(card);
            }
        }

        private void ShuffleDiscardToDeck()
        {
            for (int i = 0; i < Discard.Count; i++)
            {
                var card = Discard.RemoveTop();
                if (card != null)
                {
                    Deck.AddCard(card);
                }
            }
            Deck.Shuffle();
        }

        [UsedImplicitly]
        private void Hand_CardSelected(Card.Card card)
        {
            card.Draggable = true;
            if (currentCard != null)
            {
                StopCardDrag(currentCard);
            }
            currentCard = card;
            currentCard.Connect(nameof(Card.Card.StopDrag), this, nameof(Card_StopDrag), new Godot.Collections.Array { card });
        }

        private void StopCardDrag(Card.Card card)
        {
            card.Draggable = false;
            if (card.IsConnected(nameof(Card.Card.StopDrag), this, nameof(Card_StopDrag)))
            {
                card.Disconnect(nameof(Card.Card.StopDrag), this, nameof(Card_StopDrag));
            }
        }

        private void Card_StopDrag(Card.Card card)
        {
            if (mouseOverPlayArea)
            {
                var effects = card.CardInfo?.Effects?.ToList();
                if (effects != null)
                {
                    foreach (var effect in effects)
                    {
                        effect.Execute(this);
                    }
                }
                Hand.RemoveCard(card);
                StopCardDrag(card);
                currentCard = null;
                Discard.AddCard(card);
            }
        }

        [UsedImplicitly]
        private void PlayArea_mouse_entered()
        {
            mouseOverPlayArea = true;
        }

        [UsedImplicitly]
        private void PlayArea_mouse_exited()
        {
            mouseOverPlayArea = false;
        }

        [UsedImplicitly]
        private void End_Turn_Button_pressed()
        {
            EndTurn();
        }
    }
}
