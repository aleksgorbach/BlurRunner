
#if UNITY_4_6 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3

namespace SmartLocalization.Editor {
    #region References

    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    [RequireComponent(typeof (Text))]
    public class LocalizedText : MonoBehaviour {
        public string localizedKey = "INSERT_KEY_HERE";
        Text textObject;

        void Start() {
            textObject = GetComponent<Text>();

            //Subscribe to the change language event
            var languageManager = LanguageManager.Instance;
            languageManager.OnChangeLanguage += OnChangeLanguage;

            //Run the method one first time
            OnChangeLanguage(languageManager);
        }

        void OnDestroy() {
            if (LanguageManager.HasInstance) {
                LanguageManager.Instance.OnChangeLanguage -= OnChangeLanguage;
            }
        }

        void OnChangeLanguage(LanguageManager languageManager) {
            textObject.text = LanguageManager.Instance.GetTextValue(localizedKey);
        }
    }
}

#endif