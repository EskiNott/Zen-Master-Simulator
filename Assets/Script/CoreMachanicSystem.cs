using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoreMachanicSystem : MonoSingleton<CoreMachanicSystem>
{
    public float PushForce;
    public LayerMask layerMask;

    [SerializeField] private bool Dragging = false;
    private Vector3 StartDragging;
    private Vector3 StopDragging;
    private RaycastHit hit;
    private RaycastHit hitSecond;

    private void Update()
    {
        if (!UIManager.Instance.GetUISituation())
        {
            //ClickToPushMachanic();
            DragToBounceMachanic();
        }
    }

    private void DragToBounceMachanic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = RaycastPhysical();
            if (hit.collider.CompareTag("Item"))
            {
                Dragging = true;
                StartDragging = hit.point;
            }
        }
        else if (Input.GetMouseButtonUp(0) && Dragging && hit.collider.GetComponent<Rigidbody>() != null) 
        {
            Dragging = false;
            hitSecond = RaycastPhysical();
            StopDragging = new Vector3(hitSecond.point.x, StartDragging.y, hitSecond.point.z);
            Push(hit.collider.GetComponent<Rigidbody>(), StartDragging - StopDragging, (StartDragging - StopDragging).magnitude * 300);
        }else if (Input.GetMouseButton(0) && Dragging)
        {
/*            RaycastHit hitSecond = RaycastPhysical();
            Vector3 MouseWorld = new Vector3(hitSecond.point.x, StartDragging.y, hitSecond.point.z);
            Debug.DrawLine(StartDragging, MouseWorld, Color.red);*/
        }
    }

    private void Push(Rigidbody rb, Vector3 Direction, float PushForce)
    {
        GameManager.Instance.IncreaseMerit(GameManager.Instance.GetMeritStrength());
        rb.AddForce(Direction.normalized * PushForce);
    }

    private void ClickToPushMachanic()
    {
        hit = RaycastPhysical();
        if (hit.collider != null)
        {
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
                        Push(rb, Direction, PushForce);
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