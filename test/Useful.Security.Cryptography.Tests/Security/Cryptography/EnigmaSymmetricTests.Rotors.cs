﻿// <copyright file="EnigmaSymmetricTests.Rotors.cs" company="APH Software">
// Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>

namespace Useful.Security.Cryptography.Tests
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using Useful.Security.Cryptography;
    using Xunit;

    public partial class EnigmaSymmetricTests
    {
        [Fact]
        public void RotorsCtor()
        {
            using SymmetricAlgorithm cipher = new EnigmaSymmetric();
            Assert.Equal(Encoding.Unicode.GetBytes("B|III II I|01 01 01|"), cipher.Key);
            Assert.Equal(Encoding.Unicode.GetBytes("A A A"), cipher.IV);
        }

        [Theory]
        [InlineData("B||01 01 01|")] // No rotors
        [InlineData("B|II I|01 01 01|")] // Too few rotors
        [InlineData("B|IV III II I|01 01 01|")] // Too many rotors
        [InlineData("B|I I I|01 01 01|")] // Repeat rotors
        [InlineData("B|III II X|01 01 01|")] // Invalid rotor
        [InlineData("B|III II 1|01 01 01|")] // Rotor as number
        [InlineData("B| III II I |01 01 01|")] // Spacing
        [InlineData("B|III  II  I|01 01 01|")] // Spacing
        public void RotorsInvalid(string key)
        {
            using SymmetricAlgorithm cipher = new EnigmaSymmetric();
            Assert.Throws<ArgumentException>(nameof(cipher.Key), () => cipher.Key = Encoding.Unicode.GetBytes(key));
        }

        [Theory]
        [InlineData("B|III II I|01 01 01|")]
        [InlineData("B|I II III|01 01 01|")]
        [InlineData("B|V IV III|01 01 01|")]
        public void RotorsValid(string key)
        {
            using SymmetricAlgorithm cipher = new EnigmaSymmetric()
            {
                Key = Encoding.Unicode.GetBytes(key),
            };
            Assert.Equal(Encoding.Unicode.GetBytes(key), cipher.Key);
            Assert.Equal(Encoding.Unicode.GetBytes("A A A"), cipher.IV);
        }

        [Theory]
        [InlineData("B|III II I||")] // Rings missing
        [InlineData("B|III II I|01 01|")] // Too few rings
        [InlineData("B|III II I|01 01 01 01|")] // Too many rings
        [InlineData("B|III II I|01 01 1|")] // Number padding
        [InlineData("B|III II I|01 01 00|")] // Number too small
        [InlineData("B|III II I|01 01 27|")] // Number too large
        [InlineData("B|III II I|01 01 0A|")] // Number as letter
        [InlineData("B|III II I| 01 01 01 |")] // Spacing
        [InlineData("B|III II I|01  01  01|")] // Spacing
        public void RingsInvalid(string key)
        {
            using SymmetricAlgorithm cipher = new EnigmaSymmetric();
            Assert.Throws<ArgumentException>(nameof(cipher.Key), () => cipher.Key = Encoding.Unicode.GetBytes(key));
        }

        [Theory]
        [InlineData("B|III II I|26 13 01|")]
        public void RingsValid(string key)
        {
            using SymmetricAlgorithm cipher = new EnigmaSymmetric()
            {
                Key = Encoding.Unicode.GetBytes(key),
            };
            Assert.Equal(Encoding.Unicode.GetBytes(key), cipher.Key);
            Assert.Equal(Encoding.Unicode.GetBytes("A A A"), cipher.IV);
        }

        [Theory]
        [InlineData("A A")] // Too Few
        [InlineData("A A A A")] // Too many
        [InlineData(" A A A ")] // Spacing
        [InlineData("A  A  A")] // Spacing
        public void SettingInvalid(string iv)
        {
            using SymmetricAlgorithm cipher = new EnigmaSymmetric();
            Assert.Throws<ArgumentException>(nameof(cipher.IV), () => cipher.IV = Encoding.Unicode.GetBytes(iv));
        }
    }
}