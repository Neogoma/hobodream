using com.Neogoma.HoboDream.Language;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Neogoma.Hobodream.Examples.Localization
{
    public class LocalizationExample : MonoBehaviour, ISourceCodeLanguageProvider
    {
        private LanguageManager manager;
        public Dropdown languageSelection;
        public Text text;

        private const string FIRST_STRING_KEY = "Thank_you_key";

        private const string SECOND_STRING_KEY = "Good_bye_key";

        // Start is called before the first frame update
        void Start()
        {
            manager = LanguageManager.Instance;
            languageSelection.onValueChanged.AddListener(LanguageSelected);
        }

        private void LanguageSelected(int index)
        {
            switch (index)
            {
                case 1:
                    manager.SetLanguage(SystemLanguage.English);
                    break;
                case 2:
                    manager.SetLanguage(SystemLanguage.French);
                    break;
                case 3:
                    manager.SetLanguage(SystemLanguage.Spanish);
                    break;

                default:
                    Debug.Log("NO LANGUAGE SELECTED");
                    break;
            }
        }

        public void SwitchToValue1()
        {
            text.text = manager.GetLocalizedValue(FIRST_STRING_KEY);
        }

        public void SwitchToValue2()
        {
            text.text = manager.GetLocalizedValue(SECOND_STRING_KEY);
        }

        public List<string> GetAllProvidedKeys()
        {
            List<string> stringKeys = new List<string>();
            stringKeys.Add(FIRST_STRING_KEY);
            stringKeys.Add(SECOND_STRING_KEY);
            return stringKeys;
        }

        public GameObject GetGameObject()
        {
            return this.gameObject;
        }
    }
}