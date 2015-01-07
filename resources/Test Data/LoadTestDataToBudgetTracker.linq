<Query Kind="Program">
  <Connection>
    <ID>3d6548b5-87b6-4aef-ad8d-79571aa32824</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\Source\ASBudgetTracker\src\BudgetTracker.Core\bin\Debug\BudgetTracker.Core.dll</CustomAssemblyPath>
    <CustomTypeName>BudgetTracker.Core.Context.BudgetTrackerDbContext</CustomTypeName>
    <DisplayName>BudgetTracker (Dev)</DisplayName>
    <AppConfigPath>C:\Source\ASBudgetTracker\src\BudgetTracker.Web\Web.config</AppConfigPath>
  </Connection>
  <Reference Relative="..\..\src\BudgetTracker.Core\bin\Debug\BudgetTracker.Core.dll">C:\Source\ASBudgetTracker\src\BudgetTracker.Core\bin\Debug\BudgetTracker.Core.dll</Reference>
  <NuGetReference>Magnum</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Magnum.Extensions</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>BudgetTracker.Core.Entities</Namespace>
  <Namespace>BudgetTracker.Core.Lookups</Namespace>
</Query>

public class TransactionDto {
	public DateTime Date {get;set;}
	public string Description {get;set;}
	public decimal Amount {get;set;}
	public decimal TotalAtTime {get;set;}
}

public class ScheduledItemDto {
	public string Description {get;set;}
	public decimal Amount {get;set;}
	public string Identifier {get;set;}
	public DateTime DateLastDue {get;set;}
	public DateTime DateNextDue {get;set;}
	public string Frequency {get;set;}
	public string DayDue {get;set;}
}

void Main()
{
	var transactionsData = File.ReadAllText(@"C:\Source\ASBudgetTracker\resources\Test Data\Transactions.json");
	var scheduledItemsData = File.ReadAllText(@"C:\Source\ASBudgetTracker\resources\Test Data\ScheduledItems.json");
	
	var transactionDtos = JsonConvert.DeserializeObject<IEnumerable<TransactionDto>>(transactionsData);
	var scheduledItemDtos = JsonConvert.DeserializeObject<IEnumerable<ScheduledItemDto>>(scheduledItemsData);
	
	var scheduledItems = scheduledItemDtos.Select(si => new BudgetItemDefinition(si.Description, si.Amount, (Frequency) Enum.Parse(typeof(Frequency), si.Frequency), si.DateNextDue, si.Identifier));
	
	var transactions = transactionDtos.Select(t => new BankTransaction(t.Date, t.Amount, t.Description));
	
	var db = new BudgetTrackerDbContext();
	scheduledItems.Each(si => db.Insert(si));
	transactions.Each(t => db.Insert(t));
	
	db.SaveChanges();
}

// Define other methods and classes here