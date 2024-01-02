using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slopingGround : MonoBehaviour
{
    public float zFreezeTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("giris yapildi");
            if(collision.gameObject.GetComponent<charControl>().convCar)
            collision.gameObject.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("cikis yapildi");
            StartCoroutine(addFreezeZ(collision.gameObject));
        }
    }

    IEnumerator addFreezeZ(GameObject gobject)
    {
        print("ienumeratora girdi");
        yield return new WaitForSeconds(zFreezeTime);
        gobject.GetComponent<Rigidbody2D>().constraints |= RigidbodyConstraints2D.FreezeRotation;
    }
}
