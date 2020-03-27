using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform bulletSpawn;
    public GameObject bullet;
    public float bulletSpeed;
    public AudioSource source;
    public AudioClip bulletSound;
    public float fireRate = 5f;
    public float nextFire = 0.0f;
    public float shootPower;
    //private bool triggerDown;
 
    // Update is called once per frame
    void Start()
    {
        if (bulletSpawn == null)
            bulletSpawn = transform;
    }
    void Update()
    
        {
        //CheckTrigger();
        //   Shoot();
        {

            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation * Quaternion.Euler(90f, 0f, 0f)).GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * shootPower);
            source.PlayOneShot(bulletSound);
        }
    }
}
    //private void CheckTrigger()

    //{
      // if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
      //  {
      //      triggerDown = true;
     //   }
         //   if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
         //   {
               // triggerDown = false;
         //   }
   // }
    //private void Shoot()
  
       // { if (triggerDown && Time.time > nextFire)
     //   {

          //  nextFire = Time.time + fireRate;
           // Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation * Quaternion.Euler(0f,0f,0f)).GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * shootPower);
           // source.PlayOneShot(bulletSound);
       // }
  //  }
//}


