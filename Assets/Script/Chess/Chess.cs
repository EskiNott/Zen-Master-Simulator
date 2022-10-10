using UnityEngine;

[RequireComponent(typeof(Outline), typeof(Rigidbody), typeof(Collider))] 
public class Chess : MonoBehaviour
{
    [SerializeField] private Transform ThisTrans;
    [SerializeField] private Outline ThisOutline;
    [SerializeField] private Collider ThisCollider;
    private Vector3 OriginalPosition;
    private Quaternion OriginalRotation;

    private void Start()
    {
        OriginalPosition = ThisTrans.position;
        OriginalRotation = ThisTrans.rotation;
    }


}
