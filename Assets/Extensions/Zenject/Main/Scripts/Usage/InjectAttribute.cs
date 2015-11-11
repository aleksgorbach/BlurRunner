// Created 22.10.2015 
// Modified by Gorbach Alex 11.11.2015 at 12:43

#region References

using System;

#endregion

//using JetBrains.Annotations;

namespace Zenject {
    [AttributeUsage(
        AttributeTargets.Constructor | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field)]
    // Uncomment for use with ReSharper
    // MeansImplicitUse(ImplicitUseKindFlags.Assign)]
    public class InjectAttribute : Attribute {
        public InjectAttribute(string identifier) {
            Identifier = identifier;
        }

        public InjectAttribute() {
        }

        public string Identifier { get; private set; }
    }
}