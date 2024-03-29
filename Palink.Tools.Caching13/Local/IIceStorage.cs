﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Palink.Tools.Caching13.Local;

/// <summary>
/// Interface for a IceStorage of cache
/// </summary>
public interface IIceStorage
{
    /// <summary>
    /// Enable / Disable auto expiring of items in the IceStorage
    /// </summary>
    bool AutoExpire { get; set; }

    /// <summary>
    /// Add an item to the IceStorage
    /// </summary>
    /// <typeparam name="T">Type of item</typeparam>
    /// <param name="key">Key to use</param>
    /// <param name="data">Data to store of type T</param>
    /// <param name="expireIn">How long in the future the item should expire</param>
    /// <param name="eTag">eTag to use if needed</param>
    /// <param name="jsonSerializationSettings">Specific json serialization to use</param>
    void Add<T>(string key, T data, TimeSpan expireIn, string? eTag = null,
        JsonSerializerSettings? jsonSerializationSettings = null);

    /// <summary>
    /// Empty a set of keys
    /// </summary>
    /// <param name="key">Keys to empty</param>
    void Empty(params string[] key);

    /// <summary>
    /// Empty all items from the IceStorage
    /// </summary>
    void EmptyAll();

    /// <summary>
    /// Empty only expired items from the IceStorage
    /// </summary>
    void EmptyExpired();

    /// <summary>
    /// Checks to see if a key exists in the IceStorage
    /// </summary>
    /// <param name="key">Key to check</param>
    /// <returns>True if the key exists, else false</returns>
    bool Exists(string key);

    /// <summary>
    /// Get keys with specified state
    /// </summary>
    /// <param name="state">State to get: Multiple with flags: CacheState.Active | CacheState.Expired</param>
    /// <returns>The keys</returns>
    IEnumerable<string> GetKeys(CacheState state = CacheState.Active);

    /// <summary>
    /// Get keys with specified eTag
    /// </summary>
    /// <param name="eTag">eTag name</param>
    /// <param name="state">State to get: Multiple with flags: CacheState.Active | CacheState.Expired</param>
    /// <returns>The keys</returns>
    IEnumerable<string> GetKeys(string? eTag, CacheState state = CacheState.Active);

    /// <summary>
    /// Get an object for the key
    /// </summary>
    /// <typeparam name="T">Type of object to get</typeparam>
    /// <param name="key">Key to use</param>
    /// <param name="jsonSettings">json serialization settings to use.</param>
    /// <returns>The object back if it exists, else null</returns>
    /// <remarks>
    /// When AutoExpire is set to true, Get<T> will return NULL if the item is expired</T>
    /// </remarks>
    T? Get<T>(string key, JsonSerializerSettings? jsonSettings = null);

    /// <summary>
    /// Get the eTag for a key
    /// </summary>
    /// <param name="key">Key to use</param>
    /// <returns>eTag for key, else null</returns>
    string? GetETag(string key);

    /// <summary>
    /// Checks if key is expired
    /// </summary>
    /// <param name="key">The key to check</param>
    /// <returns>True if expired, else false</returns>
    bool IsExpired(string key);

    /// <summary>
    /// Gets the expiration date for a key
    /// </summary>
    /// <param name="key">The key to check</param>
    /// <returns>The date if exists, else null</returns>
    DateTime? GetExpiration(string key);
}