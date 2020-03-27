using UnityEngine;
using System.Collections;

public class TriggerColliderStart2 : MonoBehaviour
{
    //public GameObject objToDestroy;
    //public GameObject objToDestroy2;

    //public GameObject effect;
    public GameObject Spawnobject;
    //public float Time;
    public float time;

    // Use this for initialization

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "flashlight")
           
        Spawnobject.SetActive(true);

    }
}
