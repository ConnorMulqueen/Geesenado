using UnityEngine;
using System.Collections;

namespace Helpers
{
    public class Constants
    {

        /**
         * <summary>The types of damage a weapon can do.</summary>
         */
        public enum DamageType
        {
            /** <summary>Damage Over Time</summary>*/
            DOT,
            /** <summary>One hit damage for how ever many points declared</summary>*/
            Static,
            /** <summary>Instant GPA fail ("death")</summary>*/
            Instant
        }
    }
}
