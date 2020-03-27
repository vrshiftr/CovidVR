using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public float delay = 3f;
    float countdown;
    public GameObject explosionEffect;
    public GameObject logo;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            Explode();
          
        }
    }
    void Explode()
    {

        explosionEffect.SetActive(true);


            Destroy(gameObject, 1f);
        logo.SetActive(true);
        }
}
