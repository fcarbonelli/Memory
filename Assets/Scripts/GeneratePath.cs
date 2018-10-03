using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GeneratePath : MonoBehaviour {
    public List<int> posX = new List<int>();
    public List<int> posY = new List<int>();
    public bool itcan;
    public List<Vector3> pathFollower = new List<Vector3>();

    [System.Serializable]
    public class Path
    {
        public int[] pathHorizontal;
    }
    public Path[] pathVertical;

    int medida;
    public GameObject tile, follower, coin;
    float posFollower;
    public int numeroTile = 0;

    public Text contador_auxiliar;

    // Use this for initialization
    void Start()
    {
        itcan = false;
        // D 4 N 1 L 0 3/9/18
        GameObject.Find("Time_Slider").GetComponent<TimeCS>().islevelon = true;
        //
        posX.Clear(); posY.Clear();

        GenerarPath();
        medida = pathVertical.Length;
        StartCoroutine(SpawnTiles());

        Instantiate(follower, new Vector3(posFollower, -3.5f, 180f), Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("random");
    }
    void Awake()
    {
        // D 4 N 1 L 0 5/9/18
        //  DontDestroyOnLoad(GameObject.Find("Time_Slider"));
        // 
    }
    // Update is called once per frame
    void Update()
    {
        // D 4 N 1 L 0 5/9/18
        if (GameObject.Find("Time_Slider").GetComponent<TimeCS>().islevelon)
            //

            if (numeroTile == posX.Count)
            {
                // D 4 N 1 L 0 5/9/18
                // Application.Load(Application.loadedLevel);
                // 

                // D 4 N 1 L 0 5/9/18
                // Esta linea determina la cantidad de tiempo que se tardó en el nivel.
                //GameObject.Find("Time_Slider").GetComponent<TimeCS>().slider.maxValue - GameObject.Find("Time_Slider").GetComponent<TimeCS>().current_time = tiempototalenelnivel

                if (GameObject.Find("Time_Slider").GetComponent<TimeCS>().created)
                {
                    if (GameObject.Find("Time_Slider").GetComponent<TimeCS>().slider.maxValue - GameObject.Find("Time_Slider").GetComponent<TimeCS>().current_time > 2f)
                    {
                        GameObject.Find("Time_Slider").GetComponent<TimeCS>().current_time += GameObject.Find("Time_Slider").GetComponent<TimeCS>().bonus_time;
                    }

                }


                SaveManager.Instance.AumentarSpeed();

                //NEXT LEVEL
                GameObject.Find("Canvas").GetComponent<Level>().nivel += 1;

                SceneManager.LoadScene("Main", LoadSceneMode.Single);
                GameObject.Find("Canvas").gameObject.GetComponent<ParticleSystem_CameraLocator>().RestartCanvasRenderCamera();
            }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SaveManager.Instance.Reset();
        }
    }

    public void GetFollowerPos(int tipo)
    {
        switch (tipo)
        {
            case 0: posFollower = -1.5f; break;
            case 1: posFollower = -0.5f; break;
            case 2: posFollower = 0.5f; break;
            case 3: posFollower = 1.5f; break;
            case 4: posFollower = 1.5f; break;
        }
    }

    public void GenerarPath()
    {
        
        //POSICION RANDOM DE LA PRIMERA FILA DE ARRIBA
        int posRandom = Random.Range(0,pathVertical[0].pathHorizontal.Length);
        pathVertical[0].pathHorizontal[posRandom] = 1;
        SetList(0, posRandom); GetFollowerPos(posRandom);
        
        for (int i = 0; i < pathVertical.Length; i++)
        {
            if (i >2 )
            {

            }
            else
            {
           
        int instruccion;
           if (GameObject.Find("Canvas").GetComponent<Level>().nivel < 7)
             {
                instruccion = Random.Range(0, 4); // 0=izquierda 1=derecha 2,3=arriba
             }
                else
                {
                     instruccion = Random.Range(0, 2); // 0=izquierda 1=derecha 2,3=arriba
                }
           
            switch (instruccion)
            {
                //IZQUIERDA
                case 0:
                    if ((posRandom - 1) > -1)
                    {
                        if (pathVertical[i].pathHorizontal[posRandom - 1] >= 0)
                        {
                            posRandom--;
                            pathVertical[i].pathHorizontal[posRandom] = 1;
                            SetList(i, posRandom);

                            if ((i + 1) < pathVertical.Length)
                            {
                                pathVertical[i + 1].pathHorizontal[posRandom] = 1;
                                SetList(i + 1, posRandom);
                            }
                        }
                        else
                        {
                            if ((i + 1) < pathVertical.Length)
                            {
                                pathVertical[i + 1].pathHorizontal[posRandom] = 1;
                                SetList(i + 1, posRandom);
                            }
                        }
                    }
                    else if((i + 1) < pathVertical.Length)
                    {
                        pathVertical[i + 1].pathHorizontal[posRandom] = 1;
                        SetList(i + 1, posRandom);
                    }


                    break;

                //DERECHA
                case 1:
                    if(posRandom +1 < pathVertical[i].pathHorizontal.Length)
                    {
                       if (pathVertical[i].pathHorizontal[posRandom + 1] < pathVertical[i].pathHorizontal.Length)
                        {
                            posRandom++;
                            pathVertical[i].pathHorizontal[posRandom] = 1;
                            SetList(i, posRandom);

                            if ((i + 1) < pathVertical.Length)
                            {
                                pathVertical[i + 1].pathHorizontal[posRandom] = 1;
                                SetList(i + 1, posRandom);
                            }
                        }
                        else
                        {
                            if ((i + 1) < pathVertical.Length)
                            {
                                pathVertical[i + 1].pathHorizontal[posRandom] = 1;
                                SetList(i + 1, posRandom);
                            }
                        } 
                    }
                    else if ((i + 1) < pathVertical.Length)
                    {
                        pathVertical[i + 1].pathHorizontal[posRandom] = 1;
                        SetList(i + 1, posRandom);                        
                    }

                    break;

                case 2:
                    if ((i + 1) < pathVertical.Length)
                    {
                        pathVertical[i + 1].pathHorizontal[posRandom] = 1;
                        SetList(i + 1, posRandom);
                    }
                    break;

                case 3:
                    if ((i + 1) < pathVertical.Length)
                    {
                        pathVertical[i + 1].pathHorizontal[posRandom] = 1;
                        SetList(i + 1, posRandom);
                    }
                    break;
            }
            }
        }

    }

    public void SetList(int x, int y)
    {
        posX.Add(x); posY.Add(y);

        //Debug.Log(x + "" + y);
    }

    public void SetCorrectPath()
    {
        itcan = true;
        tile.GetComponent<TileColor>().tileX.Clear();
        tile.GetComponent<TileColor>().tileY.Clear();

        for (int i = 0; i < posX.Count; i++)
        {
            tile.GetComponent<TileColor>().tileX.Add(posX[i]); 
        }
        for (int i = 0; i < posY.Count; i++)
        {
            tile.GetComponent<TileColor>().tileY.Add(posY[i]);
        }

    }

    IEnumerator SpawnTiles()
    {
        
        for (int i = 0; i < medida; i++)
        {
            for (int j = 0; j < medida; j++)
            {
                yield return new WaitForSeconds(0.02f);
                Instantiate(tile, new Vector3(j - 1.5f, i - 1.5f, 180f), transform.rotation);

            }
        }

        SetCorrectPath();

        int ax = 0; int ay = 0; //int contador = 0;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("TileCamino"))
        {
            go.GetComponent<TileColor>().x = ax;
            go.GetComponent<TileColor>().y = ay;

            if (pathVertical[ax].pathHorizontal[ay] == 1)
            {

                go.GetComponent<TileColor>().isPath = true;
               
                //acá puedo agregar un tag

                /*
                if (GameObject.Find("Canvas").GetComponent<Level>().nivel > 0 && GameObject.Find("Canvas").GetComponent<Level>().nivel < 12)
                {
                    int random = Random.Range(0, 4);
                    if (random > 2)
                    {
                         
                        // Text tempTextBox = Instantiate(contador_auxiliar, new Vector3(go.transform.position.x, go.transform.position.y, 180f),new Quaternion())  as Text;
                        // tempTextBox.transform.SetParent(Canvas.transform, false);

                        go.GetComponent<TileColor>().is_dual= true;
                        go.GetComponent<TileColor>().SetGreen();
                    }
                       }

                if (GameObject.Find("Canvas").GetComponent<Level>().nivel > 12)
                {
                    int random = Random.Range(0, 4);
                    if (random > 1)
                    {
                        go.GetComponent<TileColor>().is_dual = true;
                        go.GetComponent<TileColor>().SetGreen();
                    }


                }
                */

            }
            else if (pathVertical[ax].pathHorizontal[ay] == 0)
            {
                int ranCoin = Random.Range(0,30);
                if (ranCoin == 0)
                {
                    go.GetComponent<TileColor>().hasCoin = true;
                    Instantiate(coin ,go.transform);
                }
                
            }

            ay++;
            if (ay == medida)
            {
                ay = 0;
                ax++;
            }
        }

        CheckCoords();



    }

    public void CheckCoords()
    {
        int contador = 0;
        while (contador <= posX.Count)
        {
            int ax = 0; int ay = 0;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("TileCamino"))
            {            
                if (pathVertical[ax].pathHorizontal[ay] == 1)
                {
                    if (posX[contador] == ax && posY[contador] == ay)
                    {
                         pathFollower.Add(go.transform.position);
                         contador++;
                    }
                }

                ay++;
                if (ay == medida)
                {
                    ay = 0;
                    ax++;
                }

            }
        }
        
    }



}
