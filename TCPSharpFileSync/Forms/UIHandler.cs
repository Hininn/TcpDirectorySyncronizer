﻿using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormAnimation;

namespace TCPSharpFileSync
{
    /// <summary>
    /// Class that represents all the UI working, including progress that's shown to user.
    /// </summary>
    public static class UIHandler
    {
        /// <summary>
        /// Delegate that invokes writing given text to a RichTextBox with specific color.
        /// </summary>
        public static Action<string, Color> ActionLabelSetText;
        /// <summary>
        /// Delegate that made to set the ProgressBar max value.
        /// </summary>
        public static Action<int> SetProgressBarMax;
        /// <summary>
        /// Delegate that made to increment ProgressBar value by some value.
        /// </summary>
        public static Action<int> IncrementProgressBar;
        /// <summary>
        /// Delegate that made to set ProgressBar value to 0.
        /// </summary>
        public static Action ResetProgressBar;

        public static Action<bool> ProgressBarVisibility;

        public static Animator3D colorfulBarAnimation;

        private static Color colorfulBarInitialColor;
        private static Panel colorfulBar;

        public static Panel ColorfulBar
        {
            get 
            {
                return colorfulBar;
            }
            set 
            {
                colorfulBar = value;
                colorfulBarInitialColor = colorfulBar.BackColor;
            } 
        }

        static bool visible = false;

        /// <summary>
        /// Function that invokes writing to the RichTextBox delegate with standart text color.
        /// </summary>
        /// <param name="s">Text that has to be written.</param>
        public static void WriteLog(string s)
        {
            ActionLabelSetText.Invoke(s, SystemColors.WindowText);
            Application.DoEvents();
        }

        /// <summary>
        /// Function that invokes writing to the RichTextBox delegate with specific text color.
        /// </summary>
        /// <param name="s">Text that has to be written.</param>
        /// <param name="c">Color of the given text.</param>
        public static void WriteLog(string s, Color c)
        {
            ActionLabelSetText.Invoke(s, c);
            Application.DoEvents();
        }

        /// <summary>
        /// Function that invokes delegate that sets ProgressBat max value.
        /// </summary>
        /// <param name="max">Value that has to be set.</param>
        public static void SetProgressBarMaxValue(int max)
        {
            SetProgressBarMax.Invoke(max);
        }

        /// <summary>
        /// Function that invokes delegate that increments ProgressBar value by 1.
        /// </summary>
        public static void IncrementProgressBarValue(int value = 1)
        {
            IncrementProgressBar.Invoke(value);
        }

        /// <summary>
        /// Function that invokes delegate that sets ProgressBar value to 0.
        /// </summary>
        public static void ResetProgressBarValue()
        {
            ResetProgressBar.Invoke();
        }

        public static void ToggleProgressBarVisibility(bool tgl)
        {
            visible = tgl;
            ResetProgressBarValue();
            ProgressBarVisibility.Invoke(visible);
        }

        public static void PlayColorfulBarAnimation(bool repeatFlag = false) 
        {
            colorfulBarAnimation.Repeat = true;
            colorfulBarAnimation.Play(colorfulBar, "BackColor");
        }

        public static void StopColorfulBarAnimation()
        {
            colorfulBarAnimation.Stop();
            colorfulBar.BackColor = colorfulBarInitialColor;
        }
    }
}