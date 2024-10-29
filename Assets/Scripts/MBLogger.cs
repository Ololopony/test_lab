using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBLogger : MonoBehaviour
{
    private void Awake()
    {
        Log("Awake");
    }

    private void OnEnable()
    {
        Log("OnEnable");
    }

    private void Start()
    {
        Log("Start");
    }

    private void Update(){}

    private void LateUpdate(){}

    private void OnDisable()
    {
        Log("OnDisable");
    }

    private void OnDestroy()
    {
        Log("OnDestroy");
    }

    private void Log(string msg)
    {
        Debug.Log($"{name}.{msg} - frame {Time.frameCount}");
    }
}
