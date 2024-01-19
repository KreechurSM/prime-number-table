using NUnit.Framework;
using Parsers;
using System.Collections.Generic;
using Types;

[TestFixture]
public class PrimeParserTests
{
  [Test]
  public void PrimeTable_Should_Generate_Correct_Primes()
  {
    var primeParser = new PrimeParser(4); // Should generate 25 nodes

    List<PrimeNode> primeTable = primeParser.generatePrimeTable();  // Generate the prime table

    // Check if the correct number of primes are generated
    Assert.That(25, Is.EqualTo(primeTable.Count));

    // Check if the table generated are correct
    Assert.That(1, Is.EqualTo(primeTable[0].Number));
    Assert.That(2, Is.EqualTo(primeTable[1].Number));
    Assert.That(3, Is.EqualTo(primeTable[2].Number));
    Assert.That(4, Is.EqualTo(primeTable[3].Number));
  }

  [Test]
  public void IsPrime_Should_Return_True_For_Prime_Numbers()
  {
    Assert.That(PrimeParser.IsPrime(2), Is.EqualTo(true));
    Assert.That(PrimeParser.IsPrime(3), Is.EqualTo(true));
    Assert.That(PrimeParser.IsPrime(5), Is.EqualTo(true));
    Assert.That(PrimeParser.IsPrime(7), Is.EqualTo(true));
  }

  [Test]
  public void IsPrime_Should_Return_False_For_Non_Prime_Numbers()
  {
    Assert.That(PrimeParser.IsPrime(1), Is.EqualTo(false));
    Assert.That(PrimeParser.IsPrime(4), Is.EqualTo(false));
    Assert.That(PrimeParser.IsPrime(6), Is.EqualTo(false));
    Assert.That(PrimeParser.IsPrime(8), Is.EqualTo(false));
    Assert.That(PrimeParser.IsPrime(9), Is.EqualTo(false));
  }
}