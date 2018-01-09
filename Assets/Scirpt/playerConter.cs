using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BasePlane))]
public class playerConter : MonoBehaviour {

    // Use this for initialization
    float speed = 5;
    BasePlane plane;
	void Start () {
        plane = GetComponent<BasePlane>();
    }
	
	// Update is called once per frame
	void Update () {
        if (plane.IsDead) return;
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y = 1;
            print("Input.GetKey(KeyCode.UpArrow)");
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


        if (Input.GetKeyDown(KeyCode.W))
        {
            plane.Shoot(true);
        }
         if(Input.GetKeyUp(KeyCode.W))
        {
            plane.Shoot(false);
        }
      
        Vector2 vSpeed = new Vector2( x, y);
        vSpeed = vSpeed.normalized*speed* Time.deltaTime;

       
        transform.Translate(vSpeed);
    }
}
