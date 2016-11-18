using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cukierek : MonoBehaviour
{


    public List<Cukierek> Sasiedztwo = new List<Cukierek>();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void DodanieSasiedztwa(Cukierek c)
    {
        Sasiedztwo.Add(c);
    }
    public void UsuniecieSasiedztwa(Cukierek c)
    {
        Sasiedztwo.Remove(c);
    }

    void OnMouseDown()
    {

    }
}
