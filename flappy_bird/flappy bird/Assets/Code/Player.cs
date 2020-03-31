using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip dying;
    public AudioClip scoring;
    public AudioClip jumping;

    private float horizontalVelocity = 4f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(horizontalVelocity, 0);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = GameObject.Find("AudioHolder");
            AudioSource aud = obj.GetComponent<AudioSource>();
            aud.PlayOneShot(jumping, 1.5f);
            
            rb.velocity = new Vector2(horizontalVelocity, Vector2.up.y * 30f);
            //rb.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
        }

        if (ScoreKeeper.Score == 7)
        {
            Result rst = GameObject.Find("result").GetComponent<Result> ();
            rst.Win();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.CompareTag("Score"))
        {
            GameObject obj = GameObject.Find("AudioHolder");
            AudioSource aud = obj.GetComponent<AudioSource>();
            aud.PlayOneShot(scoring, 0.8f);
            //Debug.Log("score!");
            ScoreKeeper.Score += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D obstacle)
    {
        GameObject obj = GameObject.Find("AudioHolder");
        AudioSource aud = obj.GetComponent<AudioSource>();
        aud.PlayOneShot(dying, 0.8f);
            
        Result rst = GameObject.Find("result").GetComponent<Result> ();
        //Debug.Log("dead!");
        rst.Lose();
            
        Destroy(gameObject);
    }
}
