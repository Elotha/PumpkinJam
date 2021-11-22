using Other;
using Player;
using UnityEngine;

namespace Dialogues
{
    public class ResetTrigger : DialogueTrigger
    {
        public override void Interact()
        {
            base.Interact();
            PlayerMovement.I.movementPermission = false;
            DialogueManager.OnDialogueFinishEvent += AfterDialogue;
        }

        private void AfterDialogue()
        {
            BlackScreenEffect.I.StartCoroutine(BlackScreenEffect.I.BlackScreenReset(TeleportPlayer, 
                                                   StartNewDialogue));
        }

        private static void TeleportPlayer()
        {
            Debug.Log("teleport");
            var transform1 = PlayerMovement.I.transform;
            transform1.position = PlayerMovement.startPoint;
            transform1.localRotation = PlayerMovement.startRotation;
        }

        private static void StartNewDialogue()
        {
            DialogueManager.OnDialogueFinishEvent += GivePermission;
        }

        private static void GivePermission()
        {
            PlayerMovement.I.movementPermission = true;
        }
    }
}