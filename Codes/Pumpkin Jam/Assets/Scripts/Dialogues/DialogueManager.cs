using System.Collections;
using System.Collections.Generic;
using Core;
using Core.ToolBox;
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
                dialogueBackground.enabled = (_currentString != "");
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
        public List<string> paralelChoices = new List<string>();

        public delegate void OnDialogueFinish();
        public static event OnDialogueFinish OnDialogueFinishEvent;

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI dialogueShown;
        [SerializeField] private Image dialogueBackground;
        
        [Header("Debug")]
        public bool showTriggers;
        private void Update()
        {
            HandleInput();
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
                        if (_textCoroutine != null) StopCoroutine(_textCoroutine);
                        DialogueFinish();
                    }
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
                DialogueFinish();
            }
        }

        public void FirstDialogue()
        {
            _targetString = currentDialogue.dialogue[0];
            _nextChoices = currentDialogue.choices;
            _textCoroutine = StartCoroutine(AdvanceText());
        }

        public void NewDialogue(int number)
        {
            if (number > _nextChoices.Count - 1) {
                Debug.LogError("Trigger number exceeded the choices count!");
                return;
            }
            
            // Player chose a path, update the dialogue
            choicesMade.Add(_nextChoices[number].name);
            if (_nextChoices[number].parallelChoice != null) {
                paralelChoices.Add(_nextChoices[number].parallelChoice.name);
            }
            
            currentDialogue = _nextChoices[number];
            if (currentDialogue.choices.Count != 0) {
                _nextChoices = currentDialogue.choices;
            }
            
            CurrentString = "";
            _targetString = currentDialogue.dialogue[0];
            _dialoguePartNo = 0;
            
            StopCoroutine(_textCoroutine);
            _textCoroutine = StartCoroutine(AdvanceText());
        }

        private void DialogueFinish()
        {
            CurrentString = "";
            _targetString = "";
            if (OnDialogueFinishEvent != null) {
                OnDialogueFinishEvent();
                OnDialogueFinishEvent = null;
            }
        }
    }
}