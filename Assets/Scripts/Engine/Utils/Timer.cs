// Created 28.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 11:35

namespace Assets.Scripts.Engine.Utils {
    #region References

    using System;
    using UnityEngine;

    #endregion

    internal delegate void TimerTickDelegate();

    internal class Timer : MonoBehaviourBase {
        public bool IsStarted { get; private set; }

        public TimeSpan TimeLeft { get; private set; }
        public event TimerTickDelegate Tick;

        public void StartTimer(TimeSpan time) {
            TimeLeft = time;
            IsStarted = true;
        }

        public void Stop() {
            IsStarted = false;
        }

        protected override void Update() {
            base.Update();
            if (!IsStarted) {
                return;
            }
            TimeLeft -= TimeSpan.FromSeconds(Time.deltaTime);
            if (TimeLeft <= TimeSpan.Zero) {
                TimeLeft = TimeSpan.Zero;
                IsStarted = false;
                OnTimerTick();
            }
        }

        private void OnTimerTick() {
            var handler = Tick;
            if (handler != null) {
                handler();
            }
        }
    }
}