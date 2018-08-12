﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColor : MonoBehaviour {

    SpriteRenderer renderer;
    
    public bool isPath, trigger;
    public int x, y = 0;
    public List<int> tileX = new List<int>();
    public List<int> tileY = new List<int>();

    public int numeroT;
    public GameObject generator;

    // Use this for initialization
    void Start ()
    {
        renderer = GetComponent<SpriteRenderer>();
        tileX.Clear(); tileY.Clear();
        generator = GameObject.Find("PathGenerator");
        
	}
	
	// Update is called once per frame
	void Update () {
        numeroT = generator.GetComponent<GeneratePath>().numeroTile;

        if (isPath && trigger == false)
        {
            StartCoroutine(showPath());
            trigger = true;
        }
    }

    IEnumerator showPath()
    {

        SetBlue();
        yield return new WaitForSeconds(1f);
        SetGrety();

    }

    private void OnMouseDown()
    {
        if (isPath)
        {
            if (generator.GetComponent<GeneratePath>().posX[numeroT] == x && generator.GetComponent<GeneratePath>().posY[numeroT] == y)
            {
                SetGreen();
                generator.GetComponent<GeneratePath>().numeroTile++;
            }
            else
            {
                SetRed();
            }
           
        }
        else
        {
            SetRed();
        }
    }

    public void SetGreen()
    {
        renderer.color = new Color(0f, 220f, 0f, 1f); //VERDE
    }
    public void SetRed()
    {
        renderer.color = new Color(255f, 0f, 0f, 1f); //ROJO
    }
    public void SetBlue()
    {
        renderer.material.color = new Color(0f, 100f, 255f, 1f); //AZUL
        Debug.Log("ass");
    }
    public void SetGrety()
    {
        renderer.material.color = Color.white; //GRIS

    }
}
