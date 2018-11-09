using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.LoadinIndicator
{
    public interface IHudService
    {
        /// <summary>
        /// Shows hud in the secreen
        /// </summary>
        /// <param name="ProgressText">Set progress</param>
        void ShowHud(string ProgressText = "Loading...");

        /// <summary>
        /// Hides hud.
        /// </summary>
        void HideHud();

        /// <summary>
        /// Set text.
        /// </summary>
        /// <param name="Text">Set text to hub.</param>
        void SetText(string Text);

        /// <summary>
        /// Set progress.
        /// </summary>
        /// <param name="Progress">Set progress.</param>
        /// <param name="ProgressText">Set Text.</param>
        void SetProgress(double Progress, string ProgressText = "");

    }
}
