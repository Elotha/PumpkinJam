using Core.Interfaces;
using UnityEngine;

namespace Dialogues
{
    public class QuestionOption : Interactable
    {
        [SerializeField] private int triggerNo;
        public override void Interact()
        {
            DialogueManager.I.NewDialogue(triggerNo);
            gameObject.layer = LayerMask.NameToLayer("Default");
            DialogueManager.OnDialogueFinishEvent += ActivateLayer;
            base.Interact();
        }

        private void ActivateLayer()
        {
            gameObject.layer = LayerMask.NameToLayer("Interactable");
        }
    }
}