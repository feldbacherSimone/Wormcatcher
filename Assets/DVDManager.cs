using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDManager : MonoBehaviour
{
    [SerializeField] private GameObject celvikiDvd;

    [SerializeField] private GameObject[] dvds;

    private List<string> dvdNames = new List<string>();
    private void Start()
    {
        foreach (var dvd in dvds)
        {
            dvdNames.Add(dvd.name);
        }
    }

    public void CheckDvds(string dvdName)
    {
        for(int i = 0; i < dvdNames.Count; i++)
            if (dvdNames[i].Equals(dvdName))
            {
                dvdNames.Remove(dvdNames[i]);
            }
        

        if (dvdNames.Count < 1)
        {
            celvikiDvd.SetActive(true);
        }
    }
}
