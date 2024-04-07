using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepLevel : MonoBehaviour
{
    [SerializeField]
    float m_minimalDepthLevel = 0f;
    [SerializeField]
    float m_maxDepthLevel = 100f;

    float m_playerDepth;

    private float SetPlayerDepth
    {
        get { return m_minimalDepthLevel; }
        set {
            if (value < m_minimalDepthLevel)
            {
                Debug.LogWarning(0);
                AkSoundEngine.SetRTPCValue("PlayerDepth", 0, gameObject);
            }
            else if (value > m_minimalDepthLevel)
            {
                Debug.LogWarning(100);
                AkSoundEngine.SetRTPCValue("PlayerDepth", 100, gameObject);
            }
            else {
                Debug.LogWarning(value / m_maxDepthLevel * 100);
                m_playerDepth = value / m_maxDepthLevel * 100;
            }
        }
    }

    private void Update()
    {
        SetPlayerDepth = transform.position.y;
    }
}
