using Core.Interfaces;
using Dialogues;
using Player;
using UnityEngine;

namespace Objects
{
    public class Phone : Interactable
    {
        [SerializeField] private GameObject[] activateObjects;

        public override void Interact()
        {
            DialogueManager.I.FirstDialogue();
            PlayerMovement.I.movementPermission = false;
            DialogueManager.OnDialogueFinishEvent += FirstDialogueFinished;
            base.Interact();
        }

        private void FirstDialogueFinished()
        {
            PlayerMovement.I.movementPermission = true;
            foreach (var obj in activateObjects) {
                obj.SetActive(true);
            }
        }
    }
}