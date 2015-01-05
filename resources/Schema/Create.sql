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

	if exists (select * from [Information_Schema].[Tables] where [Table_Name] = 'ScheduledIdentifiers')
	drop table [ScheduledIdentifiers]

	create table [dbo].[ScheduledIdentifiers] (
		[Id] uniqueidentifier not null,
		[Description] nvarchar(50) null,
		[DateCreated] datetimeoffset not null,
		[Amount] decimal(18,2) not null,
		[DateLastDue] datetime not null,
		[DateLastPaid] datetime null,
		[Frequency] int not null,
		[TransactionIdentifier] nvarchar(100) null,
		constraint [PK_ScheduledIdentifiers] primary key nonclustered ([Id])
	)

	create clustered index [CI_ScheduledIdentifiers]
	on [ScheduledIdentifiers] ([DateCreated])
	go

commit transaction