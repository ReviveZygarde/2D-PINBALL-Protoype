/*
 * Copyright (c) 2020 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using UnityEngine.InputSystem;

public class Launcher : MonoBehaviour
{
    /// <summary>
    /// This is a starter asset I found, but I might
    /// have to truncate a LOT of this.
    /// </summary>

    // Touch Listener
    public bool isKeyPress = false;
    // Ready for Launch
    public bool isActive = true;

    public int powerIndex;
    private int original_powerIndex; //This works just like the "predefined" variables in ModeBehavior.
                                     //I think "original" is the better wording in these scenarios.
    private SpringJoint2D springJoint;
    private Rigidbody2D rb;
    private float force = 0f;
    public float maxForce = 90f;

    //New Input System-related
    public gameplayControlsBehavior pl_inputButtonBool;

    void Start()
    {
        springJoint = GetComponent<SpringJoint2D>();
        springJoint.distance = 1f;
        rb = GetComponent<Rigidbody2D>();
        original_powerIndex = powerIndex;
    }

    void Update()
    {
        if (isActive)
        {
            if (pl_inputButtonBool.rfIsHeld == true)
            {
                isKeyPress = true;
            }

            if (pl_inputButtonBool.rfIsHeld == false)
            {
                isKeyPress = false;
            }

            // on Button release 
            if (isKeyPress == false)
            {
                // #1
                force = powerIndex * maxForce;
            }
        }
        
    }

    private void FixedUpdate()
    {
        // When force is not 0
        if (force != 0)
        {
            // release springJoint and power up
            springJoint.distance = 1f;
            rb.AddForce(Vector3.up * force);
            force = 0;
        }

        // When the plunger is held down
        if (isKeyPress)
        {
            // retract the springJoint distance and reduce the power
            powerIndex = original_powerIndex;
            springJoint.distance = .8f;
            rb.AddForce(Vector3.down * 400);
        }
        if (!isKeyPress)
        {
            powerIndex = 0;
        }
    }
}
