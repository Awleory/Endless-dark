
using System;
using System.Collections.Generic;

public static class IdController
{
    private static readonly List<string> _ids = new();

    public static void AddId(string id)
    {
        if (IsIdCorrect(id, out string description))
        {
            _ids.Add(id);
        }
        else
        {
            throw new Exception($"Id {id} is not correct for using! {description}");
        }
    }

    public static void RemoveId(string id)
    {
        if (_ids.Contains(id))
            _ids.Remove(id);
    }

    private static bool IsIdCorrect(string id, out string description)
    {
        description = null;

        if (_ids.Contains(id)) 
        {
            description = $"Id {id} already in use.";
            return false;
        }
        else if (id == null || id.Length == 0)
        {
            description = $"The value is not allowed.";
            return false;
        }

        return true;
    }
}
