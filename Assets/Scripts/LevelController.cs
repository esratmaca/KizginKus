using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Her karede bir kez güncellenir
    void Update()
    {
        //her düşmanı döngüyle kontrol et
        foreach (Enemy enemy in _enemies)
        {
            //düşman ölmediyse metoddan çık
            if (enemy != null)
            {
                return;
            }

            Debug.Log("You killed all enemies");

            //indeksi artır
            _nextLevelIndex++;
            //sonraki seviyeyi yükle
            string nextLevelName = "Level" + _nextLevelIndex;
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
