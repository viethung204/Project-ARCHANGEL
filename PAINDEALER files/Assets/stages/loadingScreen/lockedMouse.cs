using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
