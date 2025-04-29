using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virus : MonoBehaviour
{
    [Header("F�rlatma Ayarlar�")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float minFireInterval = 1f;
    public float maxFireInterval = 3f;

    [Header("Sal�n�m Ayarlar�")]
    public float bobAmplitude = 0.5f;   // Yukar�-a�a�� hareket mesafesi
    public float bobFrequency = 1f;     // H�z �arpan�

    private Vector3 startPosition;      // Ba�lang�� pozisyonunu saklayaca��z

    void Start()
    {
        // Ba�lang�� pozisyonunu kaydet
        startPosition = transform.position;

        // At�� d�ng�s�n� ba�lat
        StartCoroutine(FireRoutine());
    }

    void Update()
    {
        // Zaman� bobFrequency ile �arparak sin�s dalgas� �ret
        float offsetY = Mathf.Sin(Time.time * bobFrequency) * bobAmplitude;  // :contentReference[oaicite:0]{index=0}

        // Orijinal X,Z koruyarak Y�yi g�ncelle
        transform.position = new Vector3(
            startPosition.x,
            startPosition.y + offsetY,
            startPosition.z
        );
    }

    IEnumerator FireRoutine()
    {
        while (true)
        {
            float interval = Random.Range(minFireInterval, maxFireInterval);
            yield return new WaitForSeconds(interval);
            if (projectilePrefab != null && firePoint != null)
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }
}
