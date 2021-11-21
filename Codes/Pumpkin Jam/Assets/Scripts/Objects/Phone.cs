using Core.Interfaces;
using Dialogues;
using Player;

namespace Objects
{
    public class Phone : Interactable
    {

        public override void Interact()
        {
            PlayerMovement.I.movementPermission = false;
            DialogueManager.OnDialogueFinishEvent += GivePermission;
            base.Interact();
        }

        private static void GivePermission()
        {
            PlayerMovement.I.movementPermission = true;
        }
    }
}