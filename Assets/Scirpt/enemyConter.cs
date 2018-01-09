using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BasePlane))]
public class enemyConter : MonoBehaviour {

    // Use this for initialization
    BasePlane plane = null;
    void Start () {
        plane = GetComponent<BasePlane>();
       
    }
	
	// Update is called once per frame
	void Update () {
        if(plane.IsDead == false)
        plane.Shoot(true);
        else
            plane.Shoot(false);
    }
}
