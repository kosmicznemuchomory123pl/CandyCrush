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
    public Cukierek ostatniCukierek;
    //cukierek 1 start/koniec
    public Vector3 c1s, c1k, c2s, c2k;
    public bool zamiana = false;
    public Cukierek cuks1, cuks2;
    //public float czasStartu;
    //Do zmiany nazwa
    //public float SwapRate=2;
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
        gameObject.transform.position = new Vector3(-2.5f, 0f, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (zamiana)
        {
            RuchCuksa(cuks1, c1k, c1s);
            OdwrotnyRuchCuksa(cuks2, c2k, c2s);
            if (Vector3.Distance(cuks1.transform.position, c1k)<.1f|| Vector3.Distance(cuks2.transform.position, c2k) < .1f)
            {
                cuks1.transform.position = c1k;
                cuks2.transform.position = c2k;
                zamiana = false;
                WlacznikFizyki(false);
            }
        }
	}
    public void RuchCuksa(Cukierek aktualnyDoZmiany, Vector3 doPoz, Vector3 zPoz)
    {
        //szybkosc zamiany klockow
        aktualnyDoZmiany.transform.position = Vector3.Slerp(zPoz, doPoz, 1);
        //aktualnyDoZmiany.transform.position += srodek;
    }
    public void OdwrotnyRuchCuksa(Cukierek aktualnyDoZmiany, Vector3 doPoz, Vector3 zPoz)
    {
        //szybkosc zamiany klockow
        aktualnyDoZmiany.transform.position = Vector3.Slerp(zPoz, doPoz, 1);
        //aktualnyDoZmiany.transform.position += srodek;
    }
    public void WlacznikFizyki(bool isOn)
    {
        for(int i = 0; i<cukierki.Count; i++)
        {
            cukierki[i].GetComponent<Rigidbody>().isKinematic = isOn;

        }
    }

    public void ZamianaCuksow(Cukierek aktualnyCuks)
    {
        if (ostatniCukierek == null)
        {
            ostatniCukierek = aktualnyCuks;
        }
        else if (ostatniCukierek == aktualnyCuks)
        {
            ostatniCukierek = null;
        }
        else
        {
            if (ostatniCukierek.JestWSasiedztwie(aktualnyCuks))
            {
                c1s = ostatniCukierek.transform.position;
                c1k = aktualnyCuks.transform.position;

                c2s = aktualnyCuks.transform.position;
                c2k = ostatniCukierek.transform.position;

                //czasStartu = Time.time;
                WlacznikFizyki(true);
                cuks1 = ostatniCukierek;
                cuks2 = aktualnyCuks;
                zamiana = true;
                
            }
            else
            {
                ostatniCukierek = aktualnyCuks;
            }
            //to opcjonalnie
            aktualnyCuks = null;
            ostatniCukierek = null;
        }
    }
    public void rekurencja(Vector3 wektor3,Cukierek tenCuks, Cukierek wybrany)
    {



        
        tenCuks.transform.position = wektor3;
        if (tenCuks.cube != wybrany.cube )
        {
            return;
        }
        tenCuks.cube.tag = "zniszcz";

        
        
        wektor3.x = +1;
        rekurencja(wektor3, tenCuks, wybrany);
        wektor3.x = -1;
        rekurencja(wektor3, tenCuks, wybrany);
        wektor3.y = +1;
        rekurencja(wektor3, tenCuks, wybrany);
        wektor3.y = -1;
        rekurencja(wektor3, tenCuks, wybrany);
        return;

        
    }
}
