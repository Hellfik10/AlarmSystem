using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private DetectionSystem _detectionSystem;
    [SerializeField] private AlarmSystem _alarmSystem;

    private void OnEnable()
    {
        _detectionSystem.ThiefDiscovered += ChangeAlarmStatus;
    }
    private void OnDisable()
    {
        _detectionSystem.ThiefDiscovered -= ChangeAlarmStatus;
    }

    private void ChangeAlarmStatus(bool thiefInHouse)
    {
        if (thiefInHouse)
        {
            _alarmSystem.EnableSignal();
        }
        else
        {
            _alarmSystem.DisableSignal();
        }
    }
}
