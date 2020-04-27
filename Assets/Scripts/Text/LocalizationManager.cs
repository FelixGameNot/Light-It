using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _0Game.Scripts.Text
{
    public class LocalizationManager : MonoBehaviour
    {

        public int lang;

        public static LocalizationManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private readonly List<ITextLocalizer> _textComponents = new List<ITextLocalizer>();

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            ChangeLanguagues();
        }

        public void Link(ITextLocalizer sender)
        {
            _textComponents.Add(sender);
        }

        public void UnLink(ITextLocalizer sender)
        {
            _textComponents.Remove(sender);
        }
        
        public void ChangeLanguagueOn(int id)
        {
            foreach (var text in _textComponents)
            {
                text.ChangeLanguague(id);
            }
        }

        [Button(ButtonSizes.Large)]
        public void ChangeLanguagues()
        {
            foreach (var text in _textComponents)
            {
                text.ChangeLanguague(lang);
            }
        }

    }
}