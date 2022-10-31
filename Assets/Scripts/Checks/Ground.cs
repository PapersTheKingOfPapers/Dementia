using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private bool onGround;
    private float friction;

    private void OnCollisionEnter(Collision collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
        friction = 0f;
    }

    private void EvaluateCollision(Collision collision)
    {
        for(int i=0; i < collision.contactCount; i++)
        {
            Vector3 normal = collision.GetContact(i).normal;
            onGround |= normal.y >= 0.9f;
        }
    }

    private void RetrieveFriction(Collision collision)
    {
        PhysicMaterial material = collision.collider.sharedMaterial;

        friction = 0;

        if(material != null)
        {
            friction = material.dynamicFriction;
        }
    }

    public bool GetOnGround()
    {
        return onGround;
    }

    public float GetFriction()
    {
        return friction;
    }

}
