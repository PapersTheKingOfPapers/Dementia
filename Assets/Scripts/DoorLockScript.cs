using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockScript : MonoBehaviour
{
    public bool _doorLock;

    [SerializeField] private Rigidbody door;
    [SerializeField] private BoxCollider collider;

    private RigidbodyConstraints locked = RigidbodyConstraints.FreezeAll;
    private RigidbodyConstraints unLocked = RigidbodyConstraints.None;

    // Start is called before the first frame update
    void Start()
    {
        if(_doorLock == true)
        {
            door.constraints = locked;
            collider.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_doorLock == false)
        {
            door.constraints = unLocked;
            collider.enabled = false;
        }
    }
}
