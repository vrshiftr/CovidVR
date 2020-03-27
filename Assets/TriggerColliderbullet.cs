using UnityEngine;
using System.Collections;

public class TriggerColliderbullet : MonoBehaviour
{
    public GameObject objToDestroy;
    public GameObject effect;
  


    void Start()
    {
      
    }
    // Use this for initialization

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kill")
            SumScore.Add(-1);
        Instantiate(effect, objToDestroy.transform.position, objToDestroy.transform.rotation);
      
        Destroy(objToDestroy,0.2f);
       
    }
}
