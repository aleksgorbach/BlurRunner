// Created 05.11.2015
// Modified by Александр 05.11.2015 at 19:53

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using System.Collections.Generic;
    using Engine;
    using GameState.Manager;
    using GameState.Pause;
    using GameState.StateChangedSources;
    using Heroes;
    using State.Levels;
    using State.Progress;
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

        public ILevelProgress Progress { get; private set; }

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

        private void OnWin(IWinSource winSource) {
            var handler = Win;
            if (handler != null) {
                handler.Invoke(winSource);
            }
        }

        [PostInject]
        private void PostInject() {
            //_stateManager.StateChanged += OnStateChanged;
            var hero = _container.InstantiatePrefabForComponent<Hero>(_level.Hero.gameObject);
            hero.transform.SetParent(_heroSpawner);
            hero.transform.localPosition = Vector3.zero;
            _cameraAnchor.SetTarget(hero.transform);
            hero.Destination = _level.Length;
            hero.Win += OnWin;
        }
    }
}