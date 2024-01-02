using UnityEngine;
using System.Collections;

public class npcHumanoid : MonoBehaviour
{
    public float sightRange;
    public float attackRange;
    public float npcSpeed;
    GameObject player;
    public LayerMask playerLayer;
    bool attackState;
    bool followState;
    bool patrolState=true;
    Animator animator;

    Vector3 targetPosition;
    Vector3 currentPosition;
    Vector3 moveDirection;

    public GameObject bullet;
    public float fireTime;
    public Transform firePoint;
    public Transform fireTurn;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("player");
    }

    private void Update()
    {
        if (player.GetComponent<charInfo>().playerDeath == 1)
        {
            player.GetComponent<charInfo>().playerDeath++;
            //animator.SetBool("follow", false);
            //GetComponent<npcHumanoid>().enabled = false;
        }

        attackState =Physics2D.OverlapCircle(transform.position, attackRange,playerLayer);
        followState= Physics2D.OverlapCircle(transform.position, sightRange,playerLayer);

        positionArrangement();
        Flipping();

        if (attackState && player.GetComponent<charInfo>().playerDeath != 2) Attacking();
        else if (followState || !patrolState) Following();
    }

    private void positionArrangement()
    {
        targetPosition = player.transform.position;
        currentPosition = transform.position;
        moveDirection = (targetPosition - currentPosition).normalized;
    }

    private void Flipping()
    {
        if (moveDirection.x > 0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            fireTurn.eulerAngles = new Vector2(fireTurn.rotation.x, 180);
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            fireTurn.eulerAngles = new Vector2(fireTurn.rotation.x, 0);
        }
    }

    public void Attacking()
    {
        animator.SetBool("attack", true);
        animator.SetBool("follow", false);

        if (!IsInvoking("Fire") && player.GetComponent<charInfo>().health > 0)
        {
            InvokeRepeating("Fire", 0f, fireTime);
        }
    }

    void Fire()
    {
        //float spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        //Vector3 characterCenter = new Vector3(transform.position.x, transform.position.y + spriteHeight / 2);
        Instantiate(bullet, firePoint.position, transform.rotation);
    }

    public void Following()
    {
        patrolState = false;
        animator.SetBool("attack", false);
        animator.SetBool("follow",true);

        transform.position += moveDirection * npcSpeed * Time.deltaTime;
    }

}