using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerConter : MonoBehaviour {

    // Use this for initialization
    float speed = 5;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y = 1;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            y = -1;
        }
        else y = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x = -1;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            x = 1;
        }
        else x = 0;
        Vector2 vSpeed = new Vector2( x, y);
        vSpeed = vSpeed.normalized*speed* Time.deltaTime;

       
        transform.Translate(vSpeed);
    }
}
