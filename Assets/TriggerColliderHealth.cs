using UnityEngine;
using System.Collections;

public class TriggerColliderHealth : MonoBehaviour
{

  
    //public GameObject Spawnobject;
    public float Time;
    public AudioSource dead1;
    void Start()
    {
        dead1 = GetComponent<AudioSource>();   
    }

    public void SubtractPoints(int points)
    {


    }

    // Use this for initialization

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")

            dead1.Play();
        //objToDestroy2.SetActive(false);
        // Spawnobject.SetActive(true);

    }
}
