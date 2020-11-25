﻿// <copyright file="IEnigmaSettings.cs" company="APH Software">
// Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>

namespace Useful.Security.Cryptography
{
    /// <summary>
    /// The enigma algorithm settings.
    /// </summary>
    public interface IEnigmaSettings
    {
        /// <summary>
        /// Gets the plugboard settings.
        /// </summary>
        public IEnigmaPlugboardSettings Plugboard { get; }

        /// <summary>
        /// Gets the reflector being used.
        /// </summary>
        public EnigmaReflectorNumber ReflectorNumber { get; }

        /// <summary>
        /// Gets the rotors.
        /// </summary>
        public EnigmaRotorSettings Rotors { get; }
    }
}