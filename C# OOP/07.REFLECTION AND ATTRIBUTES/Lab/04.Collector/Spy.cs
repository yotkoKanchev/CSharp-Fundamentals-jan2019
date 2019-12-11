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

    public string RevealPrivateMethods(string className)
    {
        var sb = new StringBuilder();
        var type = Type.GetType(className);
        var privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        var sb = new StringBuilder();

        var type = Type.GetType(className);
        var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var method in methods)
        {
            if (method.Name.StartsWith("get"))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
        }

        foreach (var method in methods)
        {
            if (method.Name.StartsWith("set"))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
        }
        return sb.ToString().TrimEnd();
    }
}
