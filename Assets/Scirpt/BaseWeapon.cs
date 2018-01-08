using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour {

    // Use this for initialization
    BulletShoot[] lsShoot;
	void Start () {
        lsShoot = this.GetComponentsInChildren<BulletShoot>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Shoot(bool _bShoot)
    {
        for(int i = 0; i < lsShoot.Length; ++i)
        {
            lsShoot[i].Shoot(_bShoot);
        }
    }
}
