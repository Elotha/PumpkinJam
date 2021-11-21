using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public int index = 1;
    public bool isTriggered = false;
    public bool played = false;
    [SerializeField]public AudioClip[] sound = new AudioClip[1];
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            played = false;
        }
    }
    private void Update()
    {
        PlaySound();
    }
    private void PlaySound()
    {
        if (isTriggered && !played)
        {
            for(int i = 0; i < index; i++)
            {
                AudioSource.PlayClipAtPoint(sound[i], transform.position, 1);
            }
            played = true; 
        }
        else
        {

        }
    }
}
