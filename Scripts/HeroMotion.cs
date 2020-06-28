using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroMotion : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
   //private Touch touch;
    private float speedModifier;

    [SerializeField]
    float moveSpeed = 5f;

    Rigidbody2D rb;

    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
       anim.SetInteger("Moving", 0);
        speedModifier = 0.01f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.touchCount >0 )
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z + touch.deltaPosition.y * speedModifier);
            }


        }

        /*if (isMoving)
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.y = 0;
                whereToMove = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector3(whereToMove.x * moveSpeed, whereToMove.z * moveSpeed);
            }
        }

        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            rb.velocity = Vector3.zero;
        }

        if (isMoving)
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;*/

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.SetDestination(hit.point);
                anim.SetInteger("Moving", 1);
                SoundManager.PlaySound("walk");

                if (agent.stoppingDistance < agent.remainingDistance)
                {
                    anim.SetInteger("Moving", 0);
                }
            }
        }
    }
}
