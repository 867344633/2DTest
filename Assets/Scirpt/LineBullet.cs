using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBullet : BaseBullent {

    public GameObject Line;
    public GameObject FXef;//激光击中物体的粒子效果
                           // Use this for initialization
                           // Update is called once per frame
    public int distance = 10;

    void Start()
    {
        if (direct == Direct.down)
        {
            transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }
    void Update()
    {
        RaycastHit2D[] hits;
        Vector3 Sc;// 变换大小
        Sc.x = 0.1f;
        Sc.z = 0.1f;

        //发射射线，通过获取射线碰撞后返回的距离来变换激光模型的y轴上的值
        hits = Physics2D.RaycastAll(transform.position, this.transform.forward, distance);
        Sc.y = distance;
        if (hits.Length >0)
        {
            for (int i = 0; i < hits.Length; ++i)
            {
                RaycastHit2D hit = hits[i];

               
                if (Owner.tag == "Player" && hit.collider.tag == "enemy") //如果等于玩家 且碰撞的是敌方
                {
                    OnHit(hit.collider.GetComponent<BasePlane>());
                    //Debug.DrawLine(this.transform.position,hit.point);
                    Sc.y = hit.distance;
                    FXef.transform.position = hit.point;//让激光击中物体的粒子效果的空间位置与射线碰撞的点的空间位置保持一致；
                    FXef.SetActive(true);
                    break;
                }
                else if (Owner.tag == "enemy" && hit.collider.tag == "Player")
                {
                    OnHit(hit.collider.GetComponent<BasePlane>());
                    //Debug.DrawLine(this.transform.position,hit.point);
                    Sc.y = hit.distance;
                    FXef.transform.position = hit.point;//让激光击中物体的粒子效果的空间位置与射线碰撞的点的空间位置保持一致；
                    FXef.SetActive(true);
                    break;
                }
            }
          
               
 
        }
      
        //当激光没有碰撞到物体时，让射线的长度保持为500m，并设置击中效果为不显示
        else
        {
            Sc.y = 500;
            FXef.SetActive(false);
        }

    
        Line.transform.localScale = Sc;

    }
    public override void OnBomb()
    {
         
    }
}
