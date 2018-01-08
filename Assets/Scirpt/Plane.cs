using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

    BaseWeapon weaponPrefab;
    BaseWeapon curWeapon;
    // Use this for initialization
    void Start () {
        curWeapon = GameObject.Instantiate(weaponPrefab);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void ChangeWeapon()
    {

    }
}
