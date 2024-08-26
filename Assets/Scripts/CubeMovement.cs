using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    void OnEnable()
    {
        // Subscribe to the speech command event
        DictationController.CommandRecognized += OnCommandReceived;
    }

    void OnDisable()
    {
        // Unsubscribe from the event when disabled
        DictationController.CommandRecognized -= OnCommandReceived;
    }

    // This method is triggered when a speech command is recognized
    private void OnCommandReceived(string command)
    {
        if (command.Contains("right"))
        {
            MoveForward();
        }
        else if (command.Contains("left"))
        {
            MoveBackward();
        }
        else if (command.Contains("up"))
        {
            MoveUpward();
        }
        else if (command.Contains("down"))
        {
            MoveDownward();
        }
        else
        {
            Debug.Log("Unrecognized command: " + command);
        }
    }

    // Methods for cube movement
    void MoveForward()
    {
        transform.Translate(Vector3.right * moveSpeed);
        Debug.Log("Moving Forward");
    }

    void MoveBackward()
    {
        transform.Translate(Vector3.left * moveSpeed);
        Debug.Log("Moving Backward");
    }

    void MoveUpward()
    {
        transform.Translate(Vector3.up * moveSpeed);
        Debug.Log("Moving Up");
    }

    void MoveDownward()
    {
        transform.Translate(Vector3.down * moveSpeed);
        Debug.Log("Moving Down");
    }
}
