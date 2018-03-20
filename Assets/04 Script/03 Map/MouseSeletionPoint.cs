using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSeletionPoint : MonoBehaviour
{
    public GameObject followingCube;

    void Update()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 5));
        followingCube.transform.position = newPosition;
    }

}
