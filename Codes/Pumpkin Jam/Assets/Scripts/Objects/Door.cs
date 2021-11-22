using System;
using Core.Interfaces;
using UnityEngine;

namespace Objects
{
    public class Door : Interactable
    {
        public bool opened;
        public bool opening;
        [SerializeField] private Transform bone;
        [SerializeField] private BoxCollider boxCollider;

        private void Start()
        {
            boxCollider = GetComponent<BoxCollider>();
        }

        public override void Interact()
        {
            if (!opening) {
                if (opened) {
                    bone.localRotation = Quaternion.Euler(90f,0f,0f);
                }
                else {
                    bone.localRotation = Quaternion.Euler(180f,90f,90f);
                }

                opened = !opened;
                boxCollider.enabled = !boxCollider.enabled;
            }
        }
    }
}