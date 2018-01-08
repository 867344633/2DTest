using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HeroAnimal : MonoBehaviour {

    public Sprite[] sprites;
    SpriteRenderer render;
    [SerializeField]
    uint fps = 30;
    int index = 0;
    float curTime = 0;
	// Use this for initialization
	void Start () {
        render = GetComponent<SpriteRenderer>();
        if (fps == 0 || fps > 60) fps = 30; 
        curTime = 1.0f / fps;
        index = 0;
        render.sprite = sprites[0];
    }
	
	// Update is called once per frame
	void Update () {
        if ((curTime-=Time.deltaTime) < 0)
        {
            curTime = 1.0f / fps;
            index++;
            if(index>= sprites.Length) { index = 0; }
            render.sprite = sprites[index];
        }
	}
}
