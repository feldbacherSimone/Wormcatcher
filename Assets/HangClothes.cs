using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts.GameplayManagers;
using UnityEngine;

public enum Clothing
{
    Coat, 
    Shoes, 
    Key,
}
public class HangClothes : MonoBehaviour
{
    private readonly Dictionary<Clothing, bool> clothingHung = new Dictionary<Clothing, bool>();
    [SerializeField] private Vignette1Manager vignette1Manager;
   
    private void InitializeDictionary()
    {
        foreach (Clothing clothingType in Enum.GetValues(typeof(Clothing)))
        {
            clothingHung[clothingType] = false;
        }
    }
    private void PrintDictionaryContent()
    {
        foreach (var kvp in clothingHung)
        {
            Debug.Log($"{kvp.Key}: {kvp.Value}");
        }
    }
    private bool AllClothesHung()
    {
        foreach (bool isHung in clothingHung.Values)
        {
            if (!isHung)
            {
                return false; 
            }
        }
        return true; 
    }

    public void HangItem(Clothing clothingItem)
    {
        clothingHung[clothingItem] = true;
        PrintDictionaryContent();
        if (AllClothesHung())
        {
            vignette1Manager.ChangeToApartment();
        }
    }

    private void Start()
    {
        InitializeDictionary();
    }
}
