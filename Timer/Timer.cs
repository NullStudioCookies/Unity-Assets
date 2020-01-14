using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is a simple timer script witch can either 
/// count up or count down. The script will allow for reseting,
/// pausing and unpausing the timer. The timer is displayed on
/// a UI text object.
/// </summary>

enum TimerFunction { CountingUp, CountingDown}
public class Timer : MonoBehaviour {
    [SerializeField] bool TimerIsPaused = true;

    [Header("Timer Properties")]
    [Space(10)]
    [SerializeField] TimerFunction Function;
    [SerializeField] Text TimerText;

    [Space(10)]
    [ConditionalEnumHide("Function", (int)TimerFunction.CountingDown)][SerializeField] int TotalTime;

    float CurrentTime;
    string Minutes, Seconds;

    // Start is called before the first frame update
    void Start() {
        ResetTimer();
    }

    // Update is called once per frame
    void Update() {
        if (!TimerIsPaused) {
            switch (Function) {
                case TimerFunction.CountingUp:
                    CurrentTime += Time.deltaTime;

                    Minutes = ((int)CurrentTime / 60).ToString();
                    Seconds = (CurrentTime % 60).ToString("f2");

                    TimerText.text = Minutes + ":" + Seconds;
                    break;
                case TimerFunction.CountingDown:
                    CurrentTime -= Time.deltaTime;

                    if (CurrentTime <= 0) {
                        CurrentTime = 0;
                    }

                    Minutes = ((int)CurrentTime / 60).ToString();
                    Seconds = (CurrentTime % 60).ToString("f2");

                    TimerText.text = Minutes + ":" + Seconds;
                    break;
            }
        }
    }

    public void ResetTimer() {
        TimerIsPaused = true;
        switch (Function) {
            case TimerFunction.CountingUp:
                CurrentTime = 0;

                Minutes = ((int)CurrentTime / 60).ToString();
                Seconds = (CurrentTime % 60).ToString("f2");

                TimerText.text = Minutes + ":" + Seconds;
                break;
            case TimerFunction.CountingDown:
                CurrentTime = TotalTime;

                Minutes = ((int)CurrentTime / 60).ToString();
                Seconds = (CurrentTime % 60).ToString("f2");

                TimerText.text = Minutes + ":" + Seconds;
                break;
        }
    }

    public void PauseUnpauseTimer() {
        TimerIsPaused = !TimerIsPaused;
    }
}