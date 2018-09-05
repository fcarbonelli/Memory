using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class TimeCS : MonoBehaviour
{
    public bool created = false;
    public bool islevelon;
    public float current_time;
    public float default_time;

    public float penalty_time;
    public float fault_time;
    public float bonus_time;

    public Slider slider;

    void Awake()
    {
        slider.maxValue = default_time;
        current_time = default_time;
        if (!created)
        { 
                created = true;
                Debug.Log("Awake: " + this.gameObject);
         }
    }

    
    void Update()
    {
        if (islevelon)
        {

            current_time -= Time.deltaTime;
            slider.value = current_time;
            
            if (current_time < 0)
            {
                islevelon = false;
                this.gameObject.transform.parent.FindChild("Game Over").gameObject.SetActive(true);
            }

        }

    }
}