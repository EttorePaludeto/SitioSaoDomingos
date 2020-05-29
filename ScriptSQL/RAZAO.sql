DECLARE @DT_INI AS DATE
DECLARE @DT_FIM AS DATE
DECLARE @DT_FECHA AS DATE --DATA DE FECHAMENTO DO ÚLTIMO BALANÇO (Normalmente em 31/12/XX) => SaldoInicial = Between DtFechamento e DtInicial
DECLARE @CONTA AS VARCHAR(5)
SET @DT_INI = '2019-12-01'
SET @DT_FIM = '2019-12-31'
SET @CONTA = '10001'

SELECT *, ROW_NUMBER() OVER (ORDER BY d.Data) as Ordem  INTO SALDO FROM 
	(select d.Id, d.Data, p.Contabil, d.Historico, d.valor * -1 as Valor, 'C' As Natureza from diario as d inner join PlanoContas as p on d.DebitoId = p.Id
	where d.Data between @DT_INI and @DT_FIM AND CreditoId = @CONTA
	union
	select d.Id, d.Data, p.Contabil, d.Historico, d.valor, 'D' As Natureza from diario as d inner join PlanoContas as p on d.CreditoId = p.Id
	where d.Data between @DT_INI and @DT_FIM AND DebitoId = @CONTA
	union
	select d.Id, d.Data, d.Contabil, d.Historico, CASE WHEN SUM(d.valor) IS NULL THEN 0 ELSE SUM(d.valor) END as Valor, CASE WHEN SUM(d.valor) < 0 THEN 'C' ELSE 'D' END AS Natureza from 
		(select '0000' as Id , @DT_INI as Data, 'Conta Contábil '+ @CONTA as Contabil, 'Saldo Anterior da Conta' as Historico, SUM(d.valor) *-1 as Valor from diario AS d
		where d.Data < @DT_INI AND CreditoId = @CONTA
		union
		select '0000' as Id , @DT_INI, 'Conta Contábil '+ @CONTA, 'Saldo Anterior da Conta', SUM(d.valor) as Valor from diario as d
		where d.Data < @DT_INI AND DebitoId = @CONTA)
		as d
	Group By d.Id, d.Data, d.Contabil, d.Historico) AS D

SELECT S1.Id, S1.Data, S1.Contabil, S1.Historico, S1.Valor, SUM(S2.Valor) as Saldo, S1.Ordem FROM SALDO AS S1 INNER JOIN SALDO AS S2 ON S1.Ordem >= S2.Ordem
Group By S1.Id, S1.Data, S1.Contabil, S1.Historico, S1.Valor, S1.Ordem
Order By S1.Ordem

DROP TABLE SALDO



            
          