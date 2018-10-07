using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public Text score;
    int scoreValue = 0;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Score"))
        {
            scoreValue = PlayerPrefs.GetInt("Score");
        }
        else
        {
            Debug.Log("Score is Non Existing Key");
            scoreValue = 0;
        }
        score.text = "Your Score Is: " + scoreValue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPlayAgainClicked()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("Game");
    }
}
