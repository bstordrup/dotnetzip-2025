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

namespace Ionic.Zip.Tests.Attributes
{
    /// <summary>
    /// Base xUnit Fact for OS specific tests.
    /// </summary>
    class FactOnOsAttribute: FactAttribute
    {
        protected void Evaluate(OSPlatform targetOs)
        {
            if (!RuntimeInformation.IsOSPlatform(targetOs))
            {
                Skip = $"Skip because platform is not {targetOs}";
            }
        }
    }

    /// <summary>
    /// A xUnit Fact that specifically target Windows
    /// </summary>
    class FactOnWindowsAttribute: FactOnOsAttribute
    {
        public FactOnWindowsAttribute() => Evaluate(OSPlatform.Windows);
    }  

    /// <summary>
    /// A xUnit Fact that specifially target Linux
    /// </summary>
    class FactOnLinuxAttribute: FactOnOsAttribute
    {
        public FactOnLinuxAttribute() => Evaluate(OSPlatform.Linux);
    }

    class FactOnOSXAttribute: FactOnOsAttribute
    {
        public FactOnOSXAttribute() => Evaluate(OSPlatform.OSX);
    }

    class FactOnFreeBSDAttribute: FactOnOsAttribute
    {
        public FactOnFreeBSDAttribute() => Evaluate(OSPlatform.FreeBSD);
    }
}
