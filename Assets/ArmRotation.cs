using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmRotation : MonoBehaviour
{

    public int rotationOffset = 90;

    // Update is called once per frame
    void Update()
    {
        // subtracting the position of the player from the mouse position
        var mouse = Input.mousePosition;
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

