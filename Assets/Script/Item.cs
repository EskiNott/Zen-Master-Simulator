using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public Transform ItemTrans;
    public Collider ItemCollider;
    public Rigidbody ItemRigidbody;

    private void Update()
    {
        if(ItemTrans.position.y < -1)
        {
            ItemTrans.position = new Vector3(ItemTrans.position.x, 15, ItemTrans.position.z);
        }
    }
}
