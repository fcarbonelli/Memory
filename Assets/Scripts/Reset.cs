using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ResetLevel()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
        GameObject.Find("Canvas").gameObject.GetComponent<ParticleSystem_CameraLocator>().RestartCanvasRenderCamera();

        GameObject.Find("Time_Slider").GetComponent<TimeCS>().Awake();
        GameObject.Find("GameOverMENU").gameObject.SetActive(false);

        GameObject.Find("Canvas").GetComponent<Level>().nivel = 1;
        GameObject.Find("Canvas").GetComponent<Level>().puntos = 0;
        GameObject.Find("Puntos").GetComponent<Multiplier>().combo= 1;
        GameObject.Find("Nivel").GetComponent<Text>().text = "1";

    }
}
