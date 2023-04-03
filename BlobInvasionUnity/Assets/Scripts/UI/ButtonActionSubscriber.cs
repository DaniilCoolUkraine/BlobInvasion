using UnityEngine;
using UnityEngine.UI;

namespace BlobInvasion.UI
{
    public abstract class ButtonActionSubscriber : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        protected abstract void OnButtonClicked();
    }
}