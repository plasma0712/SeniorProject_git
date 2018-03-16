using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map : Singleton<Map>
{
    float TileX = 0.62f;
    float TileY = 0.62f;

    public int TileXData = 0;
    public int TileYData = 0;
    public int MapCount;
    public int MapSize;

    XMLMapData Current;
    Vector3 vPos;
    public GameObject Tile;
    public GameObject Parent;
    [SerializeField]
    List<GameObject> TileList = new List<GameObject>();


    private void Start()
    {
        Culling();
    }

    public void CurrentMapData(int _mapdata)
    {
        Current = XMLMap.Instance.GetMapData(_mapdata);
        TileXData = Current.iMapTileX;
        TileYData = Current.iMapTileY;
        vPos.x = TileX * TileXData;
        vPos.y = TileY * TileYData;

        //Debug.Log("X_Pos : " + TileXData + "Y_Pos : " + TileYData);
    }

    void Culling()
    {
        MapCount = 0;
        XMLMap.Instance.LoadXml();
        for (int k = 0; k < XMLMap.Instance.MapLength(); k++)
        {
            CurrentMapData(k);
            GameObject instance = (GameObject)Instantiate(Tile, vPos, Quaternion.identity);
            instance.transform.parent = Parent.transform; // 인스턴트로 생성된 오브젝트를 정리하기 위해서 이용함.
            TileList.Add(instance);                       // 인스턴트로 생성된 오브젝트를 리스트로 넣어 관리하기 위해 함.
            MapCount++;                                   // MapCount를 이용하여 현재 깔린 타일의 수를 알기 위함
        }
    }

    public void MapAddFuction()
    {
        MapSize = MapCount / 63;
        for (int TileY = 0; TileY < 9; TileY++)
        {
            for (int TileX = 0; TileX < 7; TileX++)
            {
                XMLMap.Instance.AddXmlNode(((TileY * 7 + TileX) + MapCount).ToString(), (TileX + 7 * MapSize).ToString(), TileY.ToString(), "0");
            }
        }

        XMLMap.Instance.LoadXml();
        Culling();

        // XMLMap.Instance.AddXmlNode("가", "가", "가", "가");
    }

}
