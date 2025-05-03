// SkipOnLinuxFactAttribute.cs
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

using System.Runtime.InteropServices;

namespace Ionic.Zip.Tests.Utilities
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    class FactOnWindowsAttribute : FactAttribute
    {
        public FactOnWindowsAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Skip = $"Skip because platform is not Windows";
            }
        }
    }  

}
