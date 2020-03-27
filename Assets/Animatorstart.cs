using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatorstart : MonoBehaviour
{
    private Animator animator;
   private bool shooting = false;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !shooting)
        {
            animator.SetBool("shooting", true);
            shooting = true;
            effect.SetActive(true);
        }
    }
}
