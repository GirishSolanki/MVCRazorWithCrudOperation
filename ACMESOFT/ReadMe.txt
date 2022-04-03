-- Run Script into SQl Server that is attached with ACMESOFT.Web/DBScript
-- Change Connectionstring Path Into ACMESOFT.Api/appsettings.json

-- In user table there one row that is inserted as 
User Name : Admin@gmail.com
Password : Admin


Before running this solution we need to set multiple project run in startup.
1.ACMESOFT.Web
2.ACMESOFT.Api

ACMESOFT.Api - This api project that we are calling into ACMESOFT.Web for crude operation on UI Side.

After running project both there will ACMESOFT.Api project URL that we need to set into ACMESOFT.Web/appsettings.json for Api path 
into WebApiUrl if in case differntone.


Project Solution architechture details : 

1.Above solution created into VS2022 and .Net Core version 6.0.3
2.It's Asp.netCore Razor Page with SQl Server 2019
3.It's code first architechture where we need to enable migration.
4.I have used Asp.netcore web api to integrate with frontend with crud operation
5.There is Global Exception used to manage logs about erros


Finally you can run both project same time ACMESOFT.Web,ACMESOFT.Api.

you can put username as Admin@gmail.com and password as Admin
