#if UNITY_EDITOR
using UnityEditor;

namespace _Source.Editor
{
    public class ScriptableObjectContextMenu : UnityEditor.Editor
    {
        [MenuItem("CONTEXT/ScriptableObject/Show in Project")]
        private static void ShowInProject(MenuCommand command)
        {
            EditorGUIUtility.PingObject(command.context);
        }
    }
}
#endif