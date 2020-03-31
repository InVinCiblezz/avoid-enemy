using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour {
    public static float score;  // everyone has the same score
    private static Text scoreText; // everyone has the same text


    public bool isRun;
    // Use this for initialization
    internal void Start () {
        scoreText = GetComponent<Text>();
        score = 0;
        UpdateText();
        isRun = true;
    }
    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        score = 0;
    }
    public void Update()
    {
        if(Input.GetKeyDown("escape")) Reset();
        if (isRun)
            UpdateText();
        
        if (score >= 10)
        {
            isRun = false;
            Result rst = GameObject.Find("result").GetComponent<Result> ();
            rst.Win();
        }
    }

    private static void UpdateText()
    {
        scoreText.text = String.Format("Score: {0}", score);
    }
}