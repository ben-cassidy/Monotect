// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Monotect.Generator;

[Generator]
public class TestGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static postInitializationContext =>
        {
            postInitializationContext.AddSource("TestSourceFile.cs", SourceText.From("""
            using System;

            namespace Monotect.Generator.Output;

            public class GeneratedClass
            {
                public void GeneratedMethod()
                    => Console.WriteLine("Test Worked!");
            }

            """, Encoding.UTF8));
        });
    }
}
