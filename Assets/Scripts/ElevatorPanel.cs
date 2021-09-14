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

            if (Input.GetKey(KeyCode.E) && player.GetCoinAmount() >= _requiredCoins)
            {
                _callButton.material.color = Color.green;
                _elevator.GetComponent<Elevator>().CallElevator();
            }
        }
    }
}
