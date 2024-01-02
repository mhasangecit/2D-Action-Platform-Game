using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBallet : MonoBehaviour
{
    GameObject player;
    float drction,bulletSpeed;
    Camera camera;
    float cameraWidth;
    public GameObject explo;
    public float explotime;

    private void Start()
    {
        player = GameObject.Find("player");
        drction = player.GetComponent<charControl>().direction;
        bulletSpeed = player.GetComponent<charControl>().bullSpeed;
        camera = player.GetComponent<charControl>().cam;
        cameraWidth = camera.orthographicSize * camera.aspect;
    }

    private void Update()
    {
        if (drction < 0) GetComponent<SpriteRenderer>().flipX = true;
        else GetComponent<SpriteRenderer>().flipX = false;

        transform.Translate(drction * Time.deltaTime * bulletSpeed, 0f, 0f);

        float cameraBorderRight = camera.transform.position.x + cameraWidth;
        float cameraBorderLeft = camera.transform.position.x - cameraWidth;

        if (transform.position.x > cameraBorderRight || transform.position.x < cameraBorderLeft)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") || collision.CompareTag("enemy2"))
        {
            //Vector3 bombPos = new Vector3(collision.transform.position.x, collision.transform.position.y, 0f);
            GameObject exploObj=Instantiate(explo, collision.bounds.center, Quaternion.identity);
            StartCoroutine(destroyEnemyandExplo(collision.gameObject, exploObj));
            Destroy(gameObject);
        }
    }

    IEnumerator destroyEnemyandExplo(GameObject enemy, GameObject exploObj)
    {
        Destroy(enemy);
        yield return new WaitForSeconds(explotime);
        Destroy(exploObj);
        print("corutuin");
    }
}
