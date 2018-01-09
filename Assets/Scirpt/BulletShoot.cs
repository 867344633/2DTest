using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour {
    [SerializeField]
    BulletType bulletType;
   public float rate = 1;
    [SerializeField]
    Direct direct = Direct.none;
    // Use this for initialization
    float curTime = 0;
    bool bShoot = false;

   
    BasePlane owner;
    BaseBullent lineBullet;
    public BasePlane Owner
    {
        get
        {
            return owner;
        }
        set
        {
            owner = value;
        }
    }
    void Start () {
        curTime = 0;
        lineBullet = null;
    }
	
	// Update is called once per frame
	void Update () {
        curTime -= Time.deltaTime;
        if (bShoot == true)
        {
            if (curTime <= 0 && lineBullet == null)
            {
           
               BaseBullent obj = GameManager.instance.CreateBullet(bulletType);
                obj.transform.position = this.transform.position;
                obj.direct = direct;
                obj.Owner = Owner;
                BaseTrack track = obj.GetComponent<BaseTrack>();
                if(track!= null)
                obj.GetComponent<BaseTrack>().rotation = transform.eulerAngles.z;
                curTime = 1 / rate;

                if (obj.IsLine == true)
                {
                    lineBullet = obj;
                    lineBullet.transform.SetParent(this.transform);
                    lineBullet.transform.localPosition = Vector3.zero;
                }
            }
        }
	}
    public void Shoot(bool _bShoot)
    {
        bShoot = _bShoot;
        if(lineBullet != null && bShoot == false)
        {
            
            GameObject.Destroy(lineBullet.gameObject);
            lineBullet = null;
        }
    }
}
