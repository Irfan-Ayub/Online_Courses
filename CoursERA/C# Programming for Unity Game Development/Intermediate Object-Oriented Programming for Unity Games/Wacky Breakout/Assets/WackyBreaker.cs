using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WackyBreaker : MonoBehaviour {

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // pause game on escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

}
