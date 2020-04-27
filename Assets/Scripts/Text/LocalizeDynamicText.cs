using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace _0Game.Scripts.Text
{
    public class LocalizeDynamicText : MonoBehaviour, ITextLocalizer, ITextSetter
    {
        [SerializeField] protected string[] localizations;
        [SerializeField] protected string[] standartVal;
        [Required][SerializeField] private TextMeshProUGUI _mainText;

        protected int lang;
        private object[] _lastVal;


        private void OnEnable()
        {
            _lastVal = standartVal;
            MakeALink();
        }

        private void OnDisable()
        {
            RemoveALink();
        }

        public void MakeALink() => LocalizationManager.Instance.Link(this);
        public void RemoveALink() => LocalizationManager.Instance.UnLink(this);
        
        public void ChangeLanguague(int langIndex)
        {
            lang = langIndex;
            SetText(_lastVal);
        }

        public virtual void SetText(params object[] values)
        {
            _lastVal = values;
            _mainText.text = string.Format(localizations[lang], values);
        }
        
        [Button]
        public virtual void GetTextComponents()
        {
            _mainText = GetComponent<TextMeshProUGUI>();
        }
        [Button]
        public void SetEditorText(int langv)
        {
            lang = langv;
            SetText(standartVal);

        }
    }
}
