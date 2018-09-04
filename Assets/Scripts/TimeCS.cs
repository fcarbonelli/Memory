using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class TimeCS : MonoBehaviour
{
    public bool islevelon;
    public float current_time = 0f;
    public float default_time = 0f;

    public Slider slider;

    
void start()
    {
       // slider = gameObject.GetComponent<Slider>();
    }

    // Invoked when the value of the slider changes.

    // Update is called once per frame
    void Update()
    {
        if (islevelon)
        {

            default_time -= Time.deltaTime;
            slider.value = default_time;
            Debug.Log(slider.value);
            if (current_time < 0)
            {
                islevelon = false;
            }

        }
    }
}