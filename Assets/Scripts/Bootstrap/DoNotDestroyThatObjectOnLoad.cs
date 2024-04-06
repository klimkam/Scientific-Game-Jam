using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyThatObjectOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
