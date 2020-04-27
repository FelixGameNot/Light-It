using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace _0Game.Scripts.Text
{
    public class SetDynamicText : MonoBehaviour, ITextSetter
    {
        
        [SerializeField] protected string textShape;
        [SerializeField] [Required] private TextMeshProUGUI _mainText;

        public virtual void SetText(params object[] values)
        {
            _mainText.text = string.Format(textShape, values);
        }
        
        [Button]
        public virtual void GetTextComponents()
        {
            _mainText = GetComponent<TextMeshProUGUI>();
        }
    }
}