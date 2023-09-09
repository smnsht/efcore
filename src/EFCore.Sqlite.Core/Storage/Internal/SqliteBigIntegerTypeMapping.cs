// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal.Json;
using Microsoft.EntityFrameworkCore.Storage.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class SqliteBigIntegerTypeMapping : RelationalTypeMapping
{
    public static readonly int INT128_COL_SIZE = Int128.MinValue.ToString().Length;

    protected SqliteBigIntegerTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    public SqliteBigIntegerTypeMapping(
        string storeType,
        Type clrType,
        DbType? dbType = null,
        bool unicode = false,
        int? size = null,
        bool fixedLength = false,
        int? precision = null,
        int? scale = null,
        JsonValueReaderWriter? jsonValueReaderWriter = null)
            : base(storeType, clrType, dbType, unicode, size, fixedLength, precision, scale, jsonValueReaderWriter)
    {
    }

    public SqliteBigIntegerTypeMapping(Type t): this(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(
                    t,
                    jsonValueReaderWriter: SqliteJsonDecimalReaderWriter.Instance),
                "TEXT",
                // TODO: figure out how to deal field size for BigInteger
                fixedLength: true,
                size: t == typeof(BigInteger) ? 2000 : INT128_COL_SIZE,
                dbType: System.Data.DbType.String))
    {        
        if(t == null)
        {
            throw new ArgumentNullException(nameof(t));
        }
            
        if (t != typeof(BigInteger)
            && t != typeof(UInt128)
            && t != typeof(Int128))
        {
            throw new ArgumentOutOfRangeException(nameof(t));
        }
    }


    /// <inheritdoc/>
    protected override SqliteBigIntegerTypeMapping Clone(RelationalTypeMappingParameters parameters)
        => new SqliteBigIntegerTypeMapping(parameters);

    protected override string SqlLiteralFormatString
        => "'" + base.SqlLiteralFormatString + "'";
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
