using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishWandering : MonoBehaviour
{
    [SerializeField]
    float m_wonderingSpeed = 10f;
    [SerializeField]
    GameObject m_wanderingPoint;

    private void Update()
    {
        MoveTheFish();
    }
    private void MoveTheFish(){
        transform.position = Vector3.MoveTowards(transform.position, m_wanderingPoint.transform.position, Time.deltaTime * m_wonderingSpeed);
        transform.Rotate(Random.value, Random.value, Random.value);
    }
}
