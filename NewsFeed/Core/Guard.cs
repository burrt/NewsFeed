using System;

namespace NewsFeed.Core
{
    /// <summary>
    /// Guard class for checking conditions are met.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Check if the object is not null.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <param name="name">The object name.</param>
        public static void IsNotNull(object o, string name)
        {
            if (o == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
