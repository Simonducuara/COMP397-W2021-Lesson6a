using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum CryptoState
{
    IDLE,
    RUN,
    JUMP
}

public class CryptoBehaviour : MonoBehaviour
{
    [Header("Line of Sight")]    
    public bool HasLOS;

    private NavMeshAgent agent;    
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetInteger("AnimState", (int)CryptoState.IDLE);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.SetInteger("AnimState", (int)CryptoState.RUN);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetInteger("AnimState", (int)CryptoState.JUMP);
        }
               
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HasLOS = true;
        }                
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HasLOS = false;
        }
    }

}
