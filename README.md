# Math Utils
[![license](https://img.shields.io/github/license/mashape/apistatus.svg?style=flat-square)]()

Contains useful bits to tackle different math problems.

> PM> Install-Package Zavolokas.Math -Version 1.0.0

## Combinatorics
  - `GetAllCombinations<T>` extension method helps to find all combinations of the items that an `IEnumerable<T>` contains.
  - Static `BinPacker` class helps to pack a set of items with defined cost to a minimal amount of bins.

## Random
  - Contains a `FastRandom` class that is faster than the `System.Random` one. There is a sample code available that demostrates the performance gain.
