Scaffold-DbContext "server=127.0.0.1;port=3306;userid=root;password=root;database=backendmpos;" Pomelo.EntityFrameworkCore.MySql -o Entities -Force -UseDatabaseNames -NoPluralize -ContextDir ../TCCPOS.Backend.SaleService.Infrastructure/Repository -ContextNamespace TCCPOS.Backend.SaleService.Infrastructure.Repository -Context SaleContext

dotnet new tool-manifest
dotnet tool install swashbuckle.aspnetcore.cli --version 6.3.1
ระวังว่า version ของ cli ต้องตรงกับ version ของ package ที่ใช้อยู่ใน project