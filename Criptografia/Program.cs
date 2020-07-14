using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Criptografia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira a senha a ser criptografada");
            string senha = Console.ReadLine();
            string senhaCripto = "";
            int qtdSenha = senha.Length;
            const string valor = "!";
            const string valor2 = "~";
            byte[] valorByte = Encoding.ASCII.GetBytes(valor);
            byte[] valorByte2 = Encoding.ASCII.GetBytes(valor2);
            string charSenha;
            string charSenhaCripto;
            byte[] codigoCharSenha;
            Boolean naoValido = false;

            //Console.WriteLine("Quantidade de caracteres da senha '" + senha + "': " + qtdSenha);

            for (int i = 0; i < qtdSenha; i++)
            {
                charSenha = senha.Substring(i, 1);
                //Console.WriteLine("Caracter atual da posição " + i + ":" + charSenha);
                codigoCharSenha = Encoding.ASCII.GetBytes(charSenha);
                //Console.WriteLine("Código ASCII desse char da senha:" + codigoCharSenha[0]);


                int a = valorByte[0] + valorByte2[0] - codigoCharSenha[0];
                //Console.WriteLine("Código ASCCI senha criptografado:" + a);
                charSenhaCripto = System.Text.ASCIIEncoding.Default.GetString(BitConverter.GetBytes(a));
                //Console.WriteLine("Caracter criptografada da posição " + i + ":" + charSenhaCripto);
                //Console.WriteLine("\n");

                senhaCripto += charSenha.Replace(charSenha, charSenhaCripto);
                senhaCripto = senhaCripto.TrimEnd('\0');

                bool result = Regex.IsMatch(charSenha, @".*[^\u0000-\u007F].*");

                if (result == true || result == Regex.IsMatch(charSenha, @"[^\u0020]"))
                {
                    naoValido = true;
                }

            }

            if (naoValido == false)
            {
                Console.WriteLine("A antiga senha é: " + senha);
                Console.WriteLine("A nova senha é: " + senhaCripto);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Char inválido detectado.");
                Console.ReadLine();
            }
        }
    }
}
