using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour {

    [SerializeField]
    WeaponPos posType = WeaponPos.none;
    // Use this for initialization
    BulletShoot[] lsShoot;
    BasePlane owner;
    public BasePlane Owner{
        get
        {
            return owner;
        }
        set
        {
            owner = value;
        }
    }
    public WeaponPos GetPosType()
    {
        return posType;
    }
	void Start () {
        lsShoot = this.GetComponentsInChildren<BulletShoot>();
        for(int i = 0; i < lsShoot.Length; ++i)
        {
            lsShoot[i].Owner = Owner;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Shoot(bool _bShoot)
    {
        if(lsShoot != null)
        for(int i = 0; i < lsShoot.Length; ++i)
        {
            lsShoot[i].Shoot(_bShoot);
        }
    }
}
