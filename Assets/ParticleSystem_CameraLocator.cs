using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem_CameraLocator : MonoBehaviour {
    Camera maincamera;

	// Use this for initialization
	void Start () {
        maincamera = FindObjectOfType<Camera>();
        
	}
	
	// Update is called once per frame
	void Update () {
        maincamera = FindObjectOfType<Camera>();
        this.gameObject.GetComponent<Canvas>().worldCamera = maincamera;
    }
   public void RestartCanvasRenderCamera()
    {

    }
}
