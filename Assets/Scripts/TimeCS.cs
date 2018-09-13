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
<<<<<<< HEAD
        { 
                created = true;
                //Debug.Log("Awake: " + this.gameObject);
         }
=======
        {
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
>>>>>>> parent of 9a1d6ad... Timer 2
    }

    
    void Update()
    {
        if (islevelon)
        {

            current_time -= Time.deltaTime;
            slider.value = current_time;
            
            if (current_time < 0)
            {
<<<<<<< HEAD
                islevelon = false;
                this.gameObject.transform.parent.Find("Game Over").gameObject.SetActive(true);
=======
                aux_cant = false;
                aux_time1 = 0.25f;
                penalty = false;
                slider.image.color = Color.Lerp(Color.yellow, Color.green, Time.deltaTime);
>>>>>>> parent of 9a1d6ad... Timer 2
            }

        }

    }
}