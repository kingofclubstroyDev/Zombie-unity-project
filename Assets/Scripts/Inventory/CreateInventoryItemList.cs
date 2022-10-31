using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateInventoryItemList {
    [MenuItem("Assets/Create/Inventory Item List")]
    public static InventoryItemsList  Create()
    {
        InventoryItemsList asset = ScriptableObject.CreateInstance<InventoryItemsList>();

        AssetDatabase.CreateAsset(asset, "Assets/InventoryItemList.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}