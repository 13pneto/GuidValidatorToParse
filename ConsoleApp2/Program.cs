using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
         static void Main(string[] args)
         {
             var a = "7e329edc-9638-4ebf-822e-b5bd9ab562b";
             var b = "11111111-2222-3333-4444-555555555555";
             var c = "00000000-0000-0000-0000-000000000000";
             var d = "00000001-0010-0001-0001-011000000000";

             List<object> propriedades = new();
            
             propriedades.Add(a);
             propriedades.Add(c);
             propriedades.Add(d);

             foreach (var propriedade in propriedades)
             {
                 TypeCode type = Type.GetTypeCode(propriedade.GetType());
                 var isValidGuid = VerifyIsGuid((string) propriedade);

                     if (isValidGuid)
                     {
                         var parsedPropriedade = Guid.Parse((string) propriedade);
                         if (parsedPropriedade == Guid.Empty) ;
                     }

                     Console.WriteLine(type);
             }
         }


        private static bool VerifyIsGuid(string guid)
        {
            if (guid.Length != 36) return false;
            
            var guidCharArray = guid.ToCharArray();

            var separatorsValid = guidCharArray[8] == '-' && guidCharArray[13] == '-' && guidCharArray[18] == '-' &&
                                  guidCharArray[23] == '-';
        
            if (!separatorsValid) return false;
            
            var numberGroupOne = guid.Substring(0, 8);
            var numberGroupTwo = guid.Substring(9, 4);
            var numberGroupThree = guid.Substring(14, 4);
            var numberGroupFour = guid.Substring(24, 12);

            var groupOneValid = VerifyGroupValid(numberGroupOne);
            var groupTwoValid = VerifyGroupValid(numberGroupTwo);
            var groupThreeValid = VerifyGroupValid(numberGroupThree);
            var groupFourValid = VerifyGroupValid(numberGroupFour);

            return groupOneValid && groupTwoValid && groupThreeValid && groupFourValid;
        }

        private static bool VerifyGroupValid(string group)
        {
            var groupToChar = group.ToCharArray();
            
            bool hasInvalidChar = groupToChar.All(x => x == '0');

            return !hasInvalidChar;
        }
    }
}