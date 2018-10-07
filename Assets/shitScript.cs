using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shitScript : MonoBehaviour {
    public GameObject movingShit;
    int shitY = 9, shitX;
    float createCount = 0.0f;
    bool create = true;
    GameObject shitNow;
    float shitSpeed = 0.1f;
    bool shitAlt;
    float Dur = 7f;
    public Text scoreText;
	// Use this for initialization
	void Start () {
        shitX = Random.Range(-6, 6);
        int sign = Random.Range(-1, 1);
        if (sign == 0) { sign = 1; }
        shitY *= sign;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = ("Score: " + PlayerPrefs.GetInt("Score").ToString());
        if (create)
        {
            if (createCount > Dur)
            {
                shitNow = CreateShit();
                if (shitNow.transform.position.y > 0)
                {
                    shitAlt = true;
                }
                else if (shitNow.transform.position.y < 0)
                {
                    shitAlt = false;
                }
                create = false;
                shitX = Random.Range(-6, 6);
                createCount = createCount - Dur;
                if (Dur > 4) { Dur -= 0.3f; }
                if (shitSpeed < 3 && shitSpeed > 0) { shitSpeed += 0.05f; }
                else if (shitSpeed > -3 && shitSpeed < 0) { shitSpeed -= 0.05f; }
            }
            else
            {
                createCount = createCount + Time.deltaTime;
            }
        }
        if (shitNow != null)
        {
            if (shitAlt)
            {
                shitNow.transform.Translate(0, shitSpeed*-1, 0);
                if (shitNow.transform.position.y <= -7)
                {
                    Destroy(GameObject.Find("Shit"));
                    create = true;
                }
            }
            else if (!shitAlt)
            {
                shitNow.transform.Translate(0, shitSpeed, 0);
                if (shitNow.transform.position.y >= 7)
                {
                    Destroy(GameObject.Find("Shit"));
                    create = true;
                }
            }
        }
        
	}
    GameObject CreateShit()
    {
        GameObject shit = Instantiate(movingShit) as GameObject;
        shit.transform.position = new Vector3(shitX, shitY, 0);
        shit.name = "Shit";
        return shit;

    }
}
