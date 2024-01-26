using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public static partial class Extensions
{
    public static Vector3 GetInDirection(this Vector3 location, Direction direction, float distance = 1)
    {
        switch (direction)
        {

            case Direction.Up:
                return new Vector3(location.x, location.y + distance, location.z);
            case Direction.Right:
                return new Vector3(location.x + distance, location.y, location.z);
            case Direction.Down:
                return new Vector3(location.x, location.y - distance, location.z);
            case Direction.Left:
                return new Vector3(location.x - distance, location.y, location.z);             
            case Direction.None:
            default:
                return location;
        }
    }
}

