using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effect;
    public GameObject objToDestroy;
    public AudioSource hit;
  
    // Use this for initialization
 

    public float Time;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 3);
        hit = GetComponent<AudioSource>();
        
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
    
            Instantiate(effect, objToDestroy.transform.position, objToDestroy.transform.rotation);
            hit.Play();
            Destroy(objToDestroy,3f);

    }
}

}
