﻿Feature: CipherViewModel

@mytag
Scenario: CipherViewModel - Initialization
	Given I have a CipherViewModel
	Then the CurrentCipher is not null
	And the CurrentCipherName is "MoqCipher"
	And the CipherNames are "MoqCipher"
	And the EncryptCommand is not null

Scenario: CipherViewModel - Plaintext property
	Given I have a CipherViewModel
	And I set the Plaintext property
	Then the Plaintext property has changed

Scenario: CipherViewModel - Ciphertext property
	Given I have a CipherViewModel
	And I set the Ciphertext property
	Then the Ciphertext property has changed

Scenario: CipherViewModel - CurrentCipher property
	Given I have a CipherViewModel
	And I set the CurrentCipher property
	Then the CurrentCipher property has changed
	And the CurrentCipherName property has changed

Scenario: CipherViewModel - CurrentCipherName property
	Given I have a CipherViewModel
	And I set the CurrentCipherName property
	Then the CurrentCipher property has changed
	And the CurrentCipherName property has changed
	
Scenario: CipherViewModel - Encrypt
	Given I have a CipherViewModel
	And my viewmodel plaintext is "MoqPlaintext"
	When I use the viewmodel to encrypt
	Then the viewmodel ciphertext should be "MoqCiphertext"