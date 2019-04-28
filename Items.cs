using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items {

    private Dictionary<int, string> ItemList;

    public Items()
    {
        ItemList = new Dictionary<int, string>();
        Debug.Log("construct");


        ItemList.Add(1, "Speaker");
        
        ItemList.Add(2, "TV");
        
        ItemList.Add(3, "Chair");

        ItemList.Add(4, "NuclearMaterial");

        ItemList.Add(5, "Car");

        ItemList.Add(6, "InfinityGlove");
    }

    public string GetItem(int key)
    {
        foreach (var item in ItemList)
        {
            if (item.Key == key)
            {
                Debug.Log("return");
                return item.Value;
            }
            
        }

        return null;
    }

    public int ItemCount()
    {
        return ItemList.Count;
    }

}
