using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cukierek : MonoBehaviour
{

    string[] kolory = { "Czarny", "Czerwony", "Niebieski", "Zielony", "Zolty" };
    string kolor = "";
    public GameObject cube;
    public List<Cukierek> Sasiedztwo = new List<Cukierek>();

    



    // Use this for initialization
    void Start()
    {
        TworzenieCukierkow();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Losowanie roznych cukierkow
    public void TworzenieCukierkow()
    {
        kolor = kolory[Random.Range(0, kolory.Length)];
        //https://docs.unity3d.com/ScriptReference/Resources.Load.html //Laduje dane z folderu Materialy
        Material m = Resources.Load("Materialy/" + kolor) as Material;
        //Dodaje kolor (renderuje) do klocka(cube) z pobranego wyzej zrodla
        cube.GetComponent<Renderer>().material = m;

    }

    //Dodaje czujke do cukierka lub ja usuwa
    public void DodanieSasiedztwa(Cukierek c)
    {
        if (!Sasiedztwo.Contains(c))
        {
            Sasiedztwo.Add(c);
        }
    }
    public bool JestWSasiedztwie (Cukierek c)
    {
        if(Sasiedztwo.Contains(c))
        {
            return true;

        }
        return false;
    }
    public void UsuniecieSasiedztwa(Cukierek c)
    {
        Sasiedztwo.Remove(c);
    }
    //funkcja wywoływana gdy klikniemy na obiekt
    void OnMouseDown()
    {
        GameObject.Find("Tablica").GetComponent<Tablica>().rekurencja(this, this);
        
    }
}
