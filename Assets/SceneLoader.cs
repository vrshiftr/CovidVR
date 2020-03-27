using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public string loadLevel;
   private void OnTriggerEnter(Collider other)
      
    {
        if (other.tag == "Player")
            SceneManager.LoadScene(loadLevel);
    }
}
