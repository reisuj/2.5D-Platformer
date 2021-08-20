using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField]
    private float _gravity = 0.5f;
    [SerializeField]
    private float _playerSpeed = 5.0f;    
    [SerializeField]
    private float _jumpHeight = 25.0f;
    [SerializeField]
    private int _coins;
    private float _yVelocity;
    private bool _canDoubleJump = false;

    private CharacterController _controller;

    private UIManager _uiManager;

    private int _lives = 3;

    private Transform _spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.Log("UIManager is NULL!!");
        }

        _uiManager.UpdateLivesDisplay(_lives);

        _spawnPoint = this.transform;

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _playerSpeed;

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump == true)
            {
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
            }
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);

        if (transform.position.y < -15.0f)
        {
            _lives--;
            if (_lives < 1)
            {
                SceneManager.LoadScene(0);
            }

            transform.position = _spawnPoint.position;
            _uiManager.UpdateLivesDisplay(_lives);
        }
    }

    public void AddCoin()
    {
        _coins++;

        _uiManager.UpdateCoinDisplay(_coins);
    }
}
