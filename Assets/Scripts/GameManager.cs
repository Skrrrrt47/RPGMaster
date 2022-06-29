using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    // Update is called once per frame
    void Update()
    {
        ClickTarget();
    }

    private void ClickTarget() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,Mathf.Infinity,1024);
   
            if (hit.collider != null)
            {
                player.MyTarget = hit.transform;
            }
            else
            {
                player.MyTarget = null;
            }
        }
        
    }
}
