﻿using System.IO;
using System.Text.Json;

namespace ShopOganicAPI
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? Activator.CreateInstance<T>() : JsonSerializer.Deserialize<T>(value);
        }
    }
}
