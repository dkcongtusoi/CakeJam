using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredients", menuName = "Scriptable Objects/Ingredients")]
public class ItemScriptableObject : ScriptableObject
{
    [Header("All lower cases")]
    public string itemName;
    [Space]
    [Header("All UPPER cases")]
    public Sprite itemSprite;
}
