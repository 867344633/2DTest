using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    float angle = 0;
    [SerializeField]
    float speed = 1;
	void Start () {
        this.transform.Rotate(new Vector3(0, 0, angle));
    }
	
	// Update is called once per frame
	void Update () {
        angle += Time.deltaTime * speed;
        if (angle >= 360) angle = 0;
        this.transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed))   ;
   
    }
}
