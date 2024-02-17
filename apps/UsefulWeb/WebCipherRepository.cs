﻿// <copyright file="WebCipherRepository.cs" company="APH Software">
// Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>

using Useful.Security.Cryptography;

namespace UsefulWeb
{
    public class WebCipherRepository : CipherRepository
    {
        public WebCipherRepository()
        {
            Atbash cipher = new();
            Create(cipher);
            Create(new Rot13());
            CurrentItem = cipher;
        }
    }
}