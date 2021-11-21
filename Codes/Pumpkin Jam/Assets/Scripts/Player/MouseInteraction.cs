using Core.Interfaces;
using UnityEngine;

namespace Player
{
    public class MouseInteraction : MonoBehaviour
    {
        private bool _possibleInteraction;
        private bool PossibleInteraction {
            get => _possibleInteraction;
            set {
                if (_possibleInteraction != value) {
                    _possibleInteraction = value;
                    instructionBox.SetActive(value);
                }
                
            }
        }

        private Camera _cam;

        private LayerMask _interactableMask;
        [SerializeField] private float maxDistance;
        
        [SerializeField] private GameObject instructionBox;
        

        private void Start()
        {
            _cam = Camera.main;
            _interactableMask = LayerMask.GetMask("Interactable");
        }

        private void Update()
        {
            Interaction();
        }

        private void Interaction()
        {
            var ray = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, maxDistance, _interactableMask)) {
                
                if (Input.GetButtonDown("Fire1")) {
                    var interactable = hit.transform.GetComponent<Interactable>();
                    if (interactable != null) {
                        interactable.Interact();
                        PossibleInteraction = false;
                        return;
                    }
                }
                PossibleInteraction = true;
                return;
            }
            PossibleInteraction = false;
        }
    }
}