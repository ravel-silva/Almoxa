using Almoxa.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Almoxa.Domain.Entities
{
    public class Material : Entidade
    {
        public int CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }

        public string Codigo { get; private set; } = string.Empty;
        public string Nome { get; private set; } = string.Empty;
        public string Apelidos { get; private set; } = string.Empty;
        public string Unidade { get; private set; } = string.Empty;
        public TipoMaterial Tipo { get; private set; }
        public string NumeroSerie { get; private set; } = string.Empty;


        public decimal EstoqueMinimo { get; private set; }
        public decimal EstoqueAtual { get; private set; }


        protected Material() { }

        public Material(int categoriaId,
        string codigo,
        string nome,
        string unidade,
        TipoMaterial tipo,
        decimal estoqueMinimo,
        string? apelidos = null,
        string? numeroSerie = null)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new DomainException("O código do material é obrigatório.");
            if (string.IsNullOrWhiteSpace(nome))
                throw new DomainException("O nome do material é obrigatório.");
            if (string.IsNullOrWhiteSpace(unidade))
                throw new DomainException("A unidade do material é obrigatória.");
            if (estoqueMinimo < 0)
                throw new DomainException("O estoque mínimo não pode ser negativo.");
            CategoriaId = categoriaId;
            Codigo = codigo.Trim().ToUpperInvariant();
            Nome = nome.Trim();
            Unidade = unidade.Trim();
            Tipo = tipo;
            EstoqueMinimo = estoqueMinimo;
            Apelidos = apelidos?.Trim();
            NumeroSerie = numeroSerie?.Trim();
        }

        public void RegistrarEntrada(decimal quantidade)
        {
            ValidarQuantidade(quantidade);
            EstoqueAtual += quantidade;
        }

        public void RegistrarSaida(decimal quantidade)
        {
            ValidarQuantidade(quantidade);

            if (quantidade > EstoqueAtual)
                throw new DomainException(
                    $"Estoque insuficiente de '{Nome}'. Disponível: {EstoqueAtual}, solicitado: {quantidade}.");

            EstoqueAtual -= quantidade;
        }

        public void RegistrarDevolucao(decimal quantidade) => RegistrarEntrada(quantidade);

        private static void ValidarQuantidade(decimal quantidade)
        {
            if (quantidade <= 0)
                throw new DomainException("A quantidade deve ser maior que zero.");
        }
    }
}
