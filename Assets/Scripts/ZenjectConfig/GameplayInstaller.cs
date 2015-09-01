using System;
using System.Collections.Generic;
using Assets.Scripts.EndlessEngine.Ground.Generators;
using Assets.Scripts.EndlessEngine.Ground.UI;
using Assets.Scripts.Engine.Factory;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.ZenjectConfig {
    internal class GameplayInstaller : MonoInstaller {
        [SerializeField] private BlockSettings _blockSettings;

        public override void InstallBindings() {
            Container.Bind<Engine.Factory.IFactory<GroundBlockUI>>()
                .ToTransient<RandomGameObjectFactory<GroundBlockUI>>();
            Container.Bind<RandomGameObjectFactory<GroundBlockUI>.ISettings>().ToInstance(_blockSettings);
            Container.Bind<IGroundGenerator>().ToSingle<GroundGenerator>();
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