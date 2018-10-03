using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TileColor : MonoBehaviour {
    public bool was_clicked;

    SpriteRenderer renderer;
    public Sprite baldosa;

    public bool is_dual = false;
    public int contador_auxiliar;


    public bool isPath, trigger, hasCoin;
    public int x, y = 0;
    public List<int> tileX = new List<int>();
    public List<int> tileY = new List<int>();

    public int numeroT;
    public GameObject generator, tileparticle;


    // Use this for initialization
    void Start ()
    {
        was_clicked = false;
        contador_auxiliar = 2;
        renderer = GetComponent<SpriteRenderer>();
        tileX.Clear(); tileY.Clear();
        generator = GameObject.Find("PathGenerator");
        SetRandomColor();
	}
	
	// Update is called once per frame
	void Update () {
        numeroT = generator.GetComponent<GeneratePath>().numeroTile;

        if (isPath && trigger == false)
        {
            //StartCoroutine(showPath());
            trigger = true;
        }
    }

    IEnumerator showPath()
    {

        SetBlue();
        yield return new WaitForSeconds(1f);
        SetGrety();

    }
    /*
    private void OnMouseDown()
    {
        if (isPath)
        {
            if (generator.GetComponent<GeneratePath>().posX[numeroT] == x && generator.GetComponent<GeneratePath>().posY[numeroT] == y)
            {
                if (is_dual)
                {

                    contador_auxiliar--;
                    Debug.Log("hola pasé por acá");
                    //Debug.Log("El contador es "+contador_auxiliar);
                    if (contador_auxiliar <1)
                    {
                        renderer.sprite = baldosa;
                        generator.GetComponent<GeneratePath>().numeroTile++;
                    }
                }
                else
                {
                    //SetGreen();
                    renderer.sprite = baldosa;
                    generator.GetComponent<GeneratePath>().numeroTile++;
                    //Instantiate(tileparticle, transform.position, Quaternion.identity);
                }
            }
            else
            {
                IncorrectTile();
            }
           
        }
        else
        {
            IncorrectTile();
        }
    }

    */
  
    void OnMouseEnter()
    {
        if (GameObject.Find("PathGenerator").GetComponent<GeneratePath>().itcan)
        {

       
        if (!was_clicked)
        {
            was_clicked = true;

            Debug.Log("hola");
            if (isPath)
            {
               


            if (generator.GetComponent<GeneratePath>().posX[numeroT] == x && generator.GetComponent<GeneratePath>().posY[numeroT] == y)
                {

                    //SetGreen();
                    renderer.sprite = baldosa;
                    generator.GetComponent<GeneratePath>().numeroTile++;
                    GameObject.Find("Puntos").GetComponent<Multiplier>().AgregarPuntos();

                    //Instantiate(tileparticle, transform.position, Quaternion.identity);

                    /*
              GameObject.Find("Puntos").GetComponent<Multiplier>().AgregarPuntos();
                    renderer.sprite = baldosa;
                    generator.GetComponent<GeneratePath>().numeroTile++;
                    */

                }
                else
                {
                    IncorrectTile();
                }

            }
            else
            {
                IncorrectTile();
            }
        }
        }
    }
    
    public void SetGreen()
    {
        renderer.color = new Color(0f, 220f, 0f, 1f); //VERDE
    }
    public void IncorrectTile()
    {
        GameObject.Find("Puntos").GetComponent<Multiplier>().recent_mistake = true;
        was_clicked = false;
        //renderer.color = new Color(255f, 0f, 0f, 1f); //ROJO
        if (isPath)
        {

            var animator = gameObject.GetComponent<Animator>();
            animator.Play("IncorrectTile");
            
            // D 4 N 1 L 0 5/9/18
            GameObject.Find("Time_Slider").GetComponent<TimeCS>().current_time -= GameObject.Find("Time_Slider").GetComponent<TimeCS>().fault_time;
            //
        }

        if (!isPath && hasCoin) //TILE CON MONEDA
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
            hasCoin = false;
        }
        else if(!isPath && !hasCoin)
        {
            
            var animator = gameObject.GetComponent<Animator>();
            animator.Play("Destroytile");

            Destroy(gameObject, 1f);
            
            // D 4 N 1 L 0 5/9/18
            GameObject.Find("Time_Slider").GetComponent<TimeCS>().current_time -= GameObject.Find("Time_Slider").GetComponent<TimeCS>().penalty_time;
            //
        }
        
    }
    public void SetBlue()
    {
        renderer.material.color = new Color(Random.Range(100f, 200f), 100f, 255f, 1f); //AZUL
    }
    public void SetRandomColor()
    {
        
      //  renderer.GetComponent<SpriteRenderer>().color = new Color(0f, 100f, 150f, 1f); //AZUL
        
        
    }
    public void SetGrety()
    {
        renderer.material.color = Color.white; //GRIS

    }

   
}
