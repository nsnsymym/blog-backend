using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Linq;
using System.Security.Cryptography;

namespace BlogBackend.Utils
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            // ソルトを作成する。
            byte[] salt = new byte[128 / 8];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            // Pbkdf2 メソッドではハッシュ化する反復回数や作成するハッシュの長さを指定することができます。
            // OS をよって最適化された実装が選択され、自前で実装するよりもパフォーマンスが向上するそうです。
            // https://docs.microsoft.com/ja-jp/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-3.0
            byte[] hash = KeyDerivation.Pbkdf2(
              password,
              salt,
              prf: KeyDerivationPrf.HMACSHA256,
              iterationCount: 10000,  // 反復回数
              numBytesRequested: 256 / 8);  // ハッシュの長さ

            // ハッシュ値を 16 進数文字列に変換します。
            return string.Concat(hash.Select(b => $"{b:x2}"));
        }
    }
}
