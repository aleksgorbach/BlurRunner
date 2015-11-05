// Created 20.10.2015 
// Modified by Gorbach Alex 05.11.2015 at 15:22

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using System.Collections.Generic;
    using Assets.Scripts.Gameplay.GameState.StateChangedSources;
    using Assets.Scripts.Gameplay.Heroes;
    using Engine;
    using GameState.Manager;
    using GameState.Pause;
    using State.Levels;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class Game : MonoBehaviourBase, IGame, IWinSource {
        [SerializeField]
        private Image _background;

        [SerializeField]
        private ObjectAnchor _cameraAnchor;

        [Inject]
        private IInstantiator _container;

        [SerializeField]
        private Transform _heroSpawner;

        private bool _isPaused;
        private ILevel _level;

        [Inject]
        private List<IPauseHandler> _pauseHandlers;

        [Inject]
        private IGameStateManager _stateManager;

        public void StartLevel(ILevel level) {
            _level = level;
            _background.sprite = level.Background;
        }

        //private void OnStateChanged(Consts.GameState state) {
        //    switch (state) {
        //        case Consts.GameState.NotStarted:
        //            break;
        //        case Consts.GameState.Running:
        //            if (_isPaused) {
        //                foreach (var handler in _pauseHandlers) {
        //                    handler.Resume();
        //                }
        //                _isPaused = false;
        //            }
        //            break;
        //        case Consts.GameState.Win:
        //            break;
        //        case Consts.GameState.Lose:
        //            break;
        //        case Consts.GameState.Paused:
        //            foreach (var handler in _pauseHandlers) {
        //                handler.Pause();
        //            }
        //            _isPaused = true;
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException(state.ToString(), state, null);
        //    }
        //}

        public event Action<IWinSource> Win;

        private void OnWin() {
            var handler = Win;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        [PostInject]
        private void PostInject() {
            //_stateManager.StateChanged += OnStateChanged;
            var hero = _container.InstantiatePrefabForComponent<Hero>(_level.Hero.gameObject);
            hero.transform.SetParent(_heroSpawner);
            hero.transform.localPosition = Vector3.zero;
            _cameraAnchor.SetTarget(hero.transform);
        }
    }
}