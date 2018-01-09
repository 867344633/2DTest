using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrack : MonoBehaviour {
    
    public float speed = 10;
    [HideInInspector]
    public float rotation = 0;
    Vector2 vSpeed = new Vector2(0, 1);
    [SerializeField]
    Direct direct = Direct.none;
    // Use this for initialization
    // Use this for initialization
    void Start () {
        if (direct == Direct.down) rotation = 180 + rotation;
        vSpeed = RotationMatrix(vSpeed * speed, rotation);
    }
	
	// Update is called once per frame
	void Update () {
        //   this.gameObject.transform.Translate(0, -speed * Time.deltaTime, 0);
        this.gameObject.transform.Translate(vSpeed * Time.deltaTime);
    }
    private Vector3 RotationMatrix(Vector2 v, float angle)
    {
        var x = v.x;
        var y = v.y;

        var sin = Math.Sin(Math.PI * angle / 180);
        var cos = Math.Cos(Math.PI * angle / 180);
        var newX = x * -cos + y * -sin;
        var newY = x * -sin + y * cos;
        return new Vector2((float)newX, (float)newY);
    }
  
}
