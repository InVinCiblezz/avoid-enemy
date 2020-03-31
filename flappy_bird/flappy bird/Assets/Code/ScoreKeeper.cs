using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    public static int Score; 
    private static Text _scoreText; 
    void Start()
    {
        _scoreText = GetComponent<Text>();
        Score = 0;
    }
    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetKeyDown("escape")) Reset();

        UpdateText();
    }
    
    private static void UpdateText()
    {
        _scoreText.text = String.Format("score: {0}", Score);
    }
}
