using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraFieldOfView {

	public static float GetFieldOfView(int columnsCount)
    {
        switch (columnsCount)
        {
            case 3:
                return 4;
            case 4:
                return 6;
            case 5:
                return 8;
            case 6:
                return 10;
            case 7:
                return 12;
            case 8:
                return 14;
            case 9:
                return 15;
            case 10:
                return 16;
            default:
                return 0;
        }
    }
}
