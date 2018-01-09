using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlaneAnimaType
{
    fly,
    bomb,
    hit,
    none,
}
[RequireComponent(typeof(SpriteRenderer))]
public class PlaneAnimal : MonoBehaviour {

    public Sprite[] flysprites;
    public Sprite[] bombsprites;
    public Sprite[] hitsprites;

    
    SpriteRenderer render;
    [SerializeField]
    uint fps = 30;
  
    PlaneAnimaType animalType = PlaneAnimaType.none;
    int index = 0;
    int endIndex = 0;
    Sprite[] curSprites;
    bool bLoop = true;
    float curTime = 0;
	// Use this for initialization
	void Start () {
        render = GetComponent<SpriteRenderer>();
        if (fps == 0 || fps > 60) fps = 30;
        ChangeAnimal(PlaneAnimaType.fly);
    }
	
	// Update is called once per frame
	void Update () {
        if ((curTime-=Time.deltaTime) < 0)
        {
            curTime = 1.0f / fps;
            index++;
            if(index>= curSprites.Length) {
                if (bLoop)
                    index = 0;
                else
                    index = curSprites.Length - 1;
            }
            render.sprite = curSprites[index];
        }
	}
    public void ChangeAnimal(PlaneAnimaType _type)
    {
        if (_type == animalType) return;
        curTime = 1.0f / fps;
        index = 0;
        switch (_type)
        {
            case PlaneAnimaType.fly:
                curSprites = flysprites;
                render.sprite = flysprites[0];
                bLoop = true;
                break;
            case PlaneAnimaType.bomb:
                curSprites = bombsprites;
                bLoop = false;
                break;
        }
    }
}
