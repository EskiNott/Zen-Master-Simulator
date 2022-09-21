using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoreMachanicSystem : MonoSingleton<CoreMachanicSystem>
{
    public float PushForce = 100.0f;
    public LayerMask layerMask;
    private void Update()
    {
        if (!UIManager.Instance.GetUISituation())
        {
            ClickToPushMachanic();
        }
    }

    public void ClickToPushMachanic()
    {
        RaycastHit hit = RaycastPhysical();
        if (hit.collider != null)
        {
            Debug.Log("collider != null!");
            GameObject hitObject = hit.collider.gameObject;
            Transform hitTrans = hit.transform;
            if (hitObject.CompareTag("Item"))
            {
                Debug.Log("Item!");
                Vector3 Direction = new Vector3
                    (UnityEngine.Random.Range(-1.0f, 1.0f)
                    , 0
                    , UnityEngine.Random.Range(-1.0f, 1.0f)).normalized;
                Rigidbody rb = hitObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Push!");
                        GameManager.Instance.Merit++;
                        rb.AddForce(Direction * PushForce);
                    }
                }
            }
        }
    }

    public static RaycastHit RaycastPhysical()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast((Ray)ray, out hit, float.PositiveInfinity, 3);
        return hit;
    }
}