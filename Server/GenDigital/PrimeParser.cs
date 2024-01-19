using System.Collections.Generic;
using Types;

// We are going to use Sieve of Eratosthenes to find prime numbers
namespace Parsers;

internal class PrimeParser()
{
  public List<PrimeNode> Nodes { get; set; }

  public PrimeParser(int n) : this()
  {
    Nodes = new List<PrimeNode>();

    for (int i = 1; i <= (n + 1); i++)
    {
      for (int j = 1; j <= (n + 1); j++)
      {
        Nodes.Add(new PrimeNode { Number = i * j, IsPrime = true });
      }
    }
  }

  public List<PrimeNode> sieveOfEratosthenes()
  {
    int count = Nodes.Count;
    // Foreach node, check if number is prime
    for (int i = 0; i < count; i++)
    {
      Nodes[i].IsPrime = IsPrime(Nodes[i].Number);
    }



    return Nodes;
  }

  private static bool IsPrime(int n)
  {
    if (n <= 1) return false;
    if (n == 2) return true;
    if (n % 2 == 0) return false;

    var boundary = (int)Math.Floor(Math.Sqrt(n));

    for (int i = 3; i <= boundary; i += 2)
    {
      if (n % i == 0)
        return false;
    }

    return true;
  }
}