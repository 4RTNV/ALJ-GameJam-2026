using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GlobalConverters
{
#if UNITY_EDITOR
    [InitializeOnLoadMethod]
#endif
    [RuntimeInitializeOnLoadMethod]
    public static void Register()
    {
        var group = new ConverterGroup("StringToVisibility");
        group.AddConverter((ref string str) => { return string.IsNullOrEmpty(str) ? new StyleEnum<Visibility>(Visibility.Hidden) 
            : new StyleEnum<Visibility>(Visibility.Visible); });
        ConverterGroups.RegisterConverterGroup(group);
    }
}
