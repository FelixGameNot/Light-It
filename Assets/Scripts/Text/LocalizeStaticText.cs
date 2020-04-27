using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace _0Game.Scripts.Text
{
    public class LocalizeStaticText : MonoBehaviour, ITextLocalizer
    {
        [SerializeField] protected string[] localizations;
        [SerializeField][Required] private TextMeshProUGUI _mainText;

        private void OnEnable()
        {
            MakeALink();
        }
        
        private void OnDisable()
        {
            RemoveALink();
        }
        public void MakeALink()=>LocalizationManager.Instance.Link(this);
        public void RemoveALink() => LocalizationManager.Instance.UnLink(this);

        [Button]
        public virtual void ChangeLanguague(int langIndex)
        {
            _mainText.text = localizations[langIndex];
        }
        
        [Button]
        public virtual void GetTextComponents()
        {
            _mainText = GetComponent<TextMeshProUGUI>();
        }
        
        
    }
}
