#region Header

// 
//        LifeUtils - LifeUtils - IConverter.cs
//                  24.10.2018 01:48

#endregion

namespace LifeUtils
{
    /// <summary>
    ///     Converter that converts some type to another type.
    /// </summary>
    /// <typeparam name="TFrom">The type from.</typeparam>
    /// <typeparam name="TTo">The type to convert.</typeparam>
    public interface IConverter<in TFrom, out TTo>
    {
        /// <summary>
        ///     Converts a type to another type.
        /// </summary>
        /// <param name="from">Type to convert.</param>
        /// <returns>The converted value.</returns>
        TTo Convert(TFrom from);
    }
}