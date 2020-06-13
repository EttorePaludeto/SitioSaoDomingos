DECLARE @DT_INI AS DATE
DECLARE @DT_FIM AS DATE
DECLARE @DT_FECHA AS DATE --DATA DE FECHAMENTO DO ÚLTIMO BALANÇO (Normalmente em 31/12/XX) => SaldoInicial = Between DtFechamento e DtInicial
SET @DT_INI = '2019-01-01'
SET @DT_FIM = '2019-12-31'	
		SELECT ROW_NUMBER() OVER(ORDER BY BALANCETE.CONTABIL) AS ID, BALANCETE.Grupo, BALANCETE.SubGrupo, BALANCETE.Financeiro, BALANCETE.Economico, BALANCETE.Contabil, SUM(BALANCETE.SaldoInicial) As SaldoInicial, SUM(BALANCETE.Debito) AS Debito, SUM(BALANCETE.Credito) As Credito, SUM(BALANCETE.SaldoInicial + BALANCETE.Debito - BALANCETE.Credito) As SaldoFinal FROM 
		(
			SELECT D.Grupo, D.SubGrupo, D.Financeiro, D.Economico, D.Contabil, 0 AS SaldoInicial, Sum(D.Debito) As Debito, Sum(D.Credito) AS Credito, Sum(D.Debito-D.Credito) As SaldoMovimento FROM 
            (
            select p.Grupo, p.SubGrupo, p.Financeiro, p.Economico, p.Contabil, SUM(d.valor) as Debito, 0 as Credito from diario as d inner join PlanoContas as p on d.DebitoId = p.Id
            where d.Data between @DT_INI and @DT_FIM
            group by p.Grupo, p.SubGrupo,  p.Financeiro, p.Economico, p.Contabil
            union
            select p.Grupo, p.SubGrupo, p.Financeiro, p.Economico, p.Contabil, 0 as Debito, SUM(d.valor) as Credito from diario as d inner join PlanoContas as p on d.CreditoId = p.Id
            where d.Data between @DT_INI and @DT_FIM
            group by p.Grupo, p.SubGrupo, p.Financeiro, p.Economico, p.Contabil
            ) AS D
            GROUP BY D.Grupo, D.SubGrupo, D.Financeiro, D.Economico, D.Contabil
            UNION

			--SALDO INICIAL
			 SELECT D.Grupo, D.SubGrupo, D.Financeiro, D.Economico, D.Contabil, SUM(d.SaldoInicial) AS SaldoInicial, 0 As Debito, 0 AS Credito, 0 As SaldoFinal FROM 
            (
            select p.Grupo, p.SubGrupo, p.Financeiro, p.Economico, p.Contabil, SUM(d.valor) AS SaldoInicial, 0 as Debito, 0 as Credito from diario as d inner join PlanoContas as p on d.DebitoId = p.Id
            where d.Data < @DT_INI
            group by p.Grupo, p.SubGrupo,  p.Financeiro, p.Economico, p.Contabil
            union
            select p.Grupo, p.SubGrupo, p.Financeiro, p.Economico, p.Contabil, SUM(d.valor) AS SaldoInicial,  0 as Debito, 0 as Credito from diario as d inner join PlanoContas as p on d.CreditoId = p.Id
            where d.Data < @DT_INI
            group by p.Grupo, p.SubGrupo,  p.Financeiro, p.Economico, p.Contabil
            ) AS D
            GROUP BY D.Grupo, D.SubGrupo,D.Financeiro, D.Economico, D.Contabil
	     ) AS BALANCETE
		 GROUP BY BALANCETE.Grupo, BALANCETE.SubGrupo, BALANCETE.Financeiro, BALANCETE.Economico, BALANCETE.Contabil