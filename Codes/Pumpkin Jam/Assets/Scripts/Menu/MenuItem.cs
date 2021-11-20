using UnityEngine;

namespace Menu
{
    public class MenuItem : MonoBehaviour
    {
        protected virtual string Name { get; set; }
        public GameObject menuObject;

        private void Enable()
        {
            menuObject.SetActive(true);
        }

        private void Disable()
        {
            menuObject.SetActive(false);
        }
        public virtual void Interact()
        {
            MenuManager.I.DisableLast();
            Enable();
            MenuManager.I.AddItem(this);
        }
        
        public virtual void Back() {
            Disable();
            MenuManager.I.RemoveItem(this);
            MenuManager.I.EnableLast();
        }
    }
}