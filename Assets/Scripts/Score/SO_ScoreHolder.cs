using UnityEngine;

namespace SuareDemo
{
    [CreateAssetMenu(menuName = "Red Panda/Score Holder")]
    public class SO_ScoreHolder : ScriptableObject
    {
        [field: SerializeField] public int Score { get; set; }
    }
}