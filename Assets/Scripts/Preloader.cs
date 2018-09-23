using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour {

    private CanvasGroup fadeGroup;
    private float loadTime;
    private float logoTime = 3.5f;

	// Use this for initialization
	void Start ()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>();
        fadeGroup.alpha = 0;

        if (Time.time < logoTime)
        {
            loadTime = logoTime;
        }
        else { loadTime = Time.time; }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > logoTime && loadTime != 0)
        {
            fadeGroup.alpha = Time.time - logoTime;
            if (fadeGroup.alpha >= 1)
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            }
        }	
	}
}
