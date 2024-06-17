namespace validarCPF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://www.4devs.com.br/gerador_de_cpf
            //numero de cpf obtido no site 4devs
            long cpf = 25691356070;

            var tamCpf = 11;

            //var cpfLength = Math.Floor(Math.Log10(cpf) + 1);

            List<int> result = new List<int>();

           var listaDigitos = Digits(cpf);

            static List<int> Digits(long value)
            {
                if (value == 0)
                    return new List<int>();

                List<int> result = new List<int>();

                for (; value != 0; value /= 10)
                    result.Add((int)Math.Abs(value % 10));

                result.Reverse();

                return result;
            }


            if (listaDigitos.Count < tamCpf)
            {
                var zeros = tamCpf - listaDigitos.Count;
                for (int i = 0; i < zeros; i++)
                {
                    listaDigitos.Insert(0, 0);
                }
            }

          
            var soma = 0;

            foreach (var x in listaDigitos.Take(9))
            {
                soma += x * (tamCpf - 1);
                tamCpf--;
            }

            var restoV1 = (soma % 11);
            var digitoV1 = restoV1 < 2 ? 0 : (11 - restoV1);

            Console.WriteLine("Digito Verificador 1: " + digitoV1);

            tamCpf = 11;
            soma = 0;

            foreach (var x in listaDigitos.Skip(1).Take(9))
            {
                soma += x * (tamCpf - 1);
                tamCpf--;
            }

            var restoV2 = (soma % 11);
            var digitoV2 = restoV2 < 2 ? 0 : (11 - restoV2);

            Console.WriteLine("Digito Verificador 1: " + digitoV2);


            if (digitoV1 == listaDigitos.Slice(9, 1).FirstOrDefault() && digitoV2 == listaDigitos.LastOrDefault())
            {
                Console.WriteLine("Hello, World! CPF VALIDO");
            }
            else
            {
                Console.WriteLine("Hello, World! CPF INVÁLIDO");
            }
        }
    }
}
