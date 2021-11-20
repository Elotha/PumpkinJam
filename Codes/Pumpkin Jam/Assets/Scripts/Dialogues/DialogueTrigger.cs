using UnityEngine;

namespace Dialogues
{
    public class DialogueTrigger : MonoBehaviour
    {
        public int triggerNo;
        [SerializeField] private GameObject[] killTriggers;

        private void Start()
        {
            GetComponent<Renderer>().enabled = DialogueManager.I.showTriggers;
        }

        public void KillTriggers()
        {
            foreach (var t in killTriggers) {
                Destroy(t);
            }
            Destroy(gameObject);
        }
        
    }
}