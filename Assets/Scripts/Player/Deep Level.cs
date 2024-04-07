using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepLevel : MonoBehaviour
{
    [SerializeField]
    float m_minimalDepthLevel = 0f;
    [SerializeField]
    float m_maxDepthLevel = 100f;

    private void Update()
    {
        float m_playerDepth = transform.localPosition.y;
        if (m_playerDepth < m_minimalDepthLevel)
        {
            AkSoundEngine.SetRTPCValue("PlayerDepth", 0, gameObject);
            return;
        }

        if (m_playerDepth > m_maxDepthLevel)
        {
            AkSoundEngine.SetRTPCValue("PlayerDepth", 100, gameObject);
            return;
        }

            m_playerDepth = m_playerDepth / m_maxDepthLevel * 100;
        Debug.Log(m_playerDepth);
            AkSoundEngine.SetRTPCValue("PlayerDepth", m_playerDepth, gameObject);
    }
}
