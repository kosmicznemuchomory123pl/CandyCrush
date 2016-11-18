using UnityEngine;
using System.Collections;

public class Czujka : MonoBehaviour
{

    public Cukierek wlasciciel;


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cukierek")
        {
            wlasciciel.DodanieSasiedztwa(other.GetComponent<Cukierek>());
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cukierek")
        {
            wlasciciel.UsuniecieSasiedztwa(other.GetComponent<Cukierek>());
        }
    }

}
