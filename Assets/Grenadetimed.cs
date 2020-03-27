using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class Grenadetimed : MonoBehaviour
{
    public float delay = 3f;
    float countdown;
    bool hasExploded = false;
    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;
  
   

    public void Start()
    {
        countdown = delay;
        
    }
    public void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }
    void Explode()
    {
       
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[]colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
              
            }
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if (dest != null)
            {
                dest.Destroy();
                SumScore.Add(1);
            }


            Destroy(gameObject,0.5f);
    }
}
}

