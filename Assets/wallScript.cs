using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class wallScript : MonoBehaviour {
    static public int Score = 0;
	// Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnTriggerEnter(Collider col)
    {
        if (PlayerPrefs.HasKey("Count"))
        {
            if (PlayerPrefs.GetInt("Count") == 1)
            {
                Score++;
                Debug.Log(Score);
                PlayerPrefs.SetInt("Score", Score);
            }
        }
        else
        {
            Debug.Log("Count is Non Existing Key");
        }
    }
}
