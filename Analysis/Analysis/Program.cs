using System;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Analysis
{
    
    class Program
    {
        static void Main()
        {
            var implemetationFilePath = @"C:\Users\HP\source\repos\Analysis\Analysis\Exercise.cs";
            var impletation  = File.ReadAllText(implemetationFilePath);
            var tree = CSharpSyntaxTree.ParseText(impletation);
            var root  = tree.GetRoot();

            if (UsesMethodOverloading(root))
            {
                throw new ArgumentOutOfRangeException(
               "Parameter index is out of range.");
            }

            if (UsesParametersOverloading(root))
            {
                throw new ArgumentOutOfRangeException(
             "Parameter index is out of range.");
            }





        }

        private static bool UsesMethodOverloading(SyntaxNode root)
        {
            return root.DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .Count(method => method.Identifier.Text == "Greeting") > 1;
        }


        private static bool UsesParametersOverloading(SyntaxNode root)
        {
            var gretting =  root.DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .Single(method => method.Identifier.Text == "Greeting");

           return gretting.ParameterList.Parameters[0].Default.Value is LiteralExpressionSyntax literal &&
                literal.IsKind(SyntaxKind.NullLiteralExpression);
        }
    }
}
