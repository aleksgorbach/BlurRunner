// Created 22.10.2015
// Modified by Александр 22.10.2015 at 21:57

namespace Assets.Scripts.UI.Popups {
    #region References

    using Engine;
    using UnityEngine.EventSystems;

    #endregion

    internal abstract class Popup : MonoBehaviourBase, IPopup {
        private EventTrigger _eventTrigger;

        public event PopupClick Click;

        protected override void Awake() {
            base.Awake();
            _eventTrigger = gameObject.AddComponent<EventTrigger>();
            var trigger = new EventTrigger.TriggerEvent();
            trigger.AddListener(OnClick);
            _eventTrigger.triggers.Add(new EventTrigger.Entry {
                eventID = EventTriggerType.PointerClick,
                callback = trigger
            });
        }

        private void OnClick(BaseEventData arg0) {
            var handler = Click;
            if (handler != null) {
                handler.Invoke(this);
            }
        }
    }
}