using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLMap : Singleton<XMLMap>
{
    List<XMLMapData> Maps;

    int MapAmount = 0;
    int EightMultiple = 8;

    string filePath = "./Assets/Resources/MapList.xml";

    private void Awake()
    {
        //CreateXml();
        LoadXml();
    }

    public void CreateXml()
    {
        Maps = new List<XMLMapData>();

        for (int i = 0; i < 9; i++)
        {
            for (int k = 0; k < 7; k++)
            {
                XMLMapData Map = new XMLMapData
                {
                    iMapTileName = (i * 7) + k,
                    iMapTileX = k,
                    iMapTileY = i,
                    fType = 0
                };
                Maps.Add(Map);  //위치 애매 바깥for문 끝나기전일 수도있음 확인요망 // 정상적으로 XML에 저장됨
            }
        }

        for(int j=0; j<1;j++)                   // 맵크기를 나타내기위해 만듦
        {
            XMLMapData MapSize = new XMLMapData
            {
                iMapNumber = MapCount()
            };
            Maps.Add(MapSize);
        }


        XmlDocument Document = new XmlDocument();
        XmlElement MapListElement = Document.CreateElement("MapList");
        Document.AppendChild(MapListElement);

        foreach (XMLMapData Map in Maps)
        {
            XmlElement MapElement = Document.CreateElement("Map");
            MapElement.SetAttribute("iMapTileName", Map.iMapTileName.ToString());
            MapElement.SetAttribute("iMapTileX", Map.iMapTileX.ToString());
            MapElement.SetAttribute("iMapTileY", Map.iMapTileY.ToString());
            MapElement.SetAttribute("fType", Map.fType.ToString());

            MapListElement.AppendChild(MapElement);
        }

        XmlDocument MapSizeDocument = new XmlDocument();
        XmlElement MapSizeListElement = MapSizeDocument.CreateElement("MapSize");
        MapSizeDocument.AppendChild(MapSizeListElement);

        foreach(XMLMapData MapSize in Maps)
        {
            XmlElement MapSizeElement = MapSizeDocument.CreateElement("Map");
            MapSizeElement.SetAttribute("iMapNumber", MapSize.iMapNumber.ToString());

            MapSizeListElement.AppendChild(MapSizeElement);
        }

        Document.Save(filePath);
    }

    public void LoadXml()
    {
        Maps = new List<XMLMapData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement MapListElement = Document["MapList"];

        foreach (XmlElement MapElement in MapListElement.ChildNodes)
        {
            XMLMapData Map = new XMLMapData
            {
                iMapTileName = System.Convert.ToInt32(MapElement.GetAttribute("iMapTileName")),
                iMapTileX = System.Convert.ToInt32(MapElement.GetAttribute("iMapTileX")),
                iMapTileY = System.Convert.ToInt32(MapElement.GetAttribute("iMapTileY")),
                fType = System.Convert.ToSingle(MapElement.GetAttribute("fType")),
            };
            Maps.Add(Map);
        }
    }

    public int MapLength()
    {
        return Maps.Count;
    }

    public int MapCount()
    {
        if(Maps.Count%64 ==0)
        {
            MapAmount = (Maps.Count / 64);
            return MapAmount;
        }
        else
        {
            return 0;
        }
    }

    public XMLMapData GetMapData(int _num)
    {
#pragma warning disable CS0162 // 접근할 수 없는 코드가 있습니다.
        for (int i = 0; i < MapLength(); i++)
#pragma warning restore CS0162 // 접근할 수 없는 코드가 있습니다.
        {
            if(Maps[i].iMapTileName == _num)
            {
                return Maps[i];
            }
        }
        return null;
    }

}
