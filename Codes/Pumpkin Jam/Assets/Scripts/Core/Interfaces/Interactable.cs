using System;
using UnityEngine;

namespace Core.Interfaces
{
    public abstract class Interactable : MonoBehaviour
    {
        public bool onlyOneUse;

        public virtual void Interact()
        {
            if (onlyOneUse) OnlyOneUse();
        }

        private void OnlyOneUse()
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}