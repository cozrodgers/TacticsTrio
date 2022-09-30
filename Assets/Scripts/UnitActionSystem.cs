using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private LayerMask unitLayerMask;
    [SerializeField] private Unit selectedUnit;
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (!TryHandleUnitSelection())
            {
                selectedUnit.Move(MouseWorld.GetPosition());
            }

        }
    }
    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask))
        {

            if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                selectedUnit = unit;
                return true;

            }
        }
        return false;

    }
}
