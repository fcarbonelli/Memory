using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.cyan, Color.magenta, Mathf.PingPong(Time.time * 0.25f, 1.0f));
    }
}
