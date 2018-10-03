using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour {
    public bool recent_mistake = false;
    public int cant;
    public int combo;
    public Animation anim;
    public int cantcombo;
    // Use this for initialization
    void Start () {
        combo = 1;
        cant = 0;
        cantcombo = 5;
       anim.wrapMode = WrapMode.Once;
    }
	
	// Update is called once per frame
	void Update () {
        if (recent_mistake)
        {
            combo = 1;
            recent_mistake = false;
        }
	}

    public void AgregarPuntos()
    {
        if (cant < cantcombo)
        {
            GameObject.Find("Canvas").GetComponent<Level>().puntos += combo;
            cant += 1;
           anim.Stop();
        }
        else
        {
            cantcombo += 1;
            cant = 0;
            combo += 1;
            anim.Play();
   
        }
        
    }
}
