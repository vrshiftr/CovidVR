using UnityEngine;
using System.Collections;

public class TriggerColliderStart1 : MonoBehaviour
{
    //public GameObject objToDestroy;
    //public GameObject objToDestroy2;

    //public GameObject effect;
    public GameObject Spawnobject;
    //public float Time;
 

    // Use this for initialization

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
           
        Spawnobject.SetActive(true);

    }
}
