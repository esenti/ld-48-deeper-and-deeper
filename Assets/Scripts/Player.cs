using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _gameOverText;

    private float _speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -3.3f)
            {
                transform.position = new Vector3(transform.position.x - Time.deltaTime * _speed, transform.position.y, 0.0f);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < 3.3f)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * _speed, transform.position.y, 0.0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
