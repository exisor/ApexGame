using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    public inGameCursor InGameCursor;
    public void ChangeFollowerBuilding(GameObject obj)
    {
        InGameCursor.ChangeBuilding(obj);
    }
}
