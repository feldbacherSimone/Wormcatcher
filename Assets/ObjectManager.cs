using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects;
    [SerializeField] private GameObject doors;

    private void Start()
    {
        doors.SetActive(false);
    }

    public void AddGameObject(string name)
    {
        GameObject foundItem = null; 
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name.Equals(name))
            {
                foundItem = gameObject;
            } 
        }

        gameObjects.Remove(foundItem);
        if (gameObjects.Count < 1)
        {
            doors.SetActive(true);
        }
    }
}
