using System;
using System.Collections;
using Core.ToolBox;
using UnityEngine;
using UnityEngine.UI;

namespace Other
{
    public class BlackScreenEffect : Singleton<BlackScreenEffect>
    {
        [SerializeField] private Image blackScreen;
        [SerializeField] private float fadeInTime = 3f;
        [SerializeField] private float blackTime;
        [SerializeField] private float fadeOutTime;
        [SerializeField] private float startingTime;

        private void Start()
        {
            StartCoroutine(ChangeColor(true, startingTime));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J)) {
                StartCoroutine(BlackScreenDefault(() => Debug.Log("let's go")));
            }
        }

        public IEnumerator BlackScreenDefault(Action action)
        {
            yield return StartCoroutine(ChangeColor(true, fadeInTime));
            yield return new WaitForSeconds(blackTime /2f);
            action();
            yield return new WaitForSeconds(blackTime /2f);
            yield return StartCoroutine(ChangeColor(false, fadeOutTime));
        }

        public IEnumerator  BlackScreenNew(Action action, float fadeIn, float black, float fadeOut)
        {
            
            yield return StartCoroutine(ChangeColor(true, fadeIn));
            yield return new WaitForSeconds(black /2f);
            action();
            yield return new WaitForSeconds(black /2f);
            yield return StartCoroutine(ChangeColor(false, fadeOut));
        }

        public IEnumerator BlackScreenReset(Action action1, Action action2)
        {
            yield return StartCoroutine(ChangeColor(true, fadeInTime));
            yield return new WaitForSeconds(blackTime /2f);
            action1();
            yield return new WaitForSeconds(blackTime /2f);
            yield return StartCoroutine(ChangeColor(false, fadeOutTime));
            action2();
        }

        private IEnumerator ChangeColor(bool positive, float totalTime)
        {
            var color = blackScreen.color;
            color.a = 0f;
            var time = 0f;
            while (time < totalTime) {
                time += Time.deltaTime;
                color.a = (time / totalTime) * (positive ? 1f : -1f) + (positive ? 0f : 1f);
                color.a = Mathf.Clamp(color.a, 0f, 1f);
                blackScreen.color = color;
                yield return null;
            }
        }
        
        
    }
}