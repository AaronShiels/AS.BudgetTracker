set xact_abort on

begin transaction

	if exists (select * from [Information_Schema].[Tables] where [Table_Name] = 'Transactions')
	drop table [Transactions]

	create table [dbo].[Transactions] (
		[Id] uniqueidentifier not null,
		[Date] datetime not null,
		[Amount] decimal(18,2) not null,
		[Description] nvarchar(100) null,
		constraint [PK_Transactions] primary key nonclustered ([Id])
	)

	create clustered index [CI_Transactions]
	on [Transactions] ([Date])

commit transaction