using UnityEngine;
using System.Collections;

public class Toucher {
	private static bool isTouch = false;
	public static bool CheckTouch()
	{
		if (Application.platform == RuntimePlatform.Android
		    || Application.platform == RuntimePlatform.IPhonePlayer)
		{
			if (Input.touchCount != 0 && Input.GetTouch(0).phase 
			    == TouchPhase.Began)
			{
				isTouch = true;
			
			}
			if (Input.touchCount != 0 && Input.GetTouch(0).phase 
			    == TouchPhase.Ended)
			{
				isTouch = false;
			}
		}
		else
		{
			if (Input.GetMouseButton(0) == true)
			{
				isTouch = true;

			}
			if (Input.GetMouseButtonUp(0) == true)
			{
				isTouch = false;
			}
		}
		return isTouch;
	}

    public static void resetTouch()
    {
        isTouch = false;
    }
}
