using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullent : MonoBehaviour {
 
    [HideInInspector]
    public Direct direct = Direct.none;
    [SerializeField]
    float hitFactor = 1.0f;//伤害系数
    [SerializeField]
    bool bStrike = false; //是否穿透
    [SerializeField]
    bool isLine = false;
    float time = 5.0f;

    BasePlane owner;
 
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
    public bool IsLine {
        get
        {
            return isLine;
        }
    }
    bool bDead = false;
	void Start () {
        time = 5.0f;
       


    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0) bDead = true;

        if(bDead == false)
        {
 
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
      
	}
    public void SetOwner(BasePlane _owner) { owner = _owner; }
    public void OnTriggerEnter2D(Collider2D _other)
    {
        if(owner != null)
        {
          
            if(owner.tag == "Player" && _other.tag == "enemy") //如果等于玩家 且碰撞的是敌方
            {
                OnHit(_other.GetComponent<BasePlane>());
            }
            else if (owner.tag == "enemy" && _other.tag == "Player")
            {
                OnHit(_other.GetComponent<BasePlane>());
            }
        }
    }

    public virtual void OnHit(BasePlane _plane)
    {
        _plane.OnHit(owner.Atk * this.hitFactor);
        if(bStrike == false)
        {
            OnBomb();
        }
    }
    public virtual void OnBomb()
    {
        GameObject.Destroy(this.gameObject);
    }
    /// <summary>
    /// 旋转向量，使其方向改变，大小不变
    /// </summary>
    /// <param name="v">需要旋转的向量</param>
    /// <param name="angle">旋转的角度</param>
    /// <returns>旋转后的向量</returns>
  
}
