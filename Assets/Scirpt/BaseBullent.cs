using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direct
{
    up,
    down,
    none
}
public class BaseBullent : MonoBehaviour {
 
    [SerializeField]
    public Direct direct = Direct.none;

    float time = 5.0f;

 
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
    public void OnTriggerEnter2D(Collider2D _other)
    {

    }
    /// <summary>
    /// 旋转向量，使其方向改变，大小不变
    /// </summary>
    /// <param name="v">需要旋转的向量</param>
    /// <param name="angle">旋转的角度</param>
    /// <returns>旋转后的向量</returns>
  
}
