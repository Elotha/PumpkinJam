using System.Collections.Generic;
using UnityEngine;

namespace Dialogues
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 0)]
    public class Dialogue : ScriptableObject
    {
        public new string name = "New Name";
        public bool isBranching;
        public string[] dialogue;
        public List<Dialogue> choices = new List<Dialogue>();
        public Dialogue parallelChoice;
    }
}