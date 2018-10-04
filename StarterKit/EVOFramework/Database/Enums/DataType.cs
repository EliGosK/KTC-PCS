namespace EVOFramework.Database
{
    public enum DataType { 
        /// <summary>
        /// None specified.
        /// </summary>
        Default = -1,
        /// <summary>
        /// SQLServer is Bit
        /// Oracle is Byte
        /// OleDb is Boolean
        /// </summary>
        Boolean = 0,

        /// <summary>
        /// SQLServer is Tiny
        /// Oracle is Byte
        /// OleDb is UnsignedTinyInt
        /// </summary>
        Byte,

        /// <summary>
        /// SQLServer is VarBinary
        /// Oracle is Raw
        /// OleDb is VarBinary
        /// </summary>
        Binary,

        /// <summary>
        /// SQLServer is DateTime
        /// Oracle is DateTime
        /// OleDb is DBTimeStamp
        /// </summary>
        DateTime,

        /// <summary>
        /// SQLServer is Int64 or BigInt
        /// Oracle is Number
        /// OleDb is BigInt        
        /// </summary>
        Number,

        /// <summary>
        /// SQLServer is Decimal
        /// Oracle is Number
        /// OleDb is Decimal
        /// </summary>
        Decimal,

        /// <summary>
        /// SQLServer is Float
        /// Oracle is Double
        /// OleDb is Double
        /// </summary>
        Double,

        /// <summary>
        /// SQLServer is Real
        /// Oracle is Real
        /// OleDb is Single
        /// </summary>
        Single,

        /// <summary>
        /// SQLServer is UniqueIdentifier
        /// Oracle is Raw
        /// OleDb is Guid
        /// </summary>
        Guid,

        /// <summary>
        /// SQLServer is not supported.
        /// Oracle is Raw
        /// OleDb is not supported.
        /// </summary>
        Raw,

        /// <summary>
        /// SQLServer is SmallInt
        /// Oracle is Int16
        /// OleDb is SmallInt
        /// </summary>
        Int16,

        /// <summary>
        /// SQLServer is Int
        /// Oracle is Int32
        /// OleDb is Int
        /// </summary>
        Int32,

        /// <summary>
        /// SQLServer is BigInt
        /// Oracle is Number
        /// OleDb is BigInt
        /// </summary>
        Int64,

        /// <summary>
        /// SQLServer is Variant
        /// Oracle is Blob
        /// OleDb is Variant
        /// </summary>
        Object,

        /// <summary>
        /// Ansi string fixed length
        /// SQLServer is Char
        /// Oracle is Char
        /// OleDb is Char
        /// </summary>
        Char,

        /// <summary>
        /// Ansi string
        /// SQLServer is VarChar
        /// Oracle is VarChar
        /// OleDb is VarChar
        /// </summary>
        VarChar,

        /// <summary>
        /// Unicode string fixed length
        /// SQLServer is NChar
        /// Oracle is NChar
        /// OleDb is WChar
        /// </summary>
        NChar,

        /// <summary>
        /// Unicode string
        /// SQLServer is NVarChar
        /// Oracle is NVarChar
        /// OleDb is VarWChar
        /// </summary>
        NVarChar,

        /// <summary>
        /// SQLServer is not supported.
        /// Oracle is Cursor
        /// OleDb is not supported.
        /// </summary>
        Cursor
    }
}
