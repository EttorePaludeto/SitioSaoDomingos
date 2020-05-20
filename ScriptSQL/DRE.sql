
SELECT D.DRE, D.Financeiro, D.Economico, D.Contabil, SUM(VALOR) AS Valor  FROM 
(
select p.DRE, p.Financeiro, p.Economico, p.Contabil, SUM(d.valor) as Valor from diario as d inner join PlanoContas as p on d.DebitoId = p.Id
group by p.DRE, p.Financeiro, p.Economico, p.Contabil
union
select p.DRE, p.Financeiro, p.Economico, p.Contabil, SUM(d.valor)*-1 as Valor from diario as d inner join PlanoContas as p on d.CreditoId = p.Id
group by p.DRE, p.Financeiro, p.Economico, p.Contabil
) AS D
GROUP BY D.DRE, D.Financeiro, D.Economico, D.Contabil
