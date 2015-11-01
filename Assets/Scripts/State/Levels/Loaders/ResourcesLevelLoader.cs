// Created 26.10.2015
// Modified by Александр 01.11.2015 at 12:01

namespace Assets.Scripts.State.Levels.Loaders {
    #region References

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using UnityEngine;

    #endregion

    internal class ResourcesLevelLoader : ILevelLoader {
        private readonly string _path;

        public ResourcesLevelLoader(string path) {
            _path = path;
        }

        public void Load() {
            var data = Resources.LoadAll<LevelData>(_path);
            OnLoaded(data.ToList());
        }

        public event Action<List<LevelData>> Loaded;


        private void OnLoaded(List<LevelData> data) {
            var handler = Loaded;
            if (handler != null) {
                handler.Invoke(data);
            }
        }
    }
}