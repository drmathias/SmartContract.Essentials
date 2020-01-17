# SmartContract.Essentials

## Overview

This is a set of tools that can be used to simplify the development of smart contract applications. Currently the tools included can be used for data encryption and string generation.

## Usage

### Generating a random string

```csharp
var generator = new UrlFriendlyStringGenerator();
var value = generator.CreateUniqueString(24);
```

### Encrypting personal data

```csharp
var customerName = "Benjamin Swift";

CbcResult customerNameEncryptionResult;
using (var aes = new AesCbc())
{
    customerNameEncryptionResult = aes.Encrypt(customerName);
}

// persist cipher to contract
// give user control of key and IV
```

### Decrypting personal data

```csharp
using (var aes = new AesCbc())
{
    var customerName = aes.Decrypt(customerNameCipher, key, iv);
}
```

### Password generation

```csharp
var generator = new UrlFriendlyStringGenerator();
var password = generator.CreatePassword();

CbcResult passwordEncryptionResult;
using (var aes = new AesCbc())
{
    passwordEncryptionResult = aes.Encrypt(password);
}
```