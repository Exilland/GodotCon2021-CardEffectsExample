using Exilland.GodotCon.CardEffects.Card.Cards;
using Godot;
using GodotOnReady.Attributes;
using System;

namespace Exilland.GodotCon.CardEffects.Card
{
    public partial class Card : Control
    {
        [Signal]
        public delegate void StopDrag();

        [OnReadyGet] private Label title = null!;
        [OnReadyGet] private Label description = null!;
        private CardInfo? cardInfo;
        private bool draggable;
        private bool dragAndDrop;

        public CardInfo? CardInfo
        {
            get => cardInfo;
            set
            {
                cardInfo = value;
                InitFromCardInfo();
            }
        }

        public bool Draggable
        {
            get => draggable;
            set
            {
                draggable = value;
                if (!draggable)
                {
                    dragAndDrop = false;
                }
                MouseFilter = draggable ? MouseFilterEnum.Ignore : MouseFilterEnum.Pass;

                SetProcess(draggable);
                SetProcessInput(draggable);
            }
        }

        public override void _Input(InputEvent @event)
        {
            if (Draggable)
            {
                if (@event is InputEventMouseMotion motion)
                    if (!dragAndDrop
                        && (Input.GetMouseButtonMask() & (int)ButtonList.MaskLeft) != 0
                        && motion.Relative.LengthSquared() > 48)
                        dragAndDrop = true;

                if (@event is InputEventMouseButton mouseButton)
                {
                    if (!dragAndDrop && mouseButton.Pressed) dragAndDrop = true;

                    if (dragAndDrop && !mouseButton.Pressed)
                    {
                        EmitSignal(nameof(StopDrag));
                    }
                }
            }
        }

        public override void _Process(float delta)
        {
            if (Draggable)
            {
                RectGlobalPosition = RectGlobalPosition
                    .LinearInterpolate(
                        GetViewport().GetMousePosition() - RectSize * 0.5f,
                        delta * 12);
            }
        }

        [OnReady]
        private void InitFromCardInfo()
        {
            if (cardInfo == null || !IsInsideTree())
                return;

            title.Text = cardInfo.Title;
            description.Text = cardInfo.Description;
        }
    }
}
