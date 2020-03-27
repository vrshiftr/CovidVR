using UnityEngine;
using System.Collections;

public class TriggerColliderShootable : MonoBehaviour
{
    public GameObject objToDestroy;
    public GameObject effect;
    public float Time;
  


     void Start()
    {
   
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
            SumScore.Add(1);
        Instantiate(effect, objToDestroy.transform.position, objToDestroy.transform.rotation);

    
        Destroy(objToDestroy);
        
      
    }

}



