using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ProxyGenerator.SourceGeneration
{
    internal class MethodBodyGetter : IMethodBodyGetter
    {
        public static UsingStatementSyntax ParametrizedUsingStatement()
        {
            throw new NotImplementedException();
        }

        public static MemberAccessExpressionSyntax GetMember(string objectVariableName, string memberName)
        {
            return SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.IdentifierName(objectVariableName),
                SyntaxFactory.IdentifierName(memberName));
        }

        public static InvocationExpressionSyntax GetInvocationFor(
            string objectVariableName, string methodName, params ExpressionSyntax[] args)
        {
            var method = GetMember(objectVariableName, methodName);
            var arguments = args.Select(SyntaxFactory.Argument);
            return SyntaxFactory
                .InvocationExpression(method)
                .WithArgumentList(SyntaxFactory.ArgumentList(
                    SyntaxFactory.SeparatedList(arguments)));
        }

        public BlockSyntax GetBodyFor(MethodDeclarationSyntax methodDeclaration)
        {
            var body = new List<StatementSyntax>();
            var usingStatementBody = SyntaxFactory.Block();

            var envCallObjectMethodExpression = MethodBodyGetter.GetInvocationFor(
                    "Env", "CallObjectMethod",
                    MethodBodyGetter.GetMember("jObject", "Ptr"),
                    MethodBodyGetter.GetMember("GetClassNameMethod", "Ptr"));

            var declaration = SyntaxFactory
                .VariableDeclaration(SyntaxFactory.IdentifierName("var"))
                .WithVariables(SyntaxFactory.SingletonSeparatedList(SyntaxFactory
                    .VariableDeclarator(SyntaxFactory.Identifier("a"))
                    .WithInitializer(SyntaxFactory.EqualsValueClause(envCallObjectMethodExpression))));

            var usingStatement = SyntaxFactory.UsingStatement(
                declaration, null, usingStatementBody)
                .NormalizeWhitespace();
            body.Add(usingStatement);
            var res = SyntaxFactory.Block(body);
            return res;
        }
    }
}
