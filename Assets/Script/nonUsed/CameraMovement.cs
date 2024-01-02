using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public float moveDuration = 0.2f;
    public Vector3 moveDirection = new Vector3(0.1f, 0f, 0f);

    private Vector3 originalPosition;
    private float elapsedMoveTime = 0f;

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
        if (elapsedMoveTime < moveDuration)
        {
            // Hafif orta hareketi hesapla
            float progress = elapsedMoveTime / moveDuration;
            Vector3 targetPosition = originalPosition + (moveDirection * progress);

            // Kamerayý yeni pozisyonla güncelle
            cameraTransform.localPosition = targetPosition;

            elapsedMoveTime += Time.deltaTime;
        }
        else
        {
            // Hareket süresi dolduðunda kamerayý eski pozisyonuna geri getir
            cameraTransform.localPosition = originalPosition;
        }
        MoveToCenter();
    }

    // Kamerayý ortaya doðru kaydýrmak için bu fonksiyonu çaðýrabilirsiniz
    public void MoveToCenter()
    {
        elapsedMoveTime = 0f;
    }
}
