using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField]
    protected int _weightThreshold;

    protected abstract bool CheckIfWeightCanPass(IWeightedItem weightedObject);
}
