using UnityEngine;

/// <summary>
/// YOU DO NOT HAVE TO LOOK AT THIS
/// But in case you still do
/// </summary>

public static class GoodEnough
{

    // The classic math expression is (a < x < b) 
    // (second - range/2) < first < (second + range/2)
    public static bool Mol(float first, float second, float range)
    {
        return (first >= second - (range / 2) && first <= second + (range / 2));
    }

    // The classic math expression is (a < x < b) 
    // (second - range/2) < first < (second + range/2)
    public static bool Mol(Vector3 first, Vector3 second, float range)
    {
        return ((first.x >= second.x - (range / 2) && first.x <= second.x + (range / 2)) 
            && (first.y >= second.y - (range / 2) && first.y <= second.y + (range / 2)) 
            && (first.z >= second.z - (range / 2) && first.z <= second.z + (range / 2)));
    }
    
	public static float Lerp(float value, float to, float step) {
		if (value == to) return value;
		if (value > to) return ((value - step) < to? to : value - step);
		else return (value + step) > to ? to : value + step;
	}
	
	public static float Dist(Vector3 value, Vector3 to) {
		return (to - value).magnitude;
	}
	
	public static float GetDist(this Vector3 value, Vector3 to) {
		return (to - value).magnitude;
	}
	
	public static bool IsCloseEnough (Vector3 value, Vector3 to, float range) {
		return (to - value).magnitude <= range;
	}
	
	public static bool IsCloseEnoughTo (this Vector3 value, Vector3 to, float range) {
		return (to - value).magnitude <= range;
	}
}
