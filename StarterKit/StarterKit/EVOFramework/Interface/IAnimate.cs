using System.Drawing;

namespace EVOFramework.Windows.Forms
{
    /// <summary>
    /// Implement this interface to support method animation.
    /// </summary>
    interface IAnimate
    {
        /// <summary>
        /// Flag to indicate that has animating.
        /// </summary>
        bool Animating { get; }

        /// <summary>
        /// Start animation to specificed bound.
        /// </summary>
        /// <param name="location">Target location.</param>
        /// <param name="size">Target size.</param>
        void StartAnimateToBound(Point location, Size size);

        /// <summary>
        /// Start animation to specificed bound.
        /// </summary>
        /// <param name="x">Target x-position.</param>
        /// <param name="y">Target y-position.</param>
        /// <param name="width">Target width.</param>
        /// <param name="height">Target height.</param>
        void StartAnimateToBound(int x, int y, int width, int height);

        /// <summary>
        /// Stop animation immediatly.
        /// </summary>
        void StopAnimate();
    }
}
