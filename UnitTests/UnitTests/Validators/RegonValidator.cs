using System.Linq;
using Workshops.AppLogic.Validators.Exceptions;

namespace Workshops.AppLogic.Validators
{
  public class RegonValidator
  {
    public static void Validate(string regon)
    {
      if (regon.Length != 9 && regon.Length != 14)
        throw new WrongLengthException(regon);

      if (!regon.All(x => x <= '9' && x >= '0'))
      {
        throw new IncorrectCharsException(regon);
      }

      int[] weights = new int[0];

      if (regon.Length == 9)
        weights = new[] { 8, 9, 2, 3, 4, 5, 6, 7, 0};

      if (regon.Length == 14)
        weights = new[] {2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8, 0};

      int sum = regon.Zip(weights, (digit, weight) => (digit - '0') * weight).Sum();

      if (sum % 11 != regon.Last() - '0')
      {
        throw new NotValidException(regon);
      }
    }
  }
}