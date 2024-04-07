using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingPoint : MonoBehaviour
{
    [SerializeField]
    float m_moveSpeed = 1f;
    [SerializeField]
    float m_sinFrequensy = 10f;
    [SerializeField]
    float m_sinMagnitude = 10f;
    [SerializeField]
    float m_cosFrequensy = 10f;
    [SerializeField]
    float m_cosMagnitude = 10f;

    private Vector3 axisRight;
    private Vector3 axisUp;
    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
        axisRight = transform.right;
        axisUp = transform.up;
    }
    private void Update()
    {
        pos += transform.forward * Time.deltaTime * m_moveSpeed;
        transform.position = pos;
        transform.position += axisRight * Mathf.Sin(Time.time * m_sinFrequensy) * m_sinMagnitude * Random.value;
        transform.position += axisUp * Mathf.Cos(Time.time * m_cosFrequensy) * m_cosMagnitude * Random.value;
    }
}
