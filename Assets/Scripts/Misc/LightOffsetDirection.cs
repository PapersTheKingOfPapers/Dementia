using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LightOffsetDirection : MonoBehaviour
{
    [SerializeField] private Move move = null;
    [SerializeField] private Transform lightObject = null;
    [SerializeField, Range(0f, 1f)] private float maxlightOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 offsetDirection = move.GetDirection();

        float offset = Mathf.Lerp(lightObject.localPosition.x, maxlightOffset * offsetDirection.x, Time.deltaTime * 5f);

        lightObject.localPosition = new Vector3(offset, lightObject.localPosition.y, lightObject.localPosition.z);
    }
}
