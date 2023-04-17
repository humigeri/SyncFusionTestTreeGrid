# Syncfusion Blazor TreeGrid bug demonstration

It seems like when a TreeGrid control have a column filled with only null values, it cannot be updated. The update works well when the column contains values.

- Start the program, it will show random weather values in a TreeGrid, grouped monthly. (FetchData.razor)
- Change any cell of "Summary" column. The changed value will be indicated by green background.
- Push "Update". The green background will be gone - it is saved to the datasource.
- Push "DataSourcex" button. This will reload the datasource, but in other mode. This time summary columns are empty. (null)
- Change any cell of "Summary" column. The changed value will be indicated by green background.
- Push "Update". The green background will remain - it is not saved.

In `WeatherForecastService.cs` this line is responsible for the null values: `Summary = dataSourceWithEmptyColumn ? null : Summaries[Random.Shared.Next(Summaries.Length)]`  
If we change `null` to `string.Empty` the problem doesn't occur. But you cannot do the same with other types for example date.