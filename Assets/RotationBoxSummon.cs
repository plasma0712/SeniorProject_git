﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBoxSummon : MonoBehaviour
{
    public GameObject[] BoxRotation;

    public const float TileX = 0.62f;
    public const float TileY = 0.62f;

    [HideInInspector]
    public int TileXData = 0;
    [HideInInspector]
    public int TileYData = 0;

    float TileTypeData;
    public Vector3 vPos;

    XMLMapData Current;

    public GameObject Parent;

    public void Awake()
    {
        BoxPostion();
    }

    public void CurrentMapData(int _mapdata)
    {
        Current = XMLMap.Instance.GetMapData(_mapdata);
        TileXData = Current.iMapTileX;
        TileYData = Current.iMapTileY;
        TileTypeData = Current.fType;
        vPos.x = TileX * TileXData;
        vPos.y = TileY * TileYData;
        
        
        if (TileTypeData==1)
        {
            GameObject instance = Instantiate(BoxRotation[0], vPos, Quaternion.identity);
            instance.transform.parent = Parent.transform; // 인스턴트로 생성된 오브젝트를 정리하기 위해서 이용함.
        }
        else if (TileTypeData ==2)
        {
            GameObject instance = Instantiate(BoxRotation[1], vPos, Quaternion.identity);
            instance.transform.parent = Parent.transform; // 인스턴트로 생성된 오브젝트를 정리하기 위해서 이용함.
        }

        else if(TileTypeData==3)
        {
            GameObject instance = Instantiate(BoxRotation[2], vPos, Quaternion.identity);
            instance.transform.parent = Parent.transform; // 인스턴트로 생성된 오브젝트를 정리하기 위해서 이용함.
        }
        else if(TileTypeData ==4)
        {
            GameObject instance = Instantiate(BoxRotation[3], vPos, Quaternion.identity);
            instance.transform.parent = Parent.transform; // 인스턴트로 생성된 오브젝트를 정리하기 위해서 이용함.
        }
        else
        {
            return;
        }
    }

    void BoxPostion()
    {
        XMLMap.Instance.LoadXml();
        for (int k = 0; k < XMLMap.Instance.MapLength(); k++)
        {
            CurrentMapData(k);
        }
    }
}
