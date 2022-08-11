// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.Diagnostics;

/// <summary>
///     Enum used by <see cref="CommandEventData" />, and subclasses to indicate the
///     source of the <see cref="DbCommand" /> being used to execute the command.
/// </summary>
/// <remarks>
///     See <see href="https://aka.ms/efcore-docs-diagnostics">Logging, events, and diagnostics</see> for more information and examples.
/// </remarks>
public enum CommandSource
{
    /// <summary>
    ///     The command was generated from an unknown source. This usually indicates a database provider-generated command.
    /// </summary>
    Unknown,

    /// <summary>
    ///     The command was generated from a LINQ query on a <see cref="DbSet{TEntity}"/>.
    /// </summary>
    LinqQuery,

    /// <summary>
    ///     The command was generated from a call to <see cref="DbContext.SaveChanges()"/> or
    ///     <see cref="DbContext.SaveChangesAsync(CancellationToken)"/>
    /// </summary>
    SaveChanges,

    /// <summary>
    ///     The command was generated by EF Core Migrations.
    /// </summary>
    Migrations,

    /// <summary>
    ///     The command was generated from a call to
    ///     <see cref="RelationalQueryableExtensions.FromSql{TEntity}"/>,
    ///     <see cref="RelationalQueryableExtensions.FromSqlRaw{TEntity}"/> or
    ///     <see cref="RelationalQueryableExtensions.FromSqlInterpolated{TEntity}"/> 
    /// </summary>
    FromSqlQuery,

    /// <summary>
    ///     The command was generated from a call to
    ///     <see cref="RelationalDatabaseFacadeExtensions.ExecuteSqlRaw(DatabaseFacade,string,object[])"/>,
    ///     <see cref="RelationalDatabaseFacadeExtensions.ExecuteSqlRawAsync(DatabaseFacade,string,CancellationToken)"/>,
    ///     <see cref="RelationalDatabaseFacadeExtensions.ExecuteSql"/>,
    ///     <see cref="RelationalDatabaseFacadeExtensions.ExecuteSqlAsync"/>,
    ///     <see cref="RelationalDatabaseFacadeExtensions.ExecuteSqlInterpolated"/>,
    ///     or <see cref="RelationalDatabaseFacadeExtensions.ExecuteSqlInterpolatedAsync"/>.
    /// </summary>
    ExecuteSqlRaw,

    /// <summary>
    ///     The command was generated by a <see cref="ValueGenerator"/>.
    /// </summary>
    ValueGenerator,

    /// <summary>
    ///     The command was generated as part of scaffolding (reverse-engineering) from an existing database.
    /// </summary>
    Scaffolding,

    /// <summary>
    ///     The command was generated as part of a bulk update.
    /// </summary>
    [Obsolete("Use ExecuteDelete or ExecuteUpdate instead.")]
    BulkUpdate,

    /// <summary>
    ///     The command was generated as part of an 'ExecuteDelete' operation.
    /// </summary>
    ExecuteDelete = 9,

    /// <summary>
    ///     The command was generated as part of an 'ExecuteUpdate' operation.
    /// </summary>
    ExecuteUpdate,
}
