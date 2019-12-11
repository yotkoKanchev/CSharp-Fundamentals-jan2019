using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldNames)
    {
        var sb = new StringBuilder();

        var type = Type.GetType(className);
        var fields = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        var instance = Activator.CreateInstance(type);

        sb.AppendLine($"Class under investigation: {className}");

        foreach (var field in fields)
        {
            var currentFieldName = field.Name;
            if (fieldNames.Contains(currentFieldName))
            {
                sb.AppendLine($"{currentFieldName} = {field.GetValue(instance)}");
            }
        }

        return sb.ToString().TrimEnd();
    }
}
