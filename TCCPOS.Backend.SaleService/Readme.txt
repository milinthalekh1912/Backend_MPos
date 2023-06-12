Scaffold-DbContext "server=sql12.freemysqlhosting.net;port=3306;userid=sql12624485;password=2yQH9jVYrV;database=sql12624485;" Pomelo.EntityFrameworkCore.MySql -o Entities -Force -UseDatabaseNames -NoPluralize -ContextDir ../TCCPOS.Backend.SaleService.Infrastructure/Repository -ContextNamespace TCCPOS.Backend.SaleService.Infrastructure.Repository -Context SaleContext

dotnet new tool-manifest
dotnet tool install swashbuckle.aspnetcore.cli --version 6.3.1
ระวังว่า version ของ cli ต้องตรงกับ version ของ package ที่ใช้อยู่ใน project