using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour {
    [SerializeField]
    float delay = 5;
    // Use this for initialization
    float curDelay = 0;
	void Start () {
        curDelay = delay;
    }
	
	// Update is called once per frame
	void Update () {
        curDelay -= Time.deltaTime;
        if (curDelay < 0) Destroy(gameObject);
    }
}
