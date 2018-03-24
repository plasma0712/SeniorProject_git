using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : Singleton<TileInfo>
{
    public GameObject[] TileType;

    public int[] pos = new int[2];

    public bool MyUnitTile(int PosX,int PosY)        // IsNearMyTile
    {
        TileInfo Exist;

        Exist = Map.Instance.MapTiles[pos[PosX], pos[PosY]];

        if(Exist != null)
        {
            return true;
        }

        return false;
    }

    //public TileInfo[] MyTile(bool _isIncludeThisTile = false)
    //{
    //    if (_isIncludeThisTile)
    //    {
    //        return new TileInfo[XMLMap.Instance.MapLength();]
    //
    //            
    //    }
    //    else
    //    {
    //        return
    //    }
    //}

}
