using Core.Interfaces;
using UnityEngine;

namespace Dialogues
{
    public class Choosing : Interactable
    {
        [SerializeField] private int triggerNo;
        public override void Interact()
        {
            DialogueManager.I.NewBranchDialogue(triggerNo);
            base.Interact();
        }
    }
}