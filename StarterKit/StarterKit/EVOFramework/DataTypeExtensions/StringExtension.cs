using System;
namespace EVOFramework
{
    /// <summary>
    /// Extension class
    /// </summary>
    public static class Extensions
    {
        #region To NZ-DataType
        /// <summary>
        /// Convert to NZString type.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static NZString ToNZString(this string s) {
            return new NZString(null, s, string.Empty);
        }
        /// <summary>
        /// Convert to NZInt type.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static NZInt ToNZInt(this short number)
        {
            return new NZInt(null, number, 0);
        }
        /// <summary>
        /// Convert to NZInt type.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static NZInt ToNZInt(this int number) {
            return new NZInt(null, number, 0);
        }
        /// <summary>
        /// Convert to NZLong type.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static NZLong ToNZLong(this long number) {
            return new NZLong(null, number, 0);
        }
        /// <summary>
        /// Convert to NZDecimal type.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static NZDecimal ToNZDecimal(this float number) {
            return new NZDecimal(null, number, 0);
        }
        /// <summary>
        /// Convert to NZDecimal type.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static NZDecimal ToNZDecimal(this double number) {
            return new NZDecimal(null, number, 0);
        }
        /// <summary>
        /// Convert to NZDecimal type.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static NZDecimal ToNZDecimal(this decimal number) {
            return new NZDecimal(null, number, 0);
        }
        /// <summary>
        /// Convert to NZDateTime type.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static NZDateTime ToNZDateTime(this DateTime dateTime) {
            return new NZDateTime(null, dateTime, DBNull.Value);
        }
        #endregion
    }    
}
