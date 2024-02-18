using System;
using JetBrains.Metadata.Reader.API;
using JetBrains.Metadata.Reader.Impl;
using ReSharperPlugin.ReqnrollRiderPlugin.Psi;

namespace ReSharperPlugin.ReqnrollRiderPlugin.Helpers
{
    public class ReqnrollAttributeHelper
    {
        public static readonly ClrTypeName BindingAttribute = new ClrTypeName("Reqnroll.BindingAttribute");
        public static readonly ClrTypeName ScopeAttribute = new ClrTypeName("Reqnroll.ScopeAttribute");
        public static readonly ClrTypeName StepDefinitionAttribute = new ClrTypeName("Reqnroll.StepDefinitionAttribute");
        public static readonly ClrTypeName GivenAttribute = new ClrTypeName("Reqnroll.GivenAttribute");
        public static readonly ClrTypeName WhenAttribute = new ClrTypeName("Reqnroll.WhenAttribute");
        public static readonly ClrTypeName ThenAttribute = new ClrTypeName("Reqnroll.ThenAttribute");
        public const string StepDefinitionAttributeShortName = "StepDefinition";
        public const string GivenAttributeShortName = "Given";
        public const string WhenAttributeShortName = "When";
        public const string ThenAttributeShortName = "Then";

        public static string GetAttributeClrName(GherkinStepKind stepKind)
        {
            switch (stepKind)
            {
                case GherkinStepKind.Given:
                    return GivenAttribute.FullName;
                case GherkinStepKind.When:
                    return WhenAttribute.FullName;
                case GherkinStepKind.Then:
                    return ThenAttribute.FullName;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stepKind), stepKind, null);
            }
        }

        public static GherkinStepKind? GetAttributeStepKind(IClrTypeName typeName)
        {
            if (typeName.Equals(GivenAttribute))
                return GherkinStepKind.Given;
            if (typeName.Equals(WhenAttribute))
                return GherkinStepKind.When;
            if (typeName.Equals(ThenAttribute))
                return GherkinStepKind.Then;
            return null;
        }

        public static bool IsAttributeForKindUsingShortName(GherkinStepKind stepKind, string typeShortName)
        {
            if (typeShortName.Equals(StepDefinitionAttributeShortName))
                return true;
            if (stepKind == GherkinStepKind.Given && typeShortName.Equals(GivenAttributeShortName))
                return true;
            if (stepKind == GherkinStepKind.When && typeShortName.Equals(WhenAttributeShortName))
                return true;
            if (stepKind == GherkinStepKind.Then && typeShortName.Equals(ThenAttributeShortName))
                return true;
            return false;
        }

        public static bool IsAttributeForKind(GherkinStepKind stepKind, string fullName)
        {
            if (StepDefinitionAttribute.FullName == fullName)
                return true;
            if (stepKind == GherkinStepKind.Given && GivenAttribute.FullName == fullName)
                return true;
            if (stepKind == GherkinStepKind.When && WhenAttribute.FullName == fullName)
                return true;
            if (stepKind == GherkinStepKind.Then && ThenAttribute.FullName == fullName)
                return true;
            return false;
        }
    }
}