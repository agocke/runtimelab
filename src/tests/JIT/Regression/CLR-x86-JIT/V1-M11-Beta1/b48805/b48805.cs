// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
//

namespace Test
{
    using System;

    public struct AA
    {
        public static int Main()
        {
            bool[] ab = new bool[2];
            try
            {
                do
                {
                    continue;
                } while (ab[3]);
            }
            catch (IndexOutOfRangeException) { }
            catch (Exception) { }
            return 100;
        }
    }
}
