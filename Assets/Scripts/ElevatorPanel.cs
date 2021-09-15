using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _callButton;
    [SerializeField]
    private int _requiredCoins = 8;
    [SerializeField]
    private Elevator _elevator;
    [SerializeField]
    private bool _elevatorCalled = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag =="Player")
        {
            Player player = other.GetComponent<Player>();

            if (Input.GetKeyDown(KeyCode.E) && player.GetCoinAmount() >= _requiredCoins && _elevatorCalled == false)
            {
                _elevator.GetComponent<Elevator>().CallElevator();
                _callButton.material.color = Color.green;
                _elevatorCalled = true;                
            }
            else if (_elevatorCalled == true)
            {
                _callButton.material.color = Color.red;
                _elevatorCalled = false;
            }
        }
    }
}
