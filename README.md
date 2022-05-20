⚠️ _This repository is not maintained_ ⚠️

---

# SmartContract.Essentials

[![Build Status](https://dev.azure.com/developmomentum/Develop%20Momentum/_apis/build/status/drmathias.SmartContract.Essentials?branchName=master)](https://dev.azure.com/developmomentum/Develop%20Momentum/_build/latest?definitionId=10&branchName=master) [![Nuget](https://img.shields.io/nuget/v/SmartContract.Essentials)](https://www.nuget.org/packages/SmartContract.Essentials/)

## Overview

This is a set of tools that can be used to simplify the development of smart contract applications. Currently the tools included can be used for data encryption and string generation.

## Usage

### Setting up DI

Encryption providers can be created through a factory, allowing you to adhere to SOLID guidelines and test your implementation more easily. Begin by adding the factory to your container.

```csharp
services.AddSingleton<ICipherFactory, AesCipherFactory>();
```

### Encrypting personal data

```csharp
var customerName = "Benjamin Swift";

CbcResult customerNameEncryptionResult;
try
{
    using var cbc = _cipherFactory.CreateCbcProvider();
    customerNameEncryptionResult = cbc.Encrypt(customerName);
}
catch (CryptographicException e)
{
}
catch (ArgumentException e)
{
}

// persist cipher to contract
// give user control of key and IV
```

### Decrypting personal data

```csharp
string customerName;
try
{
    using var cbc = _cipherFactory.CreateCbcProvider();
    customerName = cbc.Decrypt(customerNameCipher, key, iv);
}
catch (CryptographicException e)
{
}
catch (ArgumentException e)
{
}
```

### Generating a random string

```csharp
var generator = new UrlFriendlyStringGenerator();
var value = generator.CreateUniqueString(24);
```
