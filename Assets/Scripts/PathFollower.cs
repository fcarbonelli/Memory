using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {
   
    
    public float speed = 5f;
    float timer = 0f;
    int cant = 0;

	// Use this for initialization
	void Start () {

        //transform.position = new Vector3(GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower[1].x, transform.position.y);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (cant < GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower.Count)
        {
            if (transform.position != GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower[cant])
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower[cant], speed*Time.deltaTime);
            }
            else
            {
                cant++; 
            }
          
        }
        else if(cant >= GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower.Count)
        {
            transform.position += Vector3.up * Time.deltaTime * 2f;
            
        }
	}

    
}
