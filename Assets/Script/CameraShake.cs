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
            // Kamera sars�nt�s?s�resi boyunca rasgele bir pozisyon olu�tur
            Vector3 shakePosition = originalPosition + Random.insideUnitSphere * shakeMagnitude;

            // Kameray?sallama pozisyonuyla g�ncelle
            cameraTransform.localPosition = shakePosition;

            elapsedShakeTime += Time.deltaTime;
        }
        else
        {
            // Kamera sars�nt�s?s�resi doldu�unda kameray?eski pozisyonuna geri getir
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
