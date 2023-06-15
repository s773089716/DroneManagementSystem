Drone Management System, project features were fully completed, in minimal level.
Included:
1. Fully tested runnable code for all features, best cases.
2. Simple inmemory data
3. Dispatch service
4. Periodic task
5. Postman test collection
6. Logs
7. Docker file
8. Onion architecture
9. SOLID principles
10. Partial model validation

Below items were not included due to the lack of time and could be do as the next phase.
1. SQL Server database
2. Inmemory DbContext
3. Unit testing

Notes: SQL server part and unit testing could be added if time permits.

Instructions:
1. Please use **VisualStudio 2022** or **Visual Studio Code** to clone/open the project.
2. Use IISExpress or builtin server to run the code.
3. Use http://localhost:5010/api/dispatch/GetAvailableDrones as default API.
4. Download and import POSTMAN collection.
5. Please use below link to download and import POSTMAN collection for testing, because unit testing was not added due time didnot permit,
https://github.com/s773089716/DroneManagementSystem/tree/master/PostmanCollection
6. Test all API s using above postman collection (Best cases were tested according to the time limit)
7. To check periodic task data use below logs relative location, inside the project, 
    **DroneManagementSystem\logs**
9. (By default battery level logs would be written for every 5 seconds. hardcoded for now  in https://github.com/s773089716/DroneManagementSystem/blob/master/Scopes/DefaultScopedProcessingService.cs)
10. Inmemory data could be changed in,
https://github.com/s773089716/DroneManagementSystem/blob/master/Infrastructure/InMemoryDataProvider.cs
  


