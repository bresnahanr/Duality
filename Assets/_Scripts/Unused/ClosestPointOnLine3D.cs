using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestPointOnLine3D
{
	public static Vector3 FindClosestPointOnLine(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
	{
		float lineVectorX = lineEnd.x - lineStart.x;
		float lineVectorY = lineEnd.y - lineStart.y;
		float lineVectorZ = lineEnd.z - lineStart.z;
		float lineLengthSquared = (lineVectorX * lineVectorX) + (lineVectorY * lineVectorY) + (lineVectorZ * lineVectorZ);

		// If line has zero length, return start point as the closest point
		if (lineLengthSquared == 0)
			return lineStart;

		// Calculate the vector from the line start to the point
/*		float startToPointVectorX = point.x - lineStart.x;
		float startToPointVectorY = point.y - lineStart.y;
		float startToPointVectorZ = point.z - lineStart.z;*/

		// Calculate the dot product between the line vector and the start-to-point vector
		//float dotProduct = (startToPointVectorX * lineVectorX + startToPointVectorY * lineVectorY + startToPointVectorZ * lineVectorZ) / lineLengthSquared;
		float dotProduct = Vector3.Dot(lineStart, point) / lineLengthSquared;

		if( dotProduct <= 0 )
			return lineStart;

		if( dotProduct >= 1 )
			return lineEnd;


		// Calculate the closest point on the line by projecting the start-to-point vector onto the line vector
		float closestPointX = lineStart.x + dotProduct * lineVectorX;
		float closestPointY = lineStart.y + dotProduct * lineVectorY;
		float closestPointZ = lineStart.z + dotProduct * lineVectorZ;

		return new Vector3(closestPointX, closestPointY, closestPointZ);

	}
}
