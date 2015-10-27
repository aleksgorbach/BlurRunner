// Created 26.10.2015
// Modified by Александр 27.10.2015 at 20:24

namespace Assets.Scripts.State.Levels.Loaders {
    #region References

    using System;
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
            var serializer = new XmlSerializer(typeof (LevelsCollectionData));
            var data = (LevelsCollectionData) serializer.Deserialize(new StringReader(_text));
            OnLoaded(data);
        }

        public event Action<LevelsCollectionData> Loaded;

        private void OnLoaded(LevelsCollectionData data) {
            var handler = Loaded;
            if (handler != null) {
                handler.Invoke(data);
            }
        }
    }
}