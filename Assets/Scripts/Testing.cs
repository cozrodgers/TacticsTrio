using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    GridSystem gridSystem;
    [SerializeField] Transform debugPrefab;

    private void Start()
    {
        gridSystem = new GridSystem(10, 10, 2);
        gridSystem.CreateDebugObjects(debugPrefab);
    }
    void Update()
    {
        Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition()));
    }


}
