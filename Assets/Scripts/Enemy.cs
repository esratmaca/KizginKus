using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //bulut parçacığı prefabını örneklendi
    [SerializeField] private GameObject _cloudParticlePrefab;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        //kuş düşmanla çarpışırsa düşmanı yok et
        if (collision.collider.GetComponent<Bird>() != null)
        {
            //pozisyon (transform) ve rotasyon (quaternion: varsayılan rotasyon) gerçekleştiğinde cloudParticlePrefab'ı oluştur
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return; //quit
        }

        //diğer nesnelerin düşmanla çarpışıp çarpışmadığını kontrol et
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return; //çık
        }

        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return; 
        }
    }
}
