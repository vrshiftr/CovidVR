using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;
    public AudioSource dead;
    // Start is called before the first frame update
     void Start()
    {
        dead = GetComponent<AudioSource>();    
    }
    public void Destroy()

    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        dead.Play();
        Destroy(gameObject,0.5f);
    }
}