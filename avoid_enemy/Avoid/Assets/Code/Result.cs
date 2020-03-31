using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public static string Winning;
    public static Text ResultText;
    void Start()
    {        
        ResultText = GetComponent<Text>();

    }

    private void Awake()
    {
        ResultText = GetComponent<Text>();
        Hide();
    }

    private static void UpdateText()
    {
        ResultText.text = String.Format("YOU {0}", Winning);
    }

    public void Lose()
    {
        Winning = "LOSE";
        UpdateText();
    }
    public void Win () {
        Winning = "WIN";
        UpdateText();
    }
    
    public void Hide ()
    {          
        ResultText.text = "";
    }
}
