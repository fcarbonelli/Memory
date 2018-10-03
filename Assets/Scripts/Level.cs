using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {
    public int nivel = 1;
    public int puntos = 0;
	// Use this for initialization
	void Start () {
        puntos = 0;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("Nivel").GetComponent<Text>().text = nivel.ToString();
        GameObject.Find("Puntos").GetComponent<Text>().text = puntos.ToString() + " x" +GameObject.Find("Puntos").GetComponent<Multiplier>().combo.ToString();
        

        /*
        if (nivel > 7)
        {
            GameObject.Find("2").gameObject.SetActive(true);
        }
        */
    }
}
