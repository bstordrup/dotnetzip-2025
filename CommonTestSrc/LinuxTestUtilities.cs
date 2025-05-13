// LinuxTestUtilities.cs
// ------------------------------------------------------------------
//
// Copyright (c) 2009-2011, 2025 Dino Chiesa.
// All rights reserved.
//
// This code module is part of DotNetZip, a zipfile class library.
//
// This module defines some utility classes used by the unit tests for
// DotNetZip.
//
// ------------------------------------------------------------------
//
// This code is licensed under the Apache 2.0 Public License.
// See the file LICENSE.txt that accompanies the source code, for the license details.
//
// ------------------------------------------------------------------

using System.Diagnostics;
using System.Security.Cryptography;

namespace Ionic.Zip.Tests.Utilities
{
    class LinuxTestUtilities
    {
        private static Dictionary<char, string> linuxSpecialfileTypes = new Dictionary<char, string>
        {
            ['b'] = "Block device",
            ['c'] = "Character device",
            ['l'] = "Symbol link",
            ['p'] = "Pipe file",
            ['s'] = "Socket file"
        };

        public static bool IsSpecialFile(string resultOfLsCommand)
        {
            Debug.WriteLine($"Testing ls result {resultOfLsCommand}");
            char filetype = resultOfLsCommand[0];
            return linuxSpecialfileTypes.ContainsKey(filetype);;
        }

        public static string GetFromUsrOrGlobal(string executable)
        {
            var envPath = Environment.GetEnvironmentVariable("PATH");
            var paths = envPath?.Split(new[] { Path.PathSeparator }, StringSplitOptions.RemoveEmptyEntries) ?? [];
            return (from path in paths
                    let fullPath = Path.Combine(path, executable)
                    where File.Exists(fullPath)
                    select fullPath).FirstOrDefault();
        }
    }


}
