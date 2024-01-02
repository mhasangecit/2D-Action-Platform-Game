using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openBg : MonoBehaviour
{
    public GameObject bg;
    public float destroyTime;
    public GameObject bg2,bg3;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bg.SetActive(true);
        StartCoroutine(destroy2bg());
    }

    IEnumerator destroy2bg()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(bg2);
        Destroy(bg3);
    }
}
