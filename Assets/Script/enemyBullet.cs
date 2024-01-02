using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class enemyBullet : MonoBehaviour
{
    GameObject player;
    float direction;
    public float bulletSpeed;
    public float damage;
    float distance;

    Camera camera;
    float cameraWidth;
    public static float cameraBorderRight;
    public static float cameraBorderLeft;

    public GameObject vcam;

    public GameObject explo;
    public float explotime;

    Text healthAmount;


    void Awake()
    {
        player = GameObject.Find("player");
        vcam = GameObject.Find("CM vcam1");

        if (player != null)
        {
            distance = player.transform.position.x - transform.position.x;
            camera = player.GetComponent<charControl>().cam;
            healthAmount = player.GetComponent<charInfo>().healthText;
            cameraWidth = camera.orthographicSize * camera.aspect;
        }

        if (distance > 0f) direction = 1f;
        else direction = -1f;

    }

    private void Start()
    {
        //camShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * bulletSpeed, 0f, 0f);

        if (player != null)
        {
            cameraBorderRight = camera.transform.position.x + cameraWidth;
            cameraBorderLeft = camera.transform.position.x - cameraWidth;
        }
        else
        {

        }


        if (transform.position.x > cameraBorderRight || transform.position.x < cameraBorderLeft)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<charInfo>().health -= damage;

            //vcam.GetComponent<CinemachineImpulseSource>().GenerateImpulse(1f);

            if (player.GetComponent<charInfo>().health < 0)
                player.GetComponent<charInfo>().health = 0;

            healthAmount.text = player.GetComponent<charInfo>().health.ToString();

            if (player.GetComponent<charInfo>().health <= 0)
            {
                GameObject exploObj = Instantiate(explo, collision.bounds.center, Quaternion.identity);
                StartCoroutine(destroyEnemyandExplo(collision.gameObject, exploObj));
                player.GetComponent<charInfo>().gameOver();
            }
            Destroy(gameObject);
        }
    }

    IEnumerator destroyEnemyandExplo(GameObject target, GameObject exploObj)
    {
        target.SetActive(false);
        //camera.GetComponent<CinemachineImpulseSource>().GenerateImpulse(0.5f);
        //target.SetActive(false);
        yield return new WaitForSeconds(explotime);
        Destroy(exploObj);
    }

}
