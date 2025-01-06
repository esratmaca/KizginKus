using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomPosition : MonoBehaviour
{
    //Pozisyonları tutacak vektör dizisi
    public Vector2[] positions;

    //Oyun başladığında çalışacak metod
    void Start()
    {
        //Positions dizisinin uzunluğu içinden rastgele bir sayı seç (0 ile positions.Length arasında)
        int randomNumber = Random.Range(0, positions.Length);

        //Nesnenin pozisyonunu seçilen rastgele indeksteki pozisyona ayarla
        transform.position = positions[randomNumber];
    }
}