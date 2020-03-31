using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioClip scoring;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            //Hold the audioSource
            GameObject obj = GameObject.Find("AudioHolder");
            AudioSource aud = obj.GetComponent<AudioSource>();
            aud.PlayOneShot(scoring, 0.8f);
            
            ScoreKeeper.score += 1;
            Destroy(gameObject);   
        }
    }
}
