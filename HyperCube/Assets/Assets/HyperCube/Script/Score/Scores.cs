using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{

    private int platform = 0;
    [SerializeField] private Text Score;
    
    void Start()
    {
        //scoretext = GameObject.Find("ScoreText").GetComponent<Text>();
        StartCoroutine (CountScore());
    }

   IEnumerator CountScore()
   { 
        yield return new WaitForSeconds(0.5f);
        platform++;
        Score.text = "Score: " + platform;
        StartCoroutine (CountScore()); 
    }
}
