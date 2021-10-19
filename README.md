# Bet.Extensions.Shopify

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/kdcllc/Bet.Extensions.Shopify/master/LICENSE)
![Master CI](https://github.com/kdcllc/Bet.Extensions.Shopify/actions/workflows/master.yml/badge.svg)
![Dev CI](https://github.com/kdcllc/Bet.Extensions.Shopify/actions/workflows/dev.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/Bet.Extensions.Shopify.svg)](https://www.nuget.org/packages?q=Bet.Extensions.Shopify)
![Nuget](https://img.shields.io/nuget/dt/Bet.Extensions.Shopify)
[![feedz.io](https://img.shields.io/badge/endpoint.svg?url=https://f.feedz.io/kdcllc/bet-extensions-shopify/shield/Bet.Extensions.Shopify/latest)](https://f.feedz.io/kdcllc/bet-extensions-shopify/packages/Bet.Extensions.Shopify/latest/download)

> The second letter in the Hebrew alphabet is the ב bet/beit. Its meaning is "house". In the ancient pictographic Hebrew it was a symbol resembling a tent on a landscape.

_Note: Pre-release packages are distributed via [feedz.io](https://f.feedz.io/kdcllc/bet-extensions-shopify/nuget/index.json)._

## Summary

Yet another Shopify `DotNetCore` library which provides with simple and consistent way to deal with Shopify Admin Api with new .Net Core tech stack.

The main goal was to design a library that supports the latest functionality for `HttpClient` and `System.Text.Json` libraries.

This project consists of the following nuget packages:

- [`Bet.Extensions.Shopify.Models`](./src/Bet.Extensions.Shopify.Models/) - is a library that contains only representation of Shopify models.
  It only depends on `System.Text.Json` for serialization and de-serialization.

- [`Bet.Extensions.Shopify.Abstractions`](./src/Bet.Extensions.Shopify.Abstractions/) - is an abstraction library that can be used across different projects.

- [`Bet.Extensions.Shopify`](./src/Bet.Extensions.Shopify/)

- [`Bet.AspNetCore.Shopify`](./src/Bet.AspNetCore.Shopify/) - is a library to be used with AspNetCore application, enables support for Webhooks with a simple model.

## Hire me

Please send [email](mailto:kingdavidconsulting@gmail.com) if you consider to **hire me**.

[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Install

```csharp
    dotnet add package Bet.Extensions.Shopify.Models

    dotnet add package Bet.Extensions.Shopify.Abstractions

    dotnet add package Bet.Extensions.Shopify

    dotnet add package Bet.AspNetCore.Shopify
```

## Resources

- [Shopify APIs](https://shopify.dev/api/usage)
