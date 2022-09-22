using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePath : MonoBehaviour
{
    public GameObject go;
    public GameObject wall;

    public List<GameObject> gos;
    public int max;

    public int x;
    public int z;
    public int t;
    private void Start()
    {
        gos.Add(Instantiate(go, Vector3.zero, Quaternion.Euler(90, 0, 0)));



        for (int i = 0; i < max; i++)
        {
            x = Random.Range(-1, 2);
            z = Random.Range(-1, 2);
            t = Random.Range(0, 5);

            for (int q = 0; q < t; q++)
            {
                if (x > z)
                {
                    for (int k = 0; k < t; k++)
                    {
                        gos.Add(Instantiate(go, new Vector3((int)(gos[gos.Count - 1].gameObject.transform.position.x) + 1, 0,
                    (int)(gos[gos.Count - 1].gameObject.transform.position.z)), Quaternion.Euler(90, 0, 0)));

                        z = Random.Range(-1, 2);
                        t = Random.Range(0, 3);
                        for (int e = 0; e < t; e++)
                        {
                            if (z > 0)
                            {
                                gos.Add(Instantiate(go, new Vector3((int)(gos[gos.Count - 1].gameObject.transform.position.x), 0,
                            (int)(gos[gos.Count - 1].gameObject.transform.position.z) + 1), Quaternion.Euler(90, 0, 0)));
                            }
                            else if (z == 0)
                            {
                                continue;
                            }
                            else
                            {
                                gos.Add(Instantiate(go, new Vector3((int)(gos[gos.Count - 1].gameObject.transform.position.x), 0,
                            (int)(gos[gos.Count - 1].gameObject.transform.position.z) - 1), Quaternion.Euler(90, 0, 0)));
                            }
                        }

                    }


                }
                else if (z > x)
                {
                    for (int k = 0; k < t; k++)
                    {
                        gos.Add(Instantiate(go, new Vector3((int)(gos[gos.Count - 1].gameObject.transform.position.x), 0,
                   (int)(gos[gos.Count - 1].gameObject.transform.position.z) + 1), Quaternion.Euler(90, 0, 0)));

                        x = Random.Range(-1, 2);
                        t = Random.Range(0, 3);
                        for (int e = 0; e < t; e++)
                        {
                            if (x > 0)
                            {
                                gos.Add(Instantiate(go, new Vector3((int)(gos[gos.Count - 1].gameObject.transform.position.x) + 1, 0,
                            (int)(gos[gos.Count - 1].gameObject.transform.position.z)), Quaternion.Euler(90, 0, 0)));
                            }
                            else if (x == 0)
                            {
                                continue;
                            }
                            else
                            {
                                gos.Add(Instantiate(go, new Vector3((int)(gos[gos.Count - 1].gameObject.transform.position.x) - 1, 0,
                             (int)(gos[gos.Count - 1].gameObject.transform.position.z)), Quaternion.Euler(90, 0, 0)));
                            }
                        }

                    }


                }
            }



            int flagx = 0;
            int flagy = 0;
            for (int o = 0; o < gos.Count; o++)
            {
                if (gos[o].transform.position.x > flagx)
                {
                    flagx = (int)gos[o].transform.position.x;
                }
            }
            for (int b = 0; b < gos.Count; b++)
            {
                if (gos[b].transform.position.y > flagx)
                {
                    flagy = (int)gos[b].transform.position.y;
                }
            }



            for (int u = 0; u < flagy; u++)
            {
                for (int n = 0; n < flagx; n++)
                {
                    Debug.Log("aa");
                    Instantiate(wall, new Vector3(u, 0, n), Quaternion.identity);
                }
            }
            //gos.Add(Instantiate(go, new Vector3((int)(gos[gos.Count - 1].gameObject.transform.position.x) + 1, 0,
            //  (int)(gos[gos.Count - 1].gameObject.transform.position.z) + 1), Quaternion.Euler(90, 0, 0)));
        }



    }



    private void check(GameObject go)
    {
        for (int i = 0; i < gos.Count; i++)
        {

        }
    }



}
