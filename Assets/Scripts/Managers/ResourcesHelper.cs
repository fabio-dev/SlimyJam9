using UnityEngine;

public static class ResourcesHelper
{
    public static Sprite GetExploSprite(DestinationType destinationType)
    {
        return Resources.Load<Sprite>($"Sprites/Exploration/{destinationType}");
    }
}