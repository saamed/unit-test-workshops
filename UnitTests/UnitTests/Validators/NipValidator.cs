using System.Linq;

namespace Workshops.AppLogic.Validators
{
  public class NipValidator
  {
    public static void Validate(string nip)
    {
      if (nip.Length != 10)
        throw new WrongLengthException(nip);

      if (!nip.All(x => x <= '9' && x >= '0'))
      {
        throw new IncorrectCharsException(nip);
      }

      int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7, 0 };

      int sum = nip.Zip(weights, (digit, weight) => (digit - '0') * weight).Sum();

      if (sum % 10 != nip[9] - '0')
      {
        throw new NotValidException(nip);
      }
    }
  }
}