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
    public GameObject player;

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
        if (HasLOS)
        {
            agent.SetDestination(player.transform.position);
            

            if (Vector3.Distance(transform.position, player.transform.position) < 2.5)
            {
                //could be an attack
                animator.SetInteger("Animation", (int)CryptoState.IDLE);
                transform.LookAt(transform.position - player.transform.forward);
            }
            else
            {
                animator.SetInteger("AnimState", (int)CryptoState.RUN);
            }
        }
        else
        {
            animator.SetInteger("AnimState", (int)CryptoState.IDLE);
        }
        

               
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HasLOS = true;
            player = other.transform.gameObject;
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
