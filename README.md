# FundManager

Task:

Given the below User Story, create a C# Winforms/WPF application that meets the Product 

Owners Acceptance Criteria. There are no time constraints and you are free to use any 

resources at your disposal. 

Please consider and exhibit Object-Oriented, UI and TDD design principles in your solution.

User Story

As a Fund Manager, I want to be able to add stocks to my Fund so that I can manage and report 

on my Fund.

Acceptance Criteria

1) I can add an 'Equity' or 'Bond' stock to my Fund via a Panel at the top of my screen.

2) When adding an 'Equity' or 'Bond' stock to my Fund, I must specify the price I bought the 

stock at and the quantity of the stock that I bought, which are both mandatory when adding a 

stock to my fund

3) I can see all stocks added to my Fund in a data grid in a Panel in the middle of my screen, 

showing the following stock level information:

 Stock Type e.g. 'Equity' or 'Bond'

 Stock Name - dynamically generated from Stock Type and the number of occurrences of 

that Stock Type in the Fund e.g. 'Equity1', 'Equity2', 'Equity3', 'Bond1'

 Price

 Quantity

 Market Value - calculated from Price * Quantity

 Transaction Cost - calculated from Market Value * 0.5% for 'Equity' Stocks, Market Value 

* 2% for 'Bond' Stocks

 Stock Weight (calculated as a Market Value percentage of the Total Market Value of the 

Fund)

4) In my grid, Stock Name should be highlighted Red for any Stocks whose Market Value is < 0 

or Transaction Cost > Tolerance where Tolerance = 100,000 when Stock Type is 'Bond' or 

Tolerance = 200,000 when Stock Type is 'Equity'

5) On the right hand side of my screen I can see a Panel with the following summary level Fund 

information:

 Equity - Total Number, Total Stock Weight and Total Market Value of Equities in the 

Fund

 Bond - Total Number, Total Stock Weight and Total Market Value of Bonds in the Fund

 All - Total Number, Total Stock Weight and Total Market Value of the Fund



Dependencies:
 Dependencies:
 - NUnit and Moq for tests
 - Prism for WPF INotifyProperty change implementation
 

Comments:
 - I didn't have time for UI so couple of ViewModels are missing test coverage at all and rest have just basic tests without coverage of corner cases.
 - I would not allow to enter Price and Quantity that are less then zero, but there is requirement to "highlighted Stocks whose Market Value is < 0" so I leave it as is.
 - One unclear point. TotalNumber - is it sum of Quntities or number of Stocks? I assumed that it's number of stocks.
 
