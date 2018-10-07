using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {
    bool stop = false, move = false, mainMove = true;
    float dir = 0.4f;
    int countBool = 1;
	// Use this for initialization
	void Start () {
        int sign = Random.Range(-1, 1);
        if (sign == 0) { sign = 1; }
        dir *= sign;
	}
	
	// Update is called once per frame
	void Update () {
        if (!stop && move)
        {
            transform.Translate(dir, 0f, 0f);
            if (transform.position.x > 8) { transform.Translate((dir / 2.0f) * -1, 0f, 0f); }
            else if (transform.position.x < -8) { transform.Translate((dir/2.0f) * -1, 0f, 0f); }
            if (Input.GetKeyDown(KeyCode.Space) && !mainMove)
            {
                dir *= -1;
                mainMove = true;
                countBool = -1;
                PlayerPrefs.SetInt("Count", countBool);
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            move = true;
            stop = false;
            mainMove = false;
            countBool = 1;
            PlayerPrefs.SetInt("Count", countBool);
        }
	}
    void OnTriggerEnter(Collider col)
    {
        if (transform.position.x > 8) { if (dir > 0) { dir *= -1; } }
        else if (transform.position.x < -8) { if (dir < 0) { dir *= -1; } }
        stop = true;
        
    }
}
