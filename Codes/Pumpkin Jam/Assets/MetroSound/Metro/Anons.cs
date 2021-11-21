using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anons : MonoBehaviour
{
    public AudioClip anons;

    void Start()
    {
        StartCoroutine(Ses());
    }

    IEnumerator Ses()
    {
        AudioSource.PlayClipAtPoint(anons, transform.position, 1);
        yield return new WaitForSeconds(300);
    }
}
