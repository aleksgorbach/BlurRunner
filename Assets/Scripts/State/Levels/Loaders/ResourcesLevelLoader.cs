// Created 26.10.2015
// Modified by Александр 26.10.2015 at 21:33

namespace Assets.Scripts.State.Levels.Loaders {
    #region References

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using DataContracts.Models.Levels;
    using UnityEngine;

    #endregion

    internal class ResourcesLevelLoader : ILevelLoader {
        private readonly string _text;

        public ResourcesLevelLoader(TextAsset textAsset) {
            _text = textAsset.text;
        }

        public void Load() {
            var serializer = new XmlSerializer(typeof (IEnumerable<LevelData>));
            var data = (IEnumerable<LevelData>) serializer.Deserialize(new StringReader(_text));
            OnLoaded(data);
        }

        public event Action<IEnumerable<LevelData>> Loaded;

        private void OnLoaded(IEnumerable<LevelData> data) {
            var handler = Loaded;
            if (handler != null) {
                handler.Invoke(data);
            }
        }
    }
}