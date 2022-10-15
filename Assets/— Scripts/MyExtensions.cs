using System.Collections.Generic;
using UnityEngine.UIElements;

public static class MyExtensions
{
    public static VisualElement AddClasses(this VisualElement ve, params string[] classes)
    {
        foreach (var classItem in classes)
        {
            ve.AddToClassList(classItem);
        }
        return ve;
    }
}
