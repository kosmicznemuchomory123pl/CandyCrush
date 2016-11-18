using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tablica : MonoBehaviour
{

    public List<Cukierek> cukierki = new List<Cukierek>();
    public int wysokoscSiatki;
    public int szerokoscSiatki;
    public GameObject obiekt;


    // Use this for initialization
    void Start ()
    {
	    for(int y=0; y<wysokoscSiatki; y++)
        {
            for(int x=0; x<szerokoscSiatki; x++)
            {
                GameObject c = Instantiate(obiekt, new Vector3(x,y,0), Quaternion.identity) as GameObject;
                c.transform.parent = gameObject.transform;
                cukierki.Add(c.GetComponent<Cukierek>());
            }
        }
        gameObject.transform.position = new Vector3(-2.5f, -1.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
