using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public enum TimerFunction { CountingUp, CountingDown}
public class Timer : MonoBehaviour
{
    public TimerFunction Function = TimerFunction.CountingUp;
    public Text TimerText = null;
    [ConditionalEnumHide("Function", (int)TimerFunction.CountingDown)]public int AllowedTime = 0;
    public bool TimerIsPaused = true;

    float CurrentTime = 0;
    string Minutes, Seconds;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer(AllowedTime);
    }

    [ExecuteInEditMode]
    void OnValidate() {
        if (AllowedTime < 0) {
            AllowedTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PauseUnpauseTimer();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            ResetTimer(60);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            SwitchTimerFunction(TimerFunction.CountingDown, 60);
        }

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

    public void ResetTimer(int TotalTime) {
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

    public void SwitchTimerFunction(TimerFunction _TimerFunction, int TotalTime = 0) {
        Function = _TimerFunction;

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
}
