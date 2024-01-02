using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carKiller : MonoBehaviour
{
    public float explotime = 5f;
    public float killerSpeed;
    public GameObject explo;

    private void Start()
    {
        killerSpeed = 380f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<charControl>().speed > killerSpeed)
            {
                GameObject exploObj = Instantiate(explo, GetComponent<SpriteRenderer>().bounds.center, Quaternion.identity);
                StartCoroutine(destroyEnemyandExplo(exploObj));
            }
        }
    }

    IEnumerator destroyEnemyandExplo(GameObject exploObj)
    {
        transform.position = new Vector2(0f,-200f);
        yield return new WaitForSeconds(explotime);
        Destroy(exploObj);
        print("destroy egg with car");
        Destroy(gameObject);
    }
}
