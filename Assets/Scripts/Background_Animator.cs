using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Animator : MonoBehaviour {
    public Transform transform1;
    public Transform transform2;
    public GameObject cloud;
	// Use this for initialization
	void Start () {
        cloud = this.gameObject;    
	}

	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, transform2.position, 0.001f);
        if (this.gameObject.transform.position == transform2.position)
        {

            GameObject clouds = (GameObject)Instantiate(cloud, transform1.position, transform.rotation);
            Destroy(this.gameObject);

        }
    }
}
