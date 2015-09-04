using System;
using System.Collections.Generic;
using Assets.Scripts.EndlessEngine.Ground;
using Assets.Scripts.EndlessEngine.Ground.Generators;
using Assets.Scripts.EndlessEngine.Ground.Generators.Strategy;
using Assets.Scripts.EndlessEngine.Ground.UI;
using Assets.Scripts.Engine.Factory;
using Assets.Scripts.Engine.Pool;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.ZenjectConfig {
    internal class GameplayInstaller : MonoInstaller {
        [SerializeField] private int _initialPoolSize = 10;
        [SerializeField] private BlockSettings _blockSettings;
        [SerializeField] private DecorationGeneratorUI _decorationGenerator;

        public override void InstallBindings() {
            BindGround();
            BindDecorations();
        }

        private void BindDecorations() {
            Container.Bind<IGeneratingStrategy>().ToSingleMonoBehaviour<RandomStrategy>(_decorationGenerator.gameObject);
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
            [SerializeField] private GroundBlockUI[] _prefabs;

            public IEnumerable<GroundBlockUI> Prefabs {
                get { return _prefabs; }
            }
        }
    }
}