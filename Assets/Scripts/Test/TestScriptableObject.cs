using UnityEngine;

[CreateAssetMenu(fileName = "TestScriptableObject", menuName = "CreatTestScriptableObject", order = 0)]
public class TestScriptableObject : ScriptableObject
{
    public int type;
    public int dmg;
    public int speed;
    public int attack;
}