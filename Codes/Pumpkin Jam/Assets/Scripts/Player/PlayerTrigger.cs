using System;
using Dialogues;
using UnityEngine;

namespace Player
{
    public class PlayerTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask triggerLayer;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("DialogueTrigger")) {
                var triggerScript = other.GetComponent<DialogueTrigger>();
                triggerScript.Interact();
            }
        }
    }
}