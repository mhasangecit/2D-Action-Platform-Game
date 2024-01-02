using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public float x;
    public float sinir1,sinir2;
    public GameObject ballet;
    bool turn;
    public bool sinirda;
    public float tolerans = 0.1f;
    public GameObject panel;

    void Start()
    {
        
    }
    /*
    void Update()
    {
        fire();
        
        if (Mathf.Abs(transform.position.x - sinir1) < tolerans)
        {
            turn = true;
        }
        else if(Mathf.Abs(transform.position.x - sinir2) < tolerans)
        {
            turn = false;
        }

        if (turn)
        {
            transform.Translate(x * Time.deltaTime, 0f, 0f);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.Translate(-x * Time.deltaTime, 0f, 0f);
            GetComponent<SpriteRenderer>().flipX = true;
        }

    } */

    private void Update()
    {
        fire();
    }

    IEnumerator fire()
    {
        Instantiate(ballet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
    }

    IEnumerator dierSahne()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(1);
    }

    public void storyMode()
    {
        panel.SetActive(true);
        StartCoroutine(dierSahne());
    }

    IEnumerator forever()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(2);
    }

    public void endlessMode()
    {
        panel.SetActive(true);
        StartCoroutine(forever());
    }
}
