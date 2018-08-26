using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {
   
    
    public float speed = 10f;
    float timer = 0f;
    int cant = 0;

	// Use this for initialization
	void Start () {

        transform.position = new Vector3(GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower[1].x, transform.position.y);
        //GetPath();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (cant < GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower.Count)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower[cant], speed*Time.deltaTime);

            timer += Time.deltaTime;
            if (timer >= .25f)
            {

                cant++;
                timer = 0f;

            }
        }
        else if(cant >= GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower.Count)
        { transform.position += Vector3.up * Time.deltaTime;}
	}

    public void GetPath()
    {
        int pos = GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower.Count;

        Vector3 vec = new Vector3(
            GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower[pos].x,
            GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower[pos].y +1,
            GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower[pos].z);

        GameObject.Find("PathGenerator").GetComponent<GeneratePath>().pathFollower.Add(vec);
    }
}
