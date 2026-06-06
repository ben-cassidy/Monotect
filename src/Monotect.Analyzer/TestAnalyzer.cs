// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class TestAnalyzer : DiagnosticAnalyzer
{
    public static readonly DiagnosticDescriptor Rule = new(
        id: "MT001",
        title: "Don't use managed types in structs",
        messageFormat: "Remove the managed type",
        category: "ECS Functionality",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    
    private static void Analyze(SymbolAnalysisContext context)
    {
        // Get the type symbol of the type declaration
        var type = (INamedTypeSymbol)context.Symbol;

        // Only concerns structs
        if (type.TypeKind != TypeKind.Struct)
            return;

        // Hypothetically we'd also check here that they implement IComponent

        foreach (IFieldSymbol field in type.GetMembers().OfType<IFieldSymbol>())
        {
            // Skip compiler-generated boilerplate fields
            if (field.IsImplicitlyDeclared)
                continue;
            
            if (!field.Type.IsUnmanagedType)
            {
                Location location = field.Locations.FirstOrDefault()!;
                context.ReportDiagnostic(Diagnostic.Create(Rule, location, field.Name, field.Type));
            }
        }

    }

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.RegisterSymbolAction(Analyze, SymbolKind.NamedType);
    }
}
