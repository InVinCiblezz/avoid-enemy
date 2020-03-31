using UnityEngine;


public class DieOnCollision : MonoBehaviour
{
    public AudioClip dying;

    internal void OnCollisionEnter2D(Collision2D obstacle)
    {
        //Die = true;
        if (obstacle.collider.CompareTag("enemy"))
        {
            //Hold the audioSource
            GameObject obj = GameObject.Find("AudioHolder");
            AudioSource aud = obj.GetComponent<AudioSource>();
            aud.PlayOneShot(dying, 0.8f);
            
            Result rst = GameObject.Find("result").GetComponent<Result> ();
            rst.Lose();
            ScoreKeeper s = GameObject.Find("score").GetComponent<ScoreKeeper> ();
            s.isRun = false;
            Enemy.Die();
            Destroy(gameObject);
        }
    }

   
}
