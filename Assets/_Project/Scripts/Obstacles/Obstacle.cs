using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    protected int _weightThreshold;

    protected abstract bool CheckIfWeightCanPass(IWeightedObject weightedObject);
}
