using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tablica : MonoBehaviour
{

    public List<Cukierek> cukierki = new List<Cukierek>();
    public int wysokoscSiatki;
    public int szerokoscSiatki;
    //dzieki temu mozemy ustawic w unity jaki typ obiektu moze nam stworzyc tablice (w tym wypadku blok o nazwie cukierek)
    public GameObject obiekt;


    // Use this for initialization

    //tworzenie tablicy dwuwymiarowej
    void Start ()
    {
	    for(int y=0; y<wysokoscSiatki; y++)
        {
            for(int x=0; x<szerokoscSiatki; x++)
            {
                //nowy game object (obiekt = cukierek) z nowym wektorem i obrotem domyslnym(quaternion)
                GameObject c = Instantiate(obiekt, new Vector3(x,y,0), Quaternion.identity) as GameObject;
                //Mozna do obiektu c przypisać obiekt typu gameObject, operując komponentem transform // Dodaje rodzica ktory kieruje wszystkim 
                //przykleja cukierki do jednego glownego dzieki temu mozna ustawic pozycje calej tablicy
                c.transform.parent = gameObject.transform;
                //dodaje do listy cukierek, c pobiera komponenty ze skrytpu Cukierek
                cukierki.Add(c.GetComponent<Cukierek>());
            }
        }
        //ustawienie tablicy dla kamery
        gameObject.transform.position = new Vector3(-2.5f, -1.5f, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
