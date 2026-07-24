# pravakarCMS

ASP.NET Core 8 MVC migration of the Pravakar's Hospitality hotel website CMS — converted
from a Node.js/Express/EJS/JSON stack to a layered .NET solution (Clean Architecture:
Web / Application / Domain / Infrastructure / Shared) backed by SQL Server via EF Core.

- **Frontend**: existing HTML/CSS/JS preserved exactly, EJS templates converted to Razor views
- **Views**: runtime-compiled (`Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation`) — editable on the server without rebuilding
- **Data**: EF Core + SQL Server (`PRAVAKAR` database), Repository + Unit of Work pattern, no JSON files
- **Auth**: ASP.NET Identity, role-based (Super Admin / Admin / Editor / Content Manager)
