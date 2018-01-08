using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour {
    [SerializeField]
    GameObject bullent ;
   public float rate = 1;
    [SerializeField]
    Direct direct = Direct.none;
    // Use this for initialization
    float curTime = 0;
    bool bShoot = true;
	void Start () {
        curTime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        curTime -= Time.deltaTime;
        if (curTime <= 0)
        {
            if(bShoot == true)
            {
               GameObject obj =  GameObject.Instantiate(bullent);
                obj.transform.position = this.transform.position;
                obj.GetComponent<BaseBullent>().direct = direct;
                obj.GetComponent<BaseTrack>().rotation = transform.eulerAngles.z;
                curTime = 1 / rate;
            }
        }
	}
    public void Shoot(bool _bShoot)
    {
        bShoot = _bShoot;
    }
}
