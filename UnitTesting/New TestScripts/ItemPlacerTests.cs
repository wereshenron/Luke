using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class ItemPlacerTests
{
    [Test]
    public void PlaceItemAtCoordinates()
    {
        // Create an ItemPlacer object
        GameObject itemPlacerObj = new GameObject("ItemPlacer");
        ItemPlacer itemPlacer = itemPlacerObj.AddComponent<ItemPlacer>();

        // Create a dummy item prefab
        GameObject dummyItemPrefab = new GameObject("DummyItemPrefab");
        itemPlacer.itemPrefab = dummyItemPrefab;

        // Place the item at the specified coordinates
        itemPlacer.PlaceItem(1, 2);

        // Check if the item was instantiated at the specified position
        GameObject placedItem = GameObject.Find("DummyItemPrefab(Clone)");
        Assert.NotNull(placedItem);
        Assert.AreEqual(new Vector3(1, 2, 0), placedItem.transform.position);
    }
}
