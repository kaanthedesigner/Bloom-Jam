using UnityEngine;

public class Persistent : MonoBehaviour
{
    void Awake()
    {
        // if another copy of this object already exists, destroy this one
        foreach (var obj in FindObjectsByType<Persistent>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            if (obj != this && obj.gameObject.name == gameObject.name)
            {
                Destroy(gameObject);
                return;
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
