using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_playerTransform.position.x, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().PlayerDied();
            Debug.Log("Player died");
        }
    }
}
