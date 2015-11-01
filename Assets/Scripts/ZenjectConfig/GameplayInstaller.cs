// Created 30.10.2015
// Modified by Александр 01.11.2015 at 12:41

#region References

#endregion

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using System;
    using System.Collections.Generic;
    using EndlessEngine.Bonuses;
    using EndlessEngine.Bonuses.Strategy;
    using EndlessEngine.Bonuses.UI;
    using EndlessEngine.Ground;
    using EndlessEngine.Ground.Decorations;
    using EndlessEngine.Ground.Decorations.Strategy;
    using EndlessEngine.Ground.Decorations.UI;
    using EndlessEngine.Ground.UI;
    using Engine.Factory;
    using Engine.Factory.Strategy;
    using Engine.Pool;
    using Gameplay;
    using Gameplay.Bonuses.UI;
    using Gameplay.GameState.Manager;
    using Gameplay.GameState.Pause;
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
            Container.Bind<IGettingStrategy>().ToTransient<Engine.Factory.Strategy.RandomStrategy>();
            Container.Bind<Camera>().ToSingleInstance(Camera.main);
            Container.Bind<IPauseHandler>().ToSingle<GameStateManager>();
            BindGround();
            BindDecorations();
            BindBonuses();
        }

        private void BindBonuses() {
            Container.Bind<Engine.Factory.IFactory<BonusUI>>().ToTransient<RandomGameObjectFactory<BonusUI>>();
            Container.Bind<IBonusStrategy>().ToInstance(_bonusesSettings.Strategy);
            Container.Bind<IBonusGenerator>().ToSingle<BonusGenerator>();
            Container.Bind<IBonusGeneratorUI>().ToInstance(_bonusesSettings.Generator);
            Container.Bind<RandomGameObjectFactory<BonusUI>.ISettings>().ToInstance(_bonusesSettings);
            Container.Bind<IObjectPool<BonusUI>>().ToSingleGameObject<BonusesPool>("BonusesPool");
            Container.Bind<bool>(GameObjectPool<BonusUI>.CAN_GROW_KEY).ToInstance(true).WhenInjectedInto<BonusesPool>();
            Container.Bind<int>(GameObjectPool<BonusUI>.INITIAL_SIZE_KEY)
                .ToInstance(_initialPoolSize)
                .WhenInjectedInto<BonusesPool>();
        }

        private void BindDecorations() {
            Container.Bind<Engine.Factory.IFactory<DecorationItemUI>>()
                .ToTransient<RandomGameObjectFactory<DecorationItemUI>>();
            Container.Bind<RandomGameObjectFactory<DecorationItemUI>.ISettings>().ToInstance(_decorationsSettings);
            Container.Bind<IDecorationGenerator>().ToSingle<DecorationGenerator>();
            Container.Bind<IDecorationGeneratorUI>().ToInstance(_decorationsSettings.Generator);
            Container.Bind<IGeneratingStrategy>().ToInstance(_decorationsSettings.Strategy);
            Container.Bind<IObjectPool<DecorationItemUI>>().ToSingleGameObject<DecorationPool>("DecorationsPool");
            Container.Bind<bool>(GameObjectPool<DecorationItemUI>.CAN_GROW_KEY)
                .ToInstance(true)
                .WhenInjectedInto<DecorationPool>();
            Container.Bind<int>(GameObjectPool<DecorationItemUI>.INITIAL_SIZE_KEY)
                .ToInstance(_initialPoolSize*2)
                .WhenInjectedInto<DecorationPool>();
        }

        private void BindGround() {
            Container.Bind<Engine.Factory.IFactory<GroundBlockUI>>()
                .ToTransient<RandomGameObjectFactory<GroundBlockUI>>();
            Container.Bind<RandomGameObjectFactory<GroundBlockUI>.ISettings>().ToInstance(_blockSettings);
            Container.Bind<IGroundGenerator>().ToSingle<GroundGenerator>();
            Container.Bind<IGroundGeneratorUI>().ToInstance(_blockSettings.Generator);
            Container.Bind<IObjectPool<GroundBlockUI>>().ToSingleGameObject<GroundPool>("GroundBlocksPool");
            Container.Bind<bool>(GameObjectPool<GroundBlockUI>.CAN_GROW_KEY)
                .ToInstance(true)
                .WhenInjectedInto<GroundPool>();
            Container.Bind<int>(GameObjectPool<GroundBlockUI>.INITIAL_SIZE_KEY)
                .ToInstance(_initialPoolSize)
                .WhenInjectedInto<GroundPool>();
        }

        [Serializable]
        public class BlockSettings : RandomGameObjectFactory<GroundBlockUI>.ISettings {
            [SerializeField]
            private GroundGeneratorUI _generator;

            [SerializeField]
            private GroundBlockUI[] _prefabs;

            public IGroundGeneratorUI Generator {
                get { return _generator; }
            }

            public IEnumerable<GroundBlockUI> Prefabs {
                get { return _prefabs; }
            }
        }

        [Serializable]
        public class DecorationsSettings : RandomGameObjectFactory<DecorationItemUI>.ISettings {
            [SerializeField]
            private DecorationGeneratorUI _generator;

            [SerializeField]
            private DecorationItemUI[] _prefabs;

            [SerializeField]
            private AbstractStrategy _strategy;

            public AbstractStrategy Strategy {
                get { return _strategy; }
            }

            public IDecorationGeneratorUI Generator {
                get { return _generator; }
            }

            public IEnumerable<DecorationItemUI> Prefabs {
                get { return _prefabs; }
            }
        }

        [Serializable]
        public class BonusSettings : RandomGameObjectFactory<BonusUI>.ISettings {
            [SerializeField]
            private BonusGeneratorUI _generator;

            [SerializeField]
            private BonusUI[] _prefabs;

            [SerializeField]
            private AbstractBonusStrategy _strategy;

            public AbstractBonusStrategy Strategy {
                get { return _strategy; }
            }

            public IBonusGeneratorUI Generator {
                get { return _generator; }
            }

            public IEnumerable<BonusUI> Prefabs {
                get { return _prefabs; }
            }
        }
    }
}