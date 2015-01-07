set xact_abort on

begin transaction

	if exists (select * from [Information_Schema].[Tables] where [Table_Name] = 'BankTransactions')
	drop table [BankTransactions]

	create table [dbo].[BankTransactions] (
		[Id] uniqueidentifier not null default newid(),
		[DateSynced] datetimeoffset not null,
		[DateOccurred] datetime not null,
		[Amount] decimal(18,2) not null,
		[Description] nvarchar(100) null,
		constraint [PK_BankTransactions] primary key nonclustered ([Id])
	)

	create clustered index [CI_BankTransactions]
	on [BankTransactions] ([DateOccurred] desc)
	go

	if exists (select * from [Information_Schema].[Tables] where [Table_Name] = 'BudgetItemDefinitions')
	drop table [BudgetItemDefinitions]

	create table [dbo].[BudgetItemDefinitions] (
		[Id] uniqueidentifier not null default newid(),
		[Description] nvarchar(50) null,
		[DateCreated] datetimeoffset not null,
		[Amount] decimal(18,2) not null,
		[Frequency] int not null,
		[TransactionIdentifier] nvarchar(100) null,
		constraint [PK_BudgetItemDefinitions] primary key nonclustered ([Id])
	)

	create clustered index [CI_BudgetItemDefinitions]
	on [BudgetItemDefinitions] ([DateCreated])
	go

	if exists (select * from [Information_Schema].[Tables] where [Table_Name] = 'BudgetItemPayments')
	drop table [BudgetItemPayments]

	create table [dbo].[BudgetItemPayments] (
		[Id] uniqueidentifier not null default newid(),
		[DefinitionId] uniqueidentifier not null,
		[DateDue] datetime not null,
		[DatePaid] datetime null,
		constraint [PK_BudgetItemPayments] primary key nonclustered ([Id])
	)

	create clustered index [CI_BudgetItemPayments]
	on [BudgetItemPayments] ([DateDue])
	go

	create nonclustered index [IX_BudgetItemPayments_DefinitionId]
	on [BudgetItemPayments] ([DefinitionId])
	include ([DatePaid])
	go

commit transaction