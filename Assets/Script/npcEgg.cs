using UnityEngine;
using System.Collections;

public class npcEgg : MonoBehaviour
{
    public float attackRange;
    public float npcSpeed;
    public GameObject player;
    GameObject egg;
    public LayerMask playerLayer;
    Animator animator;

    public GameObject bullet;
    public float fireTime = 5f;
    public Transform firePoint;

    private void Start()
    {
        egg = gameObject.transform.parent.gameObject;
        animator = egg.GetComponent<Animator>();
    }


    public void Attacking()
    {
        animator.SetBool("attack", true);

        if (!IsInvoking("Fire") && player.GetComponent<charInfo>().health > 0)
        {
            InvokeRepeating("Fire", 0.5f, fireTime);
        }
    }

    void Fire()
    {
        Instantiate(bullet, firePoint.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.CompareTag("Player"))
            Attacking();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CancelInvoke("Fire");
            animator.SetBool("attack", false);
        }
    }
}