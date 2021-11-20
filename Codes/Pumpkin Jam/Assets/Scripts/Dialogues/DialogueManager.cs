using System.Collections;
using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogues
{
    public class DialogueManager : Singleton<DialogueManager>
    {
        private string _currentString = "";
        private string CurrentString {
            get => _currentString;
            set {
                _currentString = value;
                dialogueShown.text = _currentString;
                dialogueBackground.enabled = (value != "");
            }
        }
        private string _targetString = "";
        private int _characterNo;
        private int _dialoguePartNo;
        private Coroutine _textCoroutine;
        private Coroutine _textCountdown;
        private List<Dialogue> _nextChoices = new List<Dialogue>();
        
        [Header("General")]
        [SerializeField] private float newCharacterTime;
        [SerializeField] private float maximumShowTime;
        [SerializeField] private Dialogue currentDialogue;
        public List<string> choicesMade = new List<string>();

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI dialogueShown;
        [SerializeField] private Image dialogueBackground;
        
        [Header("Debug")]
        public bool showTriggers;
        
        
        private void Start()
        {
            _targetString = currentDialogue.dialogue[0];
            _nextChoices = currentDialogue.choices;
            _textCoroutine = StartCoroutine(AdvanceText());
        }

        private void Update()
        {
            HandleInput();

            // TemporaryTriggers();
        }

        private void HandleInput()
        {
            if (Input.GetButtonDown("Interact")) {
                if (CurrentString != _targetString) {
                    CurrentString = _targetString;
                }
                else {
                    if (_dialoguePartNo != currentDialogue.dialogue.Length - 1) {
                        CurrentString = "";
                        _targetString = currentDialogue.dialogue[++_dialoguePartNo];
                        _textCoroutine = StartCoroutine(AdvanceText());
                    }
                    else {
                        CurrentString = "";
                        _targetString = "";
                    }
                }
            }
        }

        private void TemporaryTriggers()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                if (currentDialogue.choices.Count > 0) {
                    NewDialogue(0);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                if (currentDialogue.choices.Count > 1) {
                    NewDialogue(1);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                if (currentDialogue.choices.Count > 2) {
                    NewDialogue(2);
                }
            }
        }

        private IEnumerator AdvanceText()
        {
            // Text appears gradually
            _characterNo = 1;
            while (CurrentString != _targetString) {
                CurrentString = _targetString.Substring(0, _characterNo++);
                yield return new WaitForSeconds(newCharacterTime);
            }
            
            // If this is the last part of the dialogue, make it disappear 
            // after a while
            if (_dialoguePartNo == currentDialogue.dialogue.Length - 1) {
                yield return new WaitForSeconds(maximumShowTime);
                CurrentString = "";
                _targetString = "";
            }
        }

        public void NewDialogue(int number)
        {
            if (number > currentDialogue.choices.Count - 1) {
                Debug.LogError("Trigger number exceeded the choices count!");
                return;
            }
            
            // Player chose a path, update the dialogue
            choicesMade.Add(currentDialogue.choices[number].name);
            currentDialogue = currentDialogue.choices[number];
            _nextChoices = currentDialogue.choices;
            
            CurrentString = "";
            _targetString = currentDialogue.dialogue[0];
            _dialoguePartNo = 0;
            
            StopCoroutine(_textCoroutine);
            _textCoroutine = StartCoroutine(AdvanceText());
        }
    }
}