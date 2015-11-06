// Created 20.10.2015 
// Modified by Gorbach Alex 06.11.2015 at 15:11

#region References

#endregion

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using System;
    using System.Collections.Generic;
    using Assets.Scripts.State.Progress;
    using Assets.Scripts.State.Progress.Storage;
    using EndlessEngine;
    using EndlessEngine.Strategy;
    using EndlessEngine.Bonuses;
    using EndlessEngine.Decorations;
    using EndlessEngine.Ground;
    using EndlessEngine.Ground.UI;
    using Engine.Factory;
    using Engine.Factory.Strategy;
    using Engine.Pool;
    using Gameplay;
    using Gameplay.Bonuses;
    using Gameplay.GameState.Manager;
    using Gameplay.GameState.StateChangedSources;
    using State.Progress.Score;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GameplayInstaller : MonoInstaller {
        private readonly int _initialPoolSize = 10;

        [SerializeField]
        private BlockSettings _blockSettings;

        [SerializeField]
        private BonusSettings _bonusesSettings;

        [SerializeField]
        private DecorationsSettings _decorationsSettings;

        [SerializeField]
        private Game _game;

        public override void InstallBindings() {
            Container.Bind<IGame>().ToInstance(_game);
            Container.Bind<IGameStateManager>().ToSingle<GameStateManager>();
            Container.Bind<Camera>().ToSingleInstance(Camera.main);
            Container.Bind<IWinSource>().ToInstance(_game);
            Container.Bind<AbstractGenerator>().ToInstance(_bonusesSettings.Generator);
            Container.Bind<AbstractGenerator>().ToInstance(_decorationsSettings.Generator);
            Container.Bind<ILevelProgress>().ToGetter<IProgressStorage>(x => x.CurrentLevelProgress);
            BindGround();
            BindDecorations();
            BindBonuses();
        }

        private void BindBonuses() {
            Container.Bind<Engine.Factory.IFactory<Bonus>>().ToTransient<MultipleGameObjectFactory<Bonus>>();
            Container.Bind<IGeneratingStrategy>()
                .ToInstance(_bonusesSettings.Strategy)
                .WhenInjectedInto<BonusGenerator>();
            Container.Bind<IBonusGenerator>().ToInstance(_bonusesSettings.Generator);
            Container.Bind<IChooseStrategy<Bonus>>().ToTransient<RandomStrategy<Bonus>>();
            Container.Bind<MultipleGameObjectFactory<Bonus>.ISettings>().ToInstance(_bonusesSettings);
            Container.Bind<IObjectPool<Bonus>>().ToSingleGameObject<BonusesPool>("BonusesPool");
            Container.Bind<bool>(GameObjectPool<Bonus>.CAN_GROW_KEY).ToInstance(true).WhenInjectedInto<BonusesPool>();
            Container.Bind<int>(GameObjectPool<Bonus>.INITIAL_SIZE_KEY)
                .ToInstance(_initialPoolSize)
                .WhenInjectedInto<BonusesPool>();
        }

        private void BindDecorations() {
            Container.Bind<Engine.Factory.IFactory<DecorationItem>>()
                .ToTransient<MultipleGameObjectFactory<DecorationItem>>();
            Container.Bind<MultipleGameObjectFactory<DecorationItem>.ISettings>().ToInstance(_decorationsSettings);
            Container.Bind<IChooseStrategy<DecorationItem>>().ToTransient<RandomStrategy<DecorationItem>>();
            Container.Bind<IDecorationGenerator>().ToInstance(_decorationsSettings.Generator);
            Container.Bind<IGeneratingStrategy>()
                .ToInstance(_decorationsSettings.Strategy)
                .WhenInjectedInto<DecorationGenerator>();
            Container.Bind<IObjectPool<DecorationItem>>().ToSingleGameObject<DecorationPool>("DecorationsPool");
            Container.Bind<bool>(GameObjectPool<DecorationItem>.CAN_GROW_KEY)
                .ToInstance(true)
                .WhenInjectedInto<DecorationPool>();
            Container.Bind<int>(GameObjectPool<DecorationItem>.INITIAL_SIZE_KEY)
                .ToInstance(_initialPoolSize * 2)
                .WhenInjectedInto<DecorationPool>();
        }

        private void BindGround() {
            Container.Bind<Engine.Factory.IFactory<GroundBlock>>().ToSingle<MultipleGameObjectFactory<GroundBlock>>();
            Container.Bind<MultipleGameObjectFactory<GroundBlock>.ISettings>().ToInstance(_blockSettings);
            Container.Bind<IChooseStrategy<GroundBlock>>().ToTransient<CompatibleStrategy<GroundBlock>>();
            Container.Bind<IGroundGenerator>().ToInstance(_blockSettings.Generator);
            Container.Bind<IObjectPool<GroundBlock>>().ToSingleGameObject<GroundPool>("GroundBlocksPool");
            Container.Bind<bool>(GameObjectPool<GroundBlock>.CAN_GROW_KEY)
                .ToInstance(true)
                .WhenInjectedInto<GroundPool>();
            Container.Bind<int>(GameObjectPool<GroundBlock>.INITIAL_SIZE_KEY)
                .ToInstance(_initialPoolSize)
                .WhenInjectedInto<GroundPool>();
        }

        [Serializable]
        public class BlockSettings : MultipleGameObjectFactory<GroundBlock>.ISettings {
            [SerializeField]
            private GroundGenerator _generator;

            [SerializeField]
            private GroundBlock[] _prefabs;

            public IGroundGenerator Generator {
                get {
                    return _generator;
                }
            }

            public IEnumerable<GroundBlock> Prefabs {
                get {
                    return _prefabs;
                }
            }
        }

        [Serializable]
        public class DecorationsSettings : MultipleGameObjectFactory<DecorationItem>.ISettings {
            [SerializeField]
            private DecorationGenerator _generator;

            [SerializeField]
            private DecorationItem[] _prefabs;

            [SerializeField]
            private AbstractStrategy _strategy;

            public AbstractStrategy Strategy {
                get {
                    return _strategy;
                }
            }

            public DecorationGenerator Generator {
                get {
                    return _generator;
                }
            }

            public IEnumerable<DecorationItem> Prefabs {
                get {
                    return _prefabs;
                }
            }
        }

        [Serializable]
        public class BonusSettings : MultipleGameObjectFactory<Bonus>.ISettings {
            [SerializeField]
            private BonusGenerator _generator;

            [SerializeField]
            private Bonus[] _prefabs;

            [SerializeField]
            private AbstractStrategy _strategy;

            public AbstractStrategy Strategy {
                get {
                    return _strategy;
                }
            }

            public BonusGenerator Generator {
                get {
                    return _generator;
                }
            }

            public IEnumerable<Bonus> Prefabs {
                get {
                    return _prefabs;
                }
            }
        }
    }
}