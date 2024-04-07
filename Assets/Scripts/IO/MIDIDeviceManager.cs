using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.Events;
using System;

// NoteCallback.cs - This script shows how to define a callback to get notified
// on MIDI note-on/off events.

[System.Serializable]
public class MIDIAverageEvent : UnityEvent<float>
{
}


sealed class MIDIDeviceManager : MonoBehaviour
{

    private int noteValue;
    /// <summary>
    /// Int (in frames), the number of sample points to compute into an average.
    /// </summary>
    public int MovingAverageLength = 1000;

    public float Stressed = 70;
    public float Relaxed = 64;

    private int count;
    private float movingAverage;
    private bool hasDevice = false;
    // private bool activeNote = false;

    MIDIAverageEvent m_MIDIAverageEvent;

    public static Action<float> OnMIDIInputChange;

    void Start()
    {
        if (m_MIDIAverageEvent == null)
            m_MIDIAverageEvent = new MIDIAverageEvent();

        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;
            if (midiDevice != null) hasDevice = true;

            midiDevice.onWillNoteOn += (note, velocity) =>
            {
                // Note that you can't use note.velocity because the state
                // hasn't been updated yet (as this is "will" event). The note
                // object is only useful to specify the target note (note
                // number, channel number, device name, etc.) Use the velocity
                // argument as an input note velocity.
                noteValue = note.noteNumber;
                // activeNote = true;
                // Debug.Log(string.Format(
                //     "Note On #{0} ({1}) vel:{2:0.00} ch:{3} dev:'{4}'",
                //     note.noteNumber,
                //     note.shortDisplayName,
                //     velocity,
                //     (note.device as Minis.MidiDevice)?.channel,
                //     note.device.description.product
                // ));
            };

            // midiDevice.onWillNoteOff += (note) => {
            //     activeNote = false;
            // //     Debug.Log(string.Format(
            // //         "Note Off #{0} ({1}) ch:{2} dev:'{3}'",
            // //         note.noteNumber,
            // //         note.shortDisplayName,
            // //         (note.device as Minis.MidiDevice)?.channel,
            // //         note.device.description.product
            // //     ));
            // };
        };
    }

    void Update()
    {
        if (hasDevice) count++;
        // if (!activeNote) noteValue = 0;

        if (count > MovingAverageLength)
        {
            movingAverage = movingAverage + (noteValue - movingAverage) / (MovingAverageLength + 1);
            Debug.Log("Moving Average: " + movingAverage); // event here
            OnMIDIInputChange.Invoke(movingAverage);
        }
        else
        {
            movingAverage += noteValue;

            // This will calculate ONLY the very first value of the MovingAverage,
            if (count == MovingAverageLength)
            {
                movingAverage = movingAverage / count;
                Debug.Log("Moving Average: " + movingAverage);
                OnMIDIInputChange.Invoke(movingAverage);
            }
        }

        if (movingAverage > Stressed)
        {
            m_MIDIAverageEvent.Invoke(movingAverage);
        }
        if (movingAverage < Relaxed)
        {
            m_MIDIAverageEvent.Invoke(movingAverage);
        }
    }
}