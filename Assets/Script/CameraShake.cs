using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.1f;

    private Vector3 originalPosition;
    private float elapsedShakeTime = 0f;

    public bool shakeState;

    private void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent<Transform>();
        }
    }

    private void Start()
    {
        originalPosition = cameraTransform.localPosition;
    }

    private void Update()
    {
        if (elapsedShakeTime < shakeDuration)
        {
            // Kamera sarsýntýs?süresi boyunca rasgele bir pozisyon oluþtur
            Vector3 shakePosition = originalPosition + Random.insideUnitSphere * shakeMagnitude;

            // Kameray?sallama pozisyonuyla güncelle
            cameraTransform.localPosition = shakePosition;

            elapsedShakeTime += Time.deltaTime;
        }
        else
        {
            // Kamera sarsýntýs?süresi dolduðunda kameray?eski pozisyonuna geri getir
            cameraTransform.localPosition = originalPosition;
        }

        if(shakeState) Shake();
    }

    public void Shake()
    {
        elapsedShakeTime = 0f;
    }

    public void shakeTrue()
    {
        shakeState = true;
    }
    public void shakeFalse()
    {
        shakeState = false;
    }
}
