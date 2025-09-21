using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Difficult", menuName = "Difficult/DifficultData")]
public class DifficultData : ScriptableObject
{
    public string difficult;

    //public List<ObjectPool> enemyPhase1 = new();
    //public List<ObjectPool> enemyPhase2 = new();
    //public List<ObjectPool> enemyPhase3 = new();
    //public List<ObjectPool> enemyPhase4 = new();

    public float phase1Time = 0.75f;
    public float phase2Time = 0.5f;
    public float phase3Time = .2f;
    public float phase4Time;

    public int phase1EnemyCount;
    public int phase2EnemyCount;
    public int phase3EnemyCount;
    public int phase4EnemyCount;

    public int timeCountdown;
}
