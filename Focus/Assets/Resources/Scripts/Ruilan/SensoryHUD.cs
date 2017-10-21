using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Sensory
{
    public ScoreSensory score;
    public StackSensory[] stack;
}

public class SensoryHUD : MonoBehaviour {

    [SerializeField] private Sensory adrenaline;
    [SerializeField] private Sensory feel;
    [SerializeField] private Sensory hearing;
    [SerializeField] private Sensory sould;

    public static SensoryHUD instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(float pointer, TypeBubbleSensory typeBubble)
    {
        Sensory sensory = new Sensory();
        switch (typeBubble)
        {
            case TypeBubbleSensory.Adrenaline:
                sensory = adrenaline;
                break;
            case TypeBubbleSensory.Feel:
                sensory = feel;
                break;
            case TypeBubbleSensory.Hearing:
                sensory = hearing;
                break;
            case TypeBubbleSensory.Sould:
                sensory = sould;
                break;
            default:
                Debug.LogError("Not Implement Bubble type");
                break;
        }

        float totalpointer = sensory.score.ScoreCurrent + pointer;
        if (totalpointer >= sensory.score.maxScore)
        {
            float pointerOverflow = totalpointer - sensory.score.maxScore;

            sensory.score.AddPointer((pointer - pointerOverflow));
            sensory.score.ClearScore();
            ActiveNextStack(sensory);

            if (pointerOverflow > 0)
                AddScore(pointerOverflow, typeBubble);
        }
        else if (pointer > 0)
            sensory.score.AddPointer(pointer);
    }

    private void ActiveNextStack(Sensory sensory)
    {
        for (int i = 0; i < sensory.stack.Length; i++)
        {
            if (!sensory.stack[i].IsActived)
            {
                sensory.stack[i].ActiveStack();

                Debug.Log(i);
                if (i == 2)
                    ActiveNextStack(sould);
                break;
            }
        }
    }
}
