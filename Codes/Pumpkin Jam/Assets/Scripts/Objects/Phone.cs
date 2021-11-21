using System;
using Core.Interfaces;
using Dialogues;
using Player;
using UnityEngine;

namespace Objects
{
    public class Phone : Interactable
    {

        public override void Interact()
        {
            PlayerMovement.I.movementPermission = false;
            DialogueManager.onDialogueFinish += GivePermission;
            base.Interact();
        }

        private static void GivePermission()
        {
            PlayerMovement.I.movementPermission = true;
        }
    }
}