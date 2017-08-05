using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance = null;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}