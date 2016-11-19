using UnityEngine;
using System.Collections;

//Czujka jako typ kolizji ktora bedzie sprawdzac sasiednie cukierki
public class Czujka : MonoBehaviour
{

    public Cukierek wlasciciel;

    //Trigger to typ kolizji
    public void OnTriggerEnter(Collider other)
    {
        // Tutaj kod wykonywany po wejściu w obszar
        if (other.tag == "Cukierek")
        {
            wlasciciel.DodanieSasiedztwa(other.GetComponent<Cukierek>());
        }

    }
    public void OnTriggerExit(Collider other)
    {
        // Tutaj kod wykonywany w momencie opuszczania obszaru
        if (other.tag == "Cukierek")
        {
            wlasciciel.UsuniecieSasiedztwa(other.GetComponent<Cukierek>());
        }
    }

}
