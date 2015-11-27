// Created 20.10.2015
// Modified by  27.11.2015 at 14:36

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using UI.Menus.Levels.LevelItem;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class LevelChooseInstaller : MonoInstaller {
        [SerializeField]
        private LevelItem _levelPrefab;

        public override void InstallBindings() {
            Container.BindIFactory<LevelItem>().ToPrefab(_levelPrefab.gameObject);
        }
    }
}