using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageShake : MonoBehaviour
{
    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.5f;

    private Vector3 initialPosition;

    public void ShakeCamera()
    {
        initialPosition = transform.position;
        StartCoroutine(PerformShake(shakeDuration));
        print("kamera sallandi");
    }

    private IEnumerator PerformShake(float duration)
    {
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float xOffset = Random.Range(-1f, 1f) * shakeMagnitude;
            float yOffset = Random.Range(-1f, 1f) * shakeMagnitude;
            transform.position = new Vector3(initialPosition.x + xOffset, initialPosition.y + yOffset, initialPosition.z);
            yield return null;
        }

        // Sallanma süresi sona erdiğinde kamerayı başlangıç konumuna getir
        transform.position = initialPosition;
    }

}
