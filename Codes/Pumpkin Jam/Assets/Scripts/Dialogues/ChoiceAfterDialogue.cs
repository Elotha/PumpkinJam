using UnityEngine;

namespace Dialogues
{
    public class ChoiceAfterDialogue : QuestionOption
    {
        [SerializeField] private GameObject[] addChoices;
        
        public override void Interact()
        {
            DialogueManager.I.NewDialogue(dialogue);
            gameObject.layer = LayerMask.NameToLayer("Default");
            DialogueManager.OnDialogueFinishEvent += AddChoices;
            base.Interact();
        }

        private void AddChoices()
        {
            foreach (var choice in addChoices) {
                choice.SetActive(true);
            }
            gameObject.layer = LayerMask.NameToLayer("Interactable");
        }
    }
}