using UnityEngine;
using System.Collections;

public class inGameCursor : MonoBehaviour
{
    public Texture2D cursorReleaseTexture;
    public Texture2D cursorPressTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private Vector3 ClickPosition;

    private GameObject _createdBuilding;
    private GameObject _follower;

    public void ChangeBuilding(GameObject building)
    {
        if (_follower != null)
        {
            Destroy(_follower);
        }
        _follower = Instantiate(building, ClickPosition, transform.rotation);
        _follower.AddComponent<Follower>();
        SetAlpha(_follower, 0.2f);
    }
    private void SetAlpha(GameObject obj, float alpha)
    {
        var color = obj.GetComponent<SpriteRenderer>().color;
        color.a = alpha;
        obj.GetComponent<SpriteRenderer>().color = color;
    }
    void Start()
    {

        
    }

    void Update()
    {
        if (_follower != null)
        {
            _follower.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 5f));

            if (_follower.GetComponent<Follower>().CollisionCheck > 0)
            {
                SetAlpha(_follower, 0.0f);
            }

            if (_follower.GetComponent<Follower>().CollisionCheck == 0)
            {
                SetAlpha(_follower, 0.2f);
            }

            if (Input.GetMouseButtonDown(0) && _follower.GetComponent<Follower>().CollisionCheck == 0)
            {

                
                ClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 5f));
                ClickPosition.z = ClickPosition.y;
                var newBuilding = Instantiate(_follower, ClickPosition, transform.rotation);
                SetAlpha(newBuilding, 1f);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorPressTexture, hotSpot, cursorMode);
        }


        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("Released left click.");
            Cursor.SetCursor(cursorReleaseTexture, hotSpot, cursorMode);
        }
    }

}
