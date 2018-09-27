using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {
    public int nivel = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("Nivel").GetComponent<Text>().text = nivel.ToString();
        /*
        if (nivel > 7)
        {
            GameObject.Find("2").gameObject.SetActive(true);
        }
        */
	}
}
