using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Follow2D : MonoBehaviour
{
    public string TargetName = "Coggy 1";

    Transform target;
    Vector3 offset;

    void Start()
    {
        if (Globals.CameraOffset != Vector3.zero)
            offset = Globals.CameraOffset;

        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.Find(TargetName).transform;
            if (offset == Vector3.zero)
                Globals.CameraOffset = offset = transform.position - target.position;

            return;
        }

        transform.position = target.position + offset;
    }
}
