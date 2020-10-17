using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator = null;
    private UnityEngine.AI.NavMeshAgent agent;
    private RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButton( 0 ) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            if( Physics.Raycast( ray, out hit, 1000 ) )
            {
                this.agent.SetDestination( hit.point );
                this.animator.SetFloat( "Speed", 1 );
            }
        }
        if( Vector3.Distance( hit.point, transform.position ) < 1.0f )
        {
            this.animator.SetFloat( "Speed", 0 );
        }
    }
}
