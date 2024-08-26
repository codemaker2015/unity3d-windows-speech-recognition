using UnityEngine;
using UnityEngine.Windows.Speech;

public class DictationController : MonoBehaviour
{
    private DictationRecognizer dictationRecognizer;

    // Define an event for recognized commands
    public delegate void OnSpeechCommand(string command);
    public static event OnSpeechCommand CommandRecognized;

    void Start()
    {
        // Initialize DictationRecognizer
        dictationRecognizer = new DictationRecognizer();

        // Subscribe to events
        dictationRecognizer.DictationResult += OnDictationResult;
        dictationRecognizer.DictationHypothesis += OnDictationHypothesis;
        dictationRecognizer.DictationComplete += OnDictationComplete;
        dictationRecognizer.DictationError += OnDictationError;

        // Start the Dictation Recognizer
        dictationRecognizer.Start();
    }

    private void OnDictationResult(string text, ConfidenceLevel confidence)
    {
        Debug.Log("Dictation result: " + text);

        // Convert text to lowercase for easier comparison
        text = text.ToLower();

        // Trigger the command event if speech is recognized
        if (CommandRecognized != null)
        {
            CommandRecognized(text);  // Trigger the event
        }
    }

    private void OnDictationHypothesis(string text)
    {
        Debug.Log("Dictation hypothesis: " + text);
    }

    private void OnDictationComplete(DictationCompletionCause cause)
    {
        Debug.Log("Dictation completed: " + cause);
    }

    private void OnDictationError(string error, int hresult)
    {
        Debug.LogError("Dictation error: " + error + " - HResult: " + hresult);
    }

    private void OnDestroy()
    {
        // Stop the recognizer when the object is destroyed
        if (dictationRecognizer != null && dictationRecognizer.Status == SpeechSystemStatus.Running)
        {
            dictationRecognizer.Stop();
        }

        // Unsubscribe from dictation events
        dictationRecognizer.DictationResult -= OnDictationResult;
        dictationRecognizer.DictationHypothesis -= OnDictationHypothesis;
        dictationRecognizer.DictationComplete -= OnDictationComplete;
        dictationRecognizer.DictationError -= OnDictationError;
    }
}
