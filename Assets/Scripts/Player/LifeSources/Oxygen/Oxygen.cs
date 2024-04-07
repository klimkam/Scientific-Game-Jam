using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Oxygen : MonoBehaviour
{
    [SerializeField]
    Animator m_oxygenAnimator;
    [SerializeField]
    float m_timeBetweenBreaths = 1f;

    //Should match the amount of frames at Oxygen.png
    int m_oxygenCurrentLevel = 111;
    int m_oxygenMaxLevel = 111;

    int OxygenCurrentLevel {
        get { return m_oxygenCurrentLevel; }
        set {
            if (value == 0) {
                Suffocate();
            }
            m_oxygenCurrentLevel = value;
        }
    }

    private void Awake()
    {
        StartCoroutine(Breathing());
    }

    private IEnumerator Breathing() { 
        yield return new WaitForSeconds(m_timeBetweenBreaths);

        if (m_oxygenCurrentLevel == 0) Suffocate();
        m_oxygenCurrentLevel--;

        float newOxygenLevel = m_oxygenAnimator.GetFloat("OxygenLeft");
        newOxygenLevel = -1f * (((float)m_oxygenCurrentLevel / (float)m_oxygenMaxLevel) - 0.001f);
        m_oxygenAnimator.SetFloat("OxygenLeft", newOxygenLevel);
        StartCoroutine(Breathing());
    }

    private void Suffocate() {
        SceneManager.LoadScene("Game Over Scene");
    }
}
