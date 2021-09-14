using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private bool _goingDown = false;
    private float _speed = 1.0f;

    [SerializeField]
    private Transform _secondFloor, _firstFloor;

    public void CallElevator()
    {
        _goingDown = !_goingDown;
    }

    private void FixedUpdate()
    {
        if (_goingDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _firstFloor.position, _speed * Time.deltaTime);
        }
        else if(_goingDown == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _secondFloor.position, _speed * Time.deltaTime);
        }
    }
}
