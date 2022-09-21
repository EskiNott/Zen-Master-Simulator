using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Item : MonoBehaviour
{
    public int ID;
    public int MeritAddition;
    public float MeritMultiply;
    public Transform ItemTrans;

}
