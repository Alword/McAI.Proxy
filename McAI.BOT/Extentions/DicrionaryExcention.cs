﻿using System.Collections.Generic;

namespace McAI.BOT.Extentions
{
    public static class DicrionaryExcention
    {
        public static bool ContainsOrAdd<T>(this HashSet<T> hash, T hashValue)
        {
            if (hash.Contains(hashValue))
                return true;

            hash.Add(hashValue);
            return false;
        }
    }
}
