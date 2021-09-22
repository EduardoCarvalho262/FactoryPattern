using System;

namespace FactoryPattern
{

    interface IVeiculos
    {
        string Modelo();
    }

    class Moto : IVeiculos
    {
        public string Modelo()
        {
            return "Sou uma moto top";
        }
    }

    class Carro : IVeiculos
    {
        public string Modelo()
        {
            return "Sou um civic";
        }
    }

    abstract class HondaFabrica
    {
        public abstract IVeiculos FactoryMethod();

        public string FazAlgumaCoisa()
        {
            var product = FactoryMethod();

            var result = $"Fábrica Honda: criando um veiculo com o mesmo código -> {product.Modelo()}";

            return result;
        }
    }

    class CriadorMoto : HondaFabrica
    {
        public override IVeiculos FactoryMethod()
        {
            return new Moto();
        }
    }

    class CriadorCarro : HondaFabrica
    {
        public override IVeiculos FactoryMethod()
        {
            return new Carro();
        }
    }

    class Cliente
    {
        public void Main()
        {
            Console.WriteLine("App: Criando uma Moto");
            CriarVeiculo(new CriadorMoto());

            Console.WriteLine("");

            Console.WriteLine("App: Criando um carro");
            CriarVeiculo(new CriadorCarro());
        }

        public void CriarVeiculo(HondaFabrica fabrica)
        {
            Console.WriteLine("Cliente: Eu quero um veiculo independente de quem está criando, quero que funcione.\n" + fabrica.FazAlgumaCoisa());
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            new Cliente().Main();
        }
    }

}
