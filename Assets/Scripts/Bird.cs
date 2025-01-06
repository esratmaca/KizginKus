using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private Vector3 _initialPosition;  //underscore used as convention 
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 500; //SerializeField, launchPower'ın Unity script bileşeninde değiştirilebilmesini sağlar


    private void Awake()
    {
        _initialPosition = transform.position;
    }

    //her saniyedeki kare başına güncellenir
    public void Update()
    {

        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        //kuşun belirli bir süre hareketsiz olup olmadığını kontrol eder
        if (_birdWasLaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime; 
        }

        if (transform.position.y > 10 ||
            transform.position.y < -20 ||
            transform.position.x > 20 ||
            transform.position.x < -20||
            _timeSittingAround > 3)
        {
            //aktif sahnenin adını yükler
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName); 
        }
    }


    //kuşa fare ile tıklandığında her seferinde çağrılan metod
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        //kuşun mevcut pozisyonunu ayarlar ve nesneye hareket ekler
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;  //yerçekimini sıfırlar
        _birdWasLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    //fare basılı tutulduğunda kuşu hareket ettirir 
    private void OnMouseDrag()
    {
        //yeni bir vektör örneği oluşturur ve fare girdisine ayarlar
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //kuşun görünür olması için newPosition'ı x ve y'ye ayarlar
        transform.position = new Vector3(newPosition.x, newPosition.y);
    } 
}
