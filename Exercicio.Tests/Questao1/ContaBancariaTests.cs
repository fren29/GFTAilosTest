using Questao1;
using Xunit;
using FluentAssertions;

namespace Exercicio.Tests.Questao1
{
    public class ContaBancariaTests
    {
        [Fact]
        public void Conta_Deve_Inicializar_Sem_Deposito()
        {
            var conta = new ContaBancaria(1001, "João");

            conta.Numero.Should().Be(1001);
            conta.Titular.Should().Be("João");
            conta.Saldo.Should().Be(0.0);
        }

        [Fact]
        public void Conta_Deve_Inicializar_Com_Deposito()
        {
            var conta = new ContaBancaria(1002, "Maria", 500);

            conta.Saldo.Should().Be(500.0);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Titular()
        {
            var conta = new ContaBancaria(1003, "Carlos");
            conta.AlterarTitular("Carlos Silva");

            conta.Titular.Should().Be("Carlos Silva");
        }

        [Fact]
        public void Depositar_Deve_Aumentar_Saldo()
        {
            var conta = new ContaBancaria(1004, "Ana");
            conta.Deposito(300);

            conta.Saldo.Should().Be(300.0);
        }

        [Fact]
        public void Sacar_Deve_Subtrair_Valor_Mais_Taxa()
        {
            var conta = new ContaBancaria(1005, "Beatriz", 1000);
            conta.Saque(200);

            conta.Saldo.Should().BeApproximately(796.5, 0.01);
        }

        [Fact]
        public void Sacar_Pode_Levar_Saldo_Negativo()
        {
            var conta = new ContaBancaria(1006, "Diego");
            conta.Saque(100);

            conta.Saldo.Should().BeApproximately(-103.5, 0.01);
        }
    }
}
