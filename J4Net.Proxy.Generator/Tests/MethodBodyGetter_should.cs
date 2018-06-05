using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;

namespace ProxyGenerator.SourceGeneration
{
    [TestFixture]
    class MethodBodeyGetter_should
    {
        [Test]
        public void TestGetMethod()
        {
            var result = MethodBodyGetter.GetMember("Object", "Member");
            Assert.AreEqual("Object.Member", result.ToString());
        }

        [Test]
        public void TestGetInvocationSimple()
        {
            var result = MethodBodyGetter.GetInvocationFor(
                "obj", "DoSmth",
                SyntaxFactory.IdentifierName("localVar"));
            Assert.AreEqual("obj.DoSmth(localVar)", result.ToString());
        }

        [Test]
        public void TestGetInvocationComplex()
        {
            var result = MethodBodyGetter.GetInvocationFor(
                "obj", "DoSmth",
                SyntaxFactory.IdentifierName("localVar"),
                SyntaxFactory.IdentifierName("anotherVar"),
                SyntaxFactory.ObjectCreationExpression(
                    SyntaxFactory.IdentifierName("A"))
                    .WithArgumentList(SyntaxFactory.ArgumentList())
                    .NormalizeWhitespace());
            Assert.AreEqual("obj.DoSmth(localVar,anotherVar,new A())", result.ToString());
        }
        [Test]
        public void TestGetInvocationReal()
        {
            // generated automatically with RoslynQuoter
            var expectedEnvCallObjectMethodExpression = SyntaxFactory
                .InvocationExpression(
                SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.IdentifierName("Env"),
                    SyntaxFactory.IdentifierName("CallObjectMethod")))
                .WithArgumentList(SyntaxFactory.ArgumentList(
                    SyntaxFactory.SeparatedList<ArgumentSyntax>(new SyntaxNodeOrToken[]{
                        SyntaxFactory.Argument(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName("jObject"),
                                SyntaxFactory.IdentifierName("Ptr"))),
                        SyntaxFactory.Token(SyntaxKind.CommaToken),
                        SyntaxFactory.Argument(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName("GetClassNameMethod"),
                                SyntaxFactory.IdentifierName("Ptr")))})));
            var actualEnvCallObjectMethodExpression =
                MethodBodyGetter.GetInvocationFor(
                    "Env", "CallObjectMethod",
                    MethodBodyGetter.GetMember("jObject", "Ptr"),
                    MethodBodyGetter.GetMember("GetClassNameMethod", "Ptr"));
            Assert.AreEqual(
                expectedEnvCallObjectMethodExpression.ToString(),
                actualEnvCallObjectMethodExpression.ToString());
        }
    }
}
