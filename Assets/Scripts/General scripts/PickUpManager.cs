using System.Collections.Generic;
using System.Diagnostics;

public static class PickupManager
{
    private static HashSet<string> collected = new HashSet<string>();

    public static void Collect(string id)
    {
        collected.Add(id);
    }

    public static bool IsCollected(string id)
    {
        return collected.Contains(id);
    }
}
