using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IdleRPG
{
    public class LocationSpawner : MonoBehaviour
    {
        [SerializeField] private List<Location> _allLocations;


        public void Spawn(LocationType locationType)
        {
            Location location = _allLocations.FirstOrDefault(l => l.LocationType == locationType);



        }

    }
}