using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MeuPensamento.Tools.Util
{
    public class CriptografiaProvider
    {
        public string MD5Hash(string input)
        {
            using (var myHash = MD5.Create())
            {
                /*
                 * 2. Invoke the ComputeHash method by passing 
                      a byte array. 
                 *    Just remember, you can pass any raw data, 
                      and you need to convert that raw data 
                      into a byte array.
                 */
                var byteArrayResultOfRawData =
                      Encoding.UTF8.GetBytes(input);

                /*
                 * 3. The ComputeHash method, after a successful 
                      execution it will return a byte array, 
                 *    and you should store that in a variable. 
                 */

                var byteArrayResult =
                     myHash.ComputeHash(byteArrayResultOfRawData);

                /*
                 * 4. After the successful execution of ComputeHash, 
                      you can then convert 
                      the byte array into a string. 
                 */

                return
                  string.Concat(Array.ConvertAll(byteArrayResult,
                                       h => h.ToString("X2")));
            }
        }
    }
}
