using UnityEngine;
using AYellowpaper.SerializedCollections;

namespace TapTD
{
    [CreateAssetMenu(fileName = "newResourcesConfig")]
    public class ResourcesConfig : ScriptableObject
    {
        public SerializedDictionary<Enums.ResourceTypes, Sprite> Resources;
    }
}