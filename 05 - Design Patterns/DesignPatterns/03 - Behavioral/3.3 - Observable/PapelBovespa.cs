﻿namespace DesignPatterns.Behavioral.Observable;

// Concrete Subject
public class PapelBovespa : Investimento
{
    public PapelBovespa(string simbolo, decimal preco)
        : base(simbolo, preco)
    {
    }
}
