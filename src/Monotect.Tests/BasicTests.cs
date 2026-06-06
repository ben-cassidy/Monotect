// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using Monotect;
using System;
using Xunit;

namespace Monotect.Tests;

public class BasicTests
{
    [Fact]
    public void True_IsTrue()
    {
        Assert.True(true);
    }

    [Fact]
    public void Banana_IsBanana()
    {
        Assert.Equal("banana", TestClass.TestString.ToLower());
    }
}
