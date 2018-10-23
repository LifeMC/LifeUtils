#region Header

// 
//        LifeUtils - LifeUtils - ICloseable.cs
//                  23.10.2018 09:12

#endregion

namespace LifeUtils
{
    /// <summary>
    ///     Represents a closeable type.
    /// </summary>
    public interface ICloseable
    {
        /// <summary>
        ///     Closes this object.
        /// </summary>
        void Close();
    }

    /// <summary>
    ///     Represents a closeable type that returns a value after closing.
    /// </summary>
    /// <typeparam name="T">The returned values type.</typeparam>
    public interface ICloseable<out T>
    {
        /// <summary>
        ///     Closes this object.
        /// </summary>
        /// <returns>The result of the termination.</returns>
        T Close();
    }
}