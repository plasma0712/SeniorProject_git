using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSeletionPoint : Singleton<MouseSeletionPoint>
{
    public GameObject My;

    public void OnMouseEnter()
    {
        if (MonsterSummon.Instance.bBuy == true)
        {
            MonsterSummon.Instance.TileIn = true;
            MonsterSummon.Instance.vPoint = My.transform.position;
        }
    }
    public void OnMouseExit()
    {
        if (MonsterSummon.Instance.bBuy == true)
        {
            MonsterSummon.Instance.vPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 5)); ;
        }
    }
}
