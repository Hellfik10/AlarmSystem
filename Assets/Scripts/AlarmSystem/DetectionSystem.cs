using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DetectionSystem : MonoBehaviour
{
    private bool _thiefInHouse = false;

    public event Action<bool> ThiefDiscovered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Mover>(out _))
        {
            _thiefInHouse = true;

            ThiefDiscovered?.Invoke(_thiefInHouse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Mover>(out _))
        {
            _thiefInHouse = false;

            ThiefDiscovered?.Invoke(_thiefInHouse);
        }
    }
}
