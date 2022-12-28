using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericChallenge1 : MonoBehaviour
{
    [SerializeField] private GameObject prefab;


    // Start is called before the first frame update
    void Start()
    {
        GenericMethod<Rigidbody>();

        GenericMethod<BoxCollider>();

        var genericList = GenericChallenge<GameObject>(5);


    }


    private void GenericMethod<T>() where T : Component
    {
        var newObject = Instantiate(prefab);

        newObject.AddComponent<T>();
        newObject.SetActive(false);
        Debug.Log($"Added component of type {typeof(T)}");
    }

    private List<T> GenericChallenge<T>(int amount) where T : new()
    {
        var newList = new List<T>();

        for(int i = 0; i < amount; i++)
        {
            T newObj = new T();
            newList.Add(newObj);
        }

        Debug.Log($"Created list of type {typeof(T)} containing {amount} items");

        return newList;
    }
}
