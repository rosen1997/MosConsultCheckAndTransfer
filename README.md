# MosConsultCheckAndTransfer

How to install:

1. Import file MosConsultTestDb.bacpac from folder DB as data-tier application.
  1.1 Quieries from QueriesToCheck.sql can be used to check the data.
  
2. Open file ..\MosConsultCheckAndTransfer\CheckAndTransferService\Program.cs and on row 21 replace the db connection string with the connection string from the imported db.

3. Rebuild the solution on Release using visual studio or open PowerShell in project directory and use command dotnet publish -o <Name of Publish Directory>
  
4. To install the project as windows service open cmd as administrator and run command sc create CheckAndTransferService binPath=<full path to CheckAndTransferService.exe in publish directory>
  
5. To start the service use command sc start CheckAndTransferService or open services on windows, find CheckAndTransfer service, right mouse button and press start.
