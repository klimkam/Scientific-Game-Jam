using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;

public class Oxygen : MonoBehaviour
{
    [SerializeField]
    Animator m_oxygenAnimator;
    [SerializeField]
    float m_timeBetweenBreaths = 1f;

    //Should match the amount of frames at Oxygen.png
    int m_oxygenCurrentLevel = 111;
    int m_oxygenMaxLevel = 111;
    float m_oxygenConsumptionSpeed = 1f;

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
        MIDIDeviceManager.OnMIDIInputChange += OnConnectedToServer;
    }

    private void OnConnectedToServer(float level)
    {
        m_oxygenConsumptionSpeed = level;

        m_oxygenConsumptionSpeed = Mathf.Clamp(m_oxygenConsumptionSpeed, 50f, 80f);
        m_oxygenConsumptionSpeed -= 75f;
        m_oxygenConsumptionSpeed = (m_oxygenConsumptionSpeed / 15f);
        m_oxygenConsumptionSpeed *= -1;

        Debug.Log("Oxygen Consuption Speed: " + m_oxygenConsumptionSpeed);
    }

    private IEnumerator Breathing() { 
        yield return new WaitForSeconds(m_timeBetweenBreaths);

        if (m_oxygenCurrentLevel <= 0) Suffocate();
        m_oxygenCurrentLevel--;

        float newOxygenLevel = m_oxygenAnimator.GetFloat("OxygenLeft");
        newOxygenLevel = -1f * ((((float)m_oxygenCurrentLevel + m_oxygenConsumptionSpeed * 3) / (float)m_oxygenMaxLevel) - 0.001f);
        newOxygenLevel = Mathf.Clamp((float) newOxygenLevel, -1f, 0.01f);
        m_oxygenAnimator.SetFloat("OxygenLeft", newOxygenLevel);
        StartCoroutine(Breathing());
    }

    private void Suffocate() {
        SceneManager.LoadScene("Game Over Scene");
    }

    public void HowCanWeBreatheWithNoAir() {
        Debug.Log("How Can we breathe with no air");
        OxygenCurrentLevel = m_oxygenMaxLevel;
    }
}
