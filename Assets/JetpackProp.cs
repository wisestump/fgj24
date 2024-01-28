using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackProp : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Fire"))
            animator.Play("Fire");
    }
}