using DG.Tweening;
using UnityEngine;
using System;

namespace AppCore
{
    public static class TweenExtensions
    {
        public static bool KillIfActiveOrPlaying(this Tween tween, bool complete = false)
        {
            if (tween.IsActive() && tween.IsPlaying())
            {
                tween.Kill(complete);

                return true;
            }

            return false;
        }

        // TODO Remove this method in future
        [Obsolete("[Obsolete] Replace this method with .KillIfActiveOrPlaying()", true)]
        public static bool KillIfPlaying(this Tween tween, bool complete = false)
        {

            if (tween != null && tween.IsPlaying())
            {
                tween.Kill(complete);

                return true;
            }

            return false;
        }
    }
}