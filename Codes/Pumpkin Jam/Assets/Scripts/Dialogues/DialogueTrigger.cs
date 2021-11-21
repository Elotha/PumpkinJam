using UnityEngine;
using UnityEngine.Serialization;

namespace Dialogues
{
    public class DialogueTrigger : MonoBehaviour
    {
        public Dialogue dialogue;
        [FormerlySerializedAs("killTriggers")] 
        [SerializeField] private GameObject[] toBeDeactivated;
        [SerializeField] private GameObject[] toBeActivated;

        private void Start()
        {
            GetComponent<Renderer>().enabled = DialogueManager.I.showTriggers;
        }

        public virtual void Interact()
        {
            DialogueManager.I.NewDialogue(dialogue);
            DialogueManager.OnDialogueFinishEvent += AdjustTriggers;
        }

        private void AdjustTriggers()
        {
            foreach (var t in toBeDeactivated) {
                t.SetActive(false);
            }
            foreach (var t in toBeActivated) {
                t.SetActive(true);
            }
            gameObject.SetActive(false);
        }
        
    }
}