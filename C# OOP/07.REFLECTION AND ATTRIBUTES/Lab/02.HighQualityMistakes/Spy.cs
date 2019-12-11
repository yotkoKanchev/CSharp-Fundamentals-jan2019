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

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();

        var type = Type.GetType(className);
        var instance = Activator.CreateInstance(type);

        var fields = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);
        var publicMethods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);
        var privateMethods = type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in privateMethods)
        {
            if (method.Name.Contains("get"))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
        }

        foreach (var method in publicMethods)
        {
            if (method.Name.Contains("set"))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
        }

        return sb.ToString().TrimEnd();
    }
}
