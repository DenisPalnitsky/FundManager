# FundManager

Dependencies:
 Dependencies:
 - NUnit and Moq for tests
 - Prism for WPF INotifyProperty change implementation
 

Comments:
 - I didn't have time for UI so couple of ViewModels are missing test coverage at all and rest have just basic tests without coverage of corner cases.
 - I would not allow to enter Price and Quantity that are less then zero, but there is requirement to "highlighted Stocks whose Market Value is < 0" so I leave it as is.
 - One unclear point. TotalNumber - is it sum of Quntities or number of Stocks? I assumed that it's number of stocks.
 
