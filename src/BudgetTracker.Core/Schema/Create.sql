set xact_abort on

begin transaction

	if exists (select * from [Information_Schema].[Tables] where [Table_Name] = 'Transactions')
	drop table [Transactions]

	create table [dbo].[Transactions] (
		[Id] uniqueidentifier not null,
		[DateSynced] datetimeoffset not null,
		[DateOccurred] datetime not null,
		[Amount] decimal(18,2) not null,
		[Description] nvarchar(100) null,
		constraint [PK_Transactions] primary key nonclustered ([Id])
	)

	create clustered index [CI_Transactions]
	on [Transactions] ([DateOccurred])
	go

	if exists (select * from [Information_Schema].[Tables] where [Table_Name] = 'ScheduledItems')
	drop table [ScheduledItems]

	create table [dbo].[ScheduledItems] (
		[Id] uniqueidentifier not null,
		[Description] nvarchar(50) null,
		[DateCreated] datetimeoffset not null,
		[Amount] decimal(18,2) not null,
		[IntendedLastDueDate] datetime not null,
		[ActualLastDueDate] datetime null,
		[Frequency] int not null,
		[TransactionIdentifier] nvarchar(100) null,
		constraint [PK_ScheduledItems] primary key nonclustered ([Id])
	)

	create clustered index [CI_ScheduledItems]
	on [ScheduledItems] ([DateCreated])
	go

commit transaction