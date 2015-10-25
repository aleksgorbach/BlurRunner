// Created 24.10.2015
// Modified by Александр 25.10.2015 at 21:31

#region References

#endregion

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using System;
    using System.Collections.Generic;
    using EndlessEngine.Ground;
    using EndlessEngine.Ground.Generators;
    using EndlessEngine.Ground.UI;
    using Engine.Factory;
    using Engine.Pool;
    using Gameplay;
    using Gameplay.GameState.Manager;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GameplayInstaller : MonoInstaller {
        [SerializeField]
        private readonly int _initialPoolSize = 10;

        [SerializeField]
        private BlockSettings _blockSettings;

        [SerializeField]
        private GroundGeneratorUI _groundGenerator;

        [SerializeField]
        private TreeSettings _treeSettings;

        public override void InstallBindings() {
            Container.Bind<IGame>().ToSingle<Game>();
            Container.Bind<IGameStateManager>().ToSingle<GameStateManager>();
            BindGround();
            BindDecorations();
        }

        private void BindDecorations() {
            Container.Bind<Engine.Factory.IFactory<DecorationItemUI>>()
                .ToTransient<RandomGameObjectFactory<DecorationItemUI>>();
            Container.Bind<RandomGameObjectFactory<DecorationItemUI>.ISettings>().ToInstance(_treeSettings);
            Container.Bind<IDecorationGenerator>().ToSingle<DecorationGenerator>();
            Container.Bind<IObjectPool<DecorationItemUI>>().ToSingleGameObject<DecorationPool>("DecorationsPool");
            Container.Bind<bool>(GameObjectPool<DecorationItemUI>.CAN_GROW_KEY)
                .ToInstance(true)
                .WhenInjectedInto<DecorationPool>();
            Container.Bind<int>(GameObjectPool<DecorationItemUI>.INITIAL_SIZE_KEY)
                .ToInstance(_initialPoolSize)
                .WhenInjectedInto<DecorationPool>();
        }

        private void BindGround() {
            Container.Bind<Engine.Factory.IFactory<GroundBlockUI>>()
                .ToTransient<RandomGameObjectFactory<GroundBlockUI>>();
            Container.Bind<RandomGameObjectFactory<GroundBlockUI>.ISettings>().ToInstance(_blockSettings);
            Container.Bind<IGroundGenerator>().ToSingle<GroundGenerator>();
            Container.Bind<IGroundGeneratorUI>().ToSingleInstance(_groundGenerator);
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
            private GroundBlockUI[] _prefabs;

            public IEnumerable<GroundBlockUI> Prefabs {
                get { return _prefabs; }
            }
        }

        [Serializable]
        public class TreeSettings : RandomGameObjectFactory<DecorationItemUI>.ISettings {
            [SerializeField]
            private DecorationItemUI[] _prefabs;

            public IEnumerable<DecorationItemUI> Prefabs {
                get { return _prefabs; }
            }
        }
    }
}