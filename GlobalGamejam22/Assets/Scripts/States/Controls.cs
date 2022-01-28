using UnityEngine;

[CreateAssetMenu(fileName = "Controls", menuName = "ScriptableObjects/Controls", order = 1)]
public class Controls : ScriptableObject
{
    public KeyCode up = KeyCode.UpArrow;
    public KeyCode down = KeyCode.DownArrow;
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode right = KeyCode.RightArrow;
}
