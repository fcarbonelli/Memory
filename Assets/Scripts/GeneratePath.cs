using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePath : MonoBehaviour {

    public List<int> posX = new List<int>();
    public List<int> posY = new List<int>();

    [System.Serializable]
    public class Path
    {
        public int[] pathHorizontal;
    }
    public Path[] pathVertical;

    int medida;
    public GameObject tile;
    public int numeroTile = 0;

    // Use this for initialization
    void Start ()
    {
        posX.Clear(); posY.Clear();

        GenerarPath();
        medida = pathVertical.Length;
        StartCoroutine(SpawnTiles());
        //MostrarCaminoAzul(); 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (numeroTile == posX.Count)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}

    public void GenerarPath()
    {
        //POSICION RANDOM DE LA PRIMERA FILA DE ARRIBA
        int posRandom = Random.Range(0,pathVertical[0].pathHorizontal.Length);
        pathVertical[0].pathHorizontal[posRandom] = 1;
        SetList(0, posRandom);

        for (int i = 0; i < pathVertical.Length; i++)
        {
            int instruccion = Random.Range(0,4); // 0=izquierda 1=derecha 2,3=arriba
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

    public void SetList(int x, int y)
    {
        posX.Add(x); posY.Add(y);

        Debug.Log(x + "" + y);
    }

    public void SetCorrectPath()
    {
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
                Instantiate(tile, new Vector3(j - 1.5f, i - 1.5f, 0), transform.rotation);

            }
        }

        SetCorrectPath();

        int ax = 0; int ay = 0;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("TileCamino"))
        {
            go.GetComponent<TileColor>().x = ax;
            go.GetComponent<TileColor>().y = ay;

            if (pathVertical[ax].pathHorizontal[ay] == 1)
            {
                go.GetComponent<TileColor>().isPath = true;
                //go.GetComponent<TileColor>().SetBlue();
                //StartCoroutine(MostrarCaminoAzul(go));
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
