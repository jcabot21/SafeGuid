/// SafeGuid
/// Created by Jorge Cabot.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGuid
{
    /// <summary>
    ///     Wrapper class for Guid, which does not throw exceptions when generating or parsing
    ///     from a string.
    ///     
    ///     Example usage:
    ///     Guid newGuid = new SafeGuid(string);     
    ///     Guid newGuid = SafeGuid.Parse(string);
    /// </summary>
    public class SafeGuid
    {
        #region Variables

        /// <summary>
        ///     Wrapped Guid structure.
        /// </summary>
        private readonly Guid _guid;

        #endregion Variables

        #region Constructors

        /// <summary>
        ///     Default constructor, generates Guid.
        /// </summary>
        public SafeGuid()
        {
            _guid = Guid.NewGuid();
        }

        /// <summary>
        ///     Transforms string representation of Guid into valid Guid. If the transformation
        ///     is not possible an empty Guid will be generated.
        /// </summary>
        /// <param name="guid">String representation of guid.</param>
        public SafeGuid(string guid)
        {
            try
            {
                _guid = new Guid(guid);
            }
            catch
            {
                _guid = Guid.Empty;
            }
        }

        /// <summary>
        ///     Wraps Guid in SafeGuid.
        /// </summary>
        /// <param name="guid">Guid to be wrapped.</param>
        public SafeGuid(Guid guid)
        {
            _guid = guid;
        }

        #endregion Constructors

        #region Overrides

        /// <summary>
        ///     Gets the string representation of the the wrapped Guid.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _guid.ToString();
        }

        /// <summary>
        ///     Compares to make sure that the provided object is equal.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            var guid = obj as SafeGuid;
            return guid == null ? false : this.Equals(guid);
        }

        /// <summary>
        ///     Returns the hash code for the wrapped Guid.
        /// </summary>
        /// <returns>Hash code for Guid.</returns>
        public override int GetHashCode()
        {
            return _guid.GetHashCode();
        }

        #endregion Overrides

        #region Private Methods

        /// <summary>
        ///     Delegates equality comparison to wrapped Guid.
        /// </summary>
        /// <param name="guid">SafeGuid to be compared.</param>
        /// <returns>True if equal, otherwise false.</returns>
        private bool Equals(SafeGuid guid)
        {
            return _guid.Equals(guid._guid);
        }

        #endregion Private Methods

        #region Operators

        /// <summary>
        ///     Implicitly convert a SafeGuid to a standard Guid.
        /// </summary>
        /// <param name="guid">SafeGuid to be converted.</param>
        /// <returns>Valid Guid.</returns>
        public static implicit operator Guid(SafeGuid guid)
        {
            return guid._guid;
        }

        /// <summary>
        ///     Implicitly convert a standard Guid into a SafeGuid.
        /// </summary>
        /// <param name="guid">Guid which will be wrapped.</param>
        /// <returns>SafeGuid object.</returns>
        public static implicit operator SafeGuid(Guid guid)
        {
            return new SafeGuid(guid);
        }

        #endregion Operators

        #region Public Statics

        /// <summary>
        ///     Static helper method which may be used to parse a string into
        ///     a valid Guid and does not throw exceptions.
        /// </summary>
        /// <param name="guid">String representation of Guid.</param>
        /// <returns>A valid Guid if possible, otherwise returns an empty Guid.</returns>
        public static Guid Parse(string guid)
        {
            return new SafeGuid(guid);
        }

        #endregion Public Statics
    }
}
