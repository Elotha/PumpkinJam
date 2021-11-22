using Core.Interfaces;
using UnityEngine;

namespace Dialogues
{
    public class QuestionOption : Interactable
    {
        [SerializeField] protected Dialogue dialogue;
        public override void Interact()
        {
            DialogueManager.I.NewDialogue(dialogue);
            gameObject.layer = LayerMask.NameToLayer("Default");
            DialogueManager.OnDialogueFinishEvent += ActivateLayer;
            base.Interact();
        }

        protected void ActivateLayer()
        {
            gameObject.layer = LayerMask.NameToLayer("Interactable");
        }
    }
}