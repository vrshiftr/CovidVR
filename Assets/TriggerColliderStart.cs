using UnityEngine;
using System.Collections;

public class TriggerColliderStart : MonoBehaviour
{
    public GameObject objToDestroy;
    //public GameObject objToDestroy2;

    public GameObject effect;
    public GameObject Spawnobject;
    public GameObject Spawnobject1;
    public GameObject Spawnobject2;

    public float Time;
 

    // Use this for initialization

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
            Instantiate(effect, objToDestroy.transform.position, objToDestroy.transform.rotation);
        Destroy(objToDestroy, 0.1f);
        //objToDestroy2.SetActive(false);
        Spawnobject.SetActive(true);
        Spawnobject1.SetActive(false);
        Spawnobject2.SetActive(true);

    }
}
