namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().Trim().ToUpper();

            // Verifica se a placa é válida
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine("Veículo cadastrado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().Trim().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());

                if (horas < 0)
                {
                    Console.WriteLine("Quantidade de horas inválida. Tente novamente.");
                    return;
                }

                decimal valorTotal = precoInicial + precoPorHora * horas;

                string placaRemover = veiculos.First(x => x.ToUpper() == placa.ToUpper());

                veiculos.Remove(placaRemover);

                Console.WriteLine($"O veículo {placaRemover} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");


                int indice = 1;
                foreach (string item in veiculos)
                {
                    Console.WriteLine($"Veículo n°{indice} placa: {item}");
                    indice++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
