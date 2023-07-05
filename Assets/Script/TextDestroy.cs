using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDestroy : MonoBehaviour
{
    public float DestroyTime = 3f;
    public Vector3 Offset = new Vector3(0,200,0);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,DestroyTime);

        transform.localPosition += Offset;
    }
    private void LateUpdate()
    {
        var cameraToLookAt = Camera.main;
        transform.LookAt(cameraToLookAt.transform);
        transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);
    }
}
