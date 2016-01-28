// Created 23.10.2015
// Modified by  28.01.2016 at 12:40

namespace Assets.Scripts.UI.Popups {
    #region References

    using System;
    using Engine;
    using UnityEngine.EventSystems;

    #endregion

    internal abstract class Popup : MonoBehaviourBase, IPopup {
        private EventTrigger _eventTrigger;

        public event Action<Popup> Closed;

        public virtual float Delay {
            get { return 0; }
        }

        protected override void Awake() {
            base.Awake();
            _eventTrigger = gameObject.AddComponent<EventTrigger>();
            var trigger = new EventTrigger.TriggerEvent();
            trigger.AddListener(OnClick);
            _eventTrigger.triggers.Add(
                new EventTrigger.Entry {eventID = EventTriggerType.PointerClick, callback = trigger});
        }

        private void OnClick(BaseEventData args) {
            Close();
        }

        protected virtual void OnClose() {
        }

        public void Close() {
            OnClose();
            var handler = Closed;
            if (handler != null) {
                handler.Invoke(this);
            }
        }
    }
}