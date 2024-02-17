﻿// Copyright (c) Andrew Hawkins. All rights reserved.

namespace Useful.Security.Cryptography
{
    /// <summary>
    /// Enigma Reflector settings generator.
    /// </summary>
    internal static class EnigmaRotorGenerator
    {
        public static IEnigmaRotors Generate()
        {
            Random rnd = new();
            int nextRandomNumber;
            Dictionary<EnigmaRotorPosition, IEnigmaRotor> rotors = new();

            List<int> usedRotorNumbers = new();

            foreach (EnigmaRotorPosition rotorPosition in EnigmaRotors.RotorPositions)
            {
                while (true)
                {
                    nextRandomNumber = rnd.Next(0, EnigmaRotors.RotorSet.Count);
                    if (!usedRotorNumbers.Contains(nextRandomNumber))
                    {
                        usedRotorNumbers.Add(nextRandomNumber);
                        break;
                    }
                }

                rotors[rotorPosition] = new EnigmaRotor()
                {
                    RotorNumber = EnigmaRotors.RotorSet[nextRandomNumber],
                    RingPosition = new Random().Next(1, 26),
                    CurrentSetting = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[new Random().Next(0, 25)],
                };
            }

            return new EnigmaRotors()
            {
                Rotors = rotors,
            };
        }
    }
}